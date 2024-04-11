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

    [SerializeField] float MazeScaleUp;

    private void ScaleUpMaze()
    {
        GroundParent.localScale *= MazeScaleUp;
        WallParent.localScale *= MazeScaleUp;
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
        ScaleUpMaze();
    }

    void DeletePrevious()
    {
        DestroyAllChildObjects(GroundParent);
        DestroyAllChildObjects(WallParent);
        ResetScale();
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

    private void ResetScale()
    {
        GroundParent.localScale = new Vector3(1, 1, 1);
        WallParent.localScale = new Vector3(1, 1, 1);
    }


}
