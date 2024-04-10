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

    public GridCell GetGridCellFromEdge(int x, int y, int Whichedge)
    {
        Vector2Int vPos = CalculateCellFromEdge(x, y, Whichedge);

        if (vPos.x < 0 || vPos.x > gridCells.GetLength(0) || vPos.y < 0 || vPos.y > gridCells.GetLength(1))
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
    
}
