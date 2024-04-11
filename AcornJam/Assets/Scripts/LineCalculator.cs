using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

struct S_ExpansionEdge
{
    public int x, y;

    public int EdgeWithPreviousCell;

    public S_ExpansionEdge(int x, int y, int previousedge)
    {
        this.x = x;
        this.y = y;
        EdgeWithPreviousCell = previousedge;
    }
}
public class LineCalculator : MonoBehaviour
{
    [SerializeField] private GridManager gridManager;

    GridCell[,] cells { get { return gridManager.gridCells; } }

    List<S_ExpansionEdge> listExpension = new List<S_ExpansionEdge>();

    public void CalculateEdges()
    {
        StartCalculation();
        Calculation();
    }
    private void StartCalculation()
    {
        Vector2Int center = GetCenter();
        EmptySide(center.x, center.y, 0);
        EmptySide(center.x, center.y, 2);
        EmptySide(center.x, center.y, 4);
        FillSide(center.x, center.y, 1);
        FillSide(center.x, center.y, 3);
        FillSide(center.x, center.y, 5);


    }

    private void Calculation()
    {
        int i = 0;
        while(listExpension.Count > 0)
        {
            if (i >= listExpension.Count)
                i = 0;
            Expand(listExpension[i]);
        }
    }

    private void Expand(S_ExpansionEdge S_Expansion)
    {
        listExpension.Remove(S_Expansion);
        List<int> NewExpansions = new List<int>();
        for(int i = 0; i < CalculateExpansionRate(); i++)
        {
            while (true)
            {
                int TryExpand = Random.Range(0, 6);
                if (NewExpansions.Contains(TryExpand))
                    continue;
                if (TryExpand == S_Expansion.EdgeWithPreviousCell)
                    continue;
                if (gridManager.GetCellPosFromEdge(S_Expansion.x, S_Expansion.y, TryExpand).x >= 0)  
                NewExpansions.Add(TryExpand);
                break;
            }          
        }
        for(int i = 0; i<6 ; i++)
        {
            if (i == S_Expansion.EdgeWithPreviousCell)
                continue;
            if(NewExpansions.Contains(i))
                EmptySide(S_Expansion.x, S_Expansion.y, i);
            else
                FillSide(S_Expansion.x, S_Expansion.y, i);
        }
    }

    private int CalculateExpansionRate()
    {
        // <= 5 .  >= 6 is not possible
        if (listExpension.Count > 3)
            return 1;
        if (listExpension.Count > 1)
            return 2;
        if (listExpension.Count >= 0)
            return 3;
        return 4;
    }
    private void EmptySide(int x, int y, int edge)
    {
        cells[x, y].edgeStates[edge] = EdgeState.empty;
        gridManager.EmptyOtherEdge(x, y, edge);

        AddToExpensionList(x, y, edge);
    }

    private void FillSide(int x, int y, int edge)
    {
        cells[x, y].edgeStates[edge] = EdgeState.filled;
        gridManager.FillOtherEdge(x, y, edge);
    }
    private void AddToExpensionList(int x, int y, int expensionedge)
    {
        Vector2Int nextCell = gridManager.GetCellPosFromEdge(x, y, expensionedge);

        if (nextCell.x < 0) 
            return;

        if (cells[nextCell.x, nextCell.y].isExpanded)
            return;

        cells[nextCell.x, nextCell.y].isExpanded = true;
        int previousEdge = gridManager.CalculateWhichEdgeFromCell(nextCell.x, nextCell.y, x, y);

        S_ExpansionEdge s_ExpansionEdge = new S_ExpansionEdge(nextCell.x, nextCell.y, previousEdge);
        listExpension.Add(s_ExpansionEdge);
    }
    private Vector2Int GetCenter()
    {
        return new Vector2Int(cells.GetLength(0), cells.GetLength(1)) / 2;
    }
}
