using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputRecieve : MonoBehaviour
{
    public Action<Vector2> MoveF;

    public Action<Vector2> LookF;
    private void OnMove(InputValue movementValue)
    {
        if (MoveF != null)
            MoveF(movementValue.Get<Vector2>());
    }

    private void OnLook(InputValue movementValue)
    {
        
         LookF?.Invoke(movementValue.Get<Vector2>());
    }
    
}
