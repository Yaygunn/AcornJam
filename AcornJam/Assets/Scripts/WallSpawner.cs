using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    [SerializeField] private GridManager gridManager;

    [SerializeField] private WallPosData wallPosData;

    [SerializeField] private GameObject[] wallObj;

    [SerializeField] private Transform WallParent;
    
    public void GenerateAllTheWalls()
    {
        for(int i = 0; i < gridManager.gridCells.GetLength(0); i++)
        {
            for(int j = 0; j<gridManager.gridCells.GetLength(1); j++)
            {
                for(int k = 0; k < 6; k++)
                {
                    if (gridManager.gridCells[i, j].edgeStates[k] == EdgeState.filled)
                    {
                        CreateWall(i, j, k);
                        gridManager.EmptyOtherEdge(i, j, k);
                    }
                }
            }
        }
    }
    private void CreateWall(int x, int y, int edge)
    {
        Vector3 pos = gridManager.gridCells[x, y].transform.position;
        pos += wallPosData.GetEdgePos(edge).position;
        quaternion rot = wallPosData.GetEdgePos(edge).rotation;
        Instantiate(GetWall(), pos, rot, WallParent);
    }
    
    private GameObject GetWall()
    {
        int randomInt = UnityEngine.Random.Range(0, wallObj.Length);
        return wallObj[randomInt];
    }
}
