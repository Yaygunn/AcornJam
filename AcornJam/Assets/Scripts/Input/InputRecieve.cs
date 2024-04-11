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

    private Vector2 moveDirection;

    private Vector2 lookDirection;
    private void Update()
    {
        if (MoveF != null)
            MoveF(moveDirection);
        if(LookF != null)
            LookF(lookDirection);
    }
    private void OnMove(InputValue movementValue)
    {
        moveDirection = movementValue.Get<Vector2>();
    }

    private void OnLook(InputValue movementValue)
    {
        
         lookDirection = movementValue.Get<Vector2>();
    }
    
}
