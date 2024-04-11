using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridFactory : MonoBehaviour
{
    [SerializeField] GridManager gridManager;
    [SerializeField] GridGeneration gridGeneration;
    [SerializeField] LineCalculator lineCalculator;
    [SerializeField] WallSpawner wallSpawner;

    [SerializeField] Transform GroundParent;
    [SerializeField] Transform WallParent;

    void Start()
    {
        //CreateNew();
    }

    public void RemakeMaze()
    {
        DeletePrevious();
        CreateNew();
    }
    void CreateNew()
    {
        gridManager.gridCells = new GridCell[gridGeneration.gridSize.x, gridGeneration.gridSize.y];
        gridGeneration.GenerateHexagonalGrid();
        lineCalculator.CalculateEdges();
        wallSpawner.GenerateAllTheWalls();
    }

    void DeletePrevious()
    {
        DestroyAllChildObjects(GroundParent);
        DestroyAllChildObjects(WallParent);
    }
    void DestroyAllChildObjects(Transform parent)
    {

        for (int i = parent.childCount - 1; i >= 0; i--)
        {
            // Get the child at index i
            Transform childTransform = parent.GetChild(i);

            // Destroy the child GameObject immediately
            DestroyImmediate(childTransform.gameObject);
        }


    }


}
