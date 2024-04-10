using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance {  get; private set; }

    public GridCell[,] gridCells;

    private void Awake()
    {
        Instance = this;
    }
}
