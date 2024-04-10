using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EdgeState { notdefined, empty, filled}// filled = there is wall, empty = there is no wall
public class GridCell : MonoBehaviour
{
    public EdgeState[] edgeStates = new EdgeState[6];

    public bool isExpanded = false;
}
