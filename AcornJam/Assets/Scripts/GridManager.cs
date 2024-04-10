using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance {  get; private set; }

    public GridCell[,] gridCells;

    private EdgeState[] edgeStates = new EdgeState[6];// 0 = right bottom edge, 1 = left bottom edge, clockwise
    private void Awake()
    {
        Instance = this;
    }

    public void CreateEdge(int x, int y, int edge)
    {
        gridCells[x, y].edgeStates[edge] = EdgeState.filled;
        FillOtherEdge(x, y, edge);
    }

    public void FillOtherEdge(int x, int y, int edge)
    {
        Vector2Int otherCell = (GetCellPosFromEdge(x, y, edge));
        if (otherCell.x < 0)
            return ;

        int WhichEdge = CalculateWhichEdgeFromCell(otherCell.x, otherCell.y, x, y);
        if (WhichEdge == -1)
            return;
        gridCells[otherCell.x, otherCell.y].edgeStates[WhichEdge] = EdgeState.filled;

    }
    public void EmptyOtherEdge(int x, int y, int edge)
    {
        Vector2Int otherCell = (GetCellPosFromEdge(x, y, edge));
        if (otherCell.x < 0)
            return;

        int WhichEdge = CalculateWhichEdgeFromCell(otherCell.x, otherCell.y, x, y);
        if (WhichEdge == -1)
            return;
        gridCells[otherCell.x, otherCell.y].edgeStates[WhichEdge] = EdgeState.empty;

    }
    public int CalculateWhichEdgeFromCell(int x1, int y1, int x2, int y2)
    {
        for(int i = 0; i < 6; i++)
        {
            if(GetGridCellFromEdge(x1, y1, i) == gridCells[x2, y2])
            {
                return i;
            }
        }
        return -1;
    }

    private Vector2Int GetCellPosFromEdge(int x, int y, int Whichedge)
    {
        Vector2Int vPos = CalculateCellFromEdge(x, y, Whichedge);
        if(isValidCell(vPos))
            return vPos;
        return new Vector2Int(-1, -1);
    }
    public GridCell GetGridCellFromEdge(int x, int y, int Whichedge)
    {
        Vector2Int vPos = CalculateCellFromEdge(x, y, Whichedge);

        if (!isValidCell(x,y))
            return null;

        return gridCells[vPos.x, vPos.y];
    }
    private Vector2Int CalculateCellFromEdge(int x, int y, int Whichedge)
    {
        if(Whichedge == 2)
            return new Vector2Int(x -1, y);
        if (Whichedge == 5)
            return new Vector2Int(x + 1, y);

        short xSign = 0;
        if (y % 2 == 1)
        {
            xSign = 1;
        }

        if(Whichedge == 0)
            return new Vector2Int(x +xSign, y - 1);

        if (Whichedge == 1)
            return new Vector2Int(x + xSign -1, y - 1);

        if (Whichedge == 4)
            return new Vector2Int(x + xSign, y + 1);

        if (Whichedge == 3)
            return new Vector2Int(x + xSign - 1, y + 1);

        return new Vector2Int(x, y);
    }

    public bool isValidCell(int x, int y)
    {
        return isValidCell(new Vector2Int(x, y));
    }

    public bool isValidCell(Vector2Int vPos)
    {
        if (vPos.x < 0 || vPos.x > gridCells.GetLength(0) || vPos.y < 0 || vPos.y > gridCells.GetLength(1))
            return false;
        return true;
    }

}
