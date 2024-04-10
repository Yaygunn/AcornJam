using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGeneration : MonoBehaviour
{
    public float edgeLength; // Length of each hexagon edge
    public Vector2Int gridSize; // Number of rows and columns in the grid
    public GameObject gridCellPrefab; // Prefab for the hexagonal cell

    private void Start()
    {
        GenerateHexagonalGrid();
    }

    private void GenerateHexagonalGrid()
    {
        for (int row = 0; row < gridSize.y; row++)
        {
            for (int col = 0; col < gridSize.x; col++)
            {
                Vector3 position = CalculateHexagonPosition(row, col);
                Instantiate(gridCellPrefab, position, Quaternion.identity);
            }
        }
    }

    private Vector3 CalculateHexagonPosition(int row, int col)
    {
        float xOffset = row * edgeLength;
        float yOffset = col * 0.75f * edgeLength;

        if (col % 2 == 1) // Offset every other row
            xOffset += 0.5f * edgeLength;

        return new Vector3(xOffset, 0f, yOffset);
    }
}
