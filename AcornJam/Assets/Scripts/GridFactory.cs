using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridFactory : MonoBehaviour
{
    [SerializeField] GridManager gridManager;
    [SerializeField] GridGeneration gridGeneration;
    [SerializeField] LineCalculator lineCalculator;
    [SerializeField] WallSpawner wallSpawner;



    void Start()
    {
        CreateNew();
    }

    void CreateNew()
    {
        gridGeneration.GenerateHexagonalGrid();
        lineCalculator.CalculateEdges();
        wallSpawner.GenerateAllTheWalls();
    }

    
}
