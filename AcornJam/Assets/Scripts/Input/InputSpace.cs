using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSpace : MonoBehaviour
{
    public Action SpaceF;
    private void OnFire()
    {
        SpaceF?.Invoke();
    }
}
