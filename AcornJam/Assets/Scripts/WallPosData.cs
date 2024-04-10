using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPosData : MonoBehaviour
{
    [SerializeField] private Transform[] WallPos;

    public Transform GetEdgePos(int edge)
    {
        return WallPos[edge];
    }
}
