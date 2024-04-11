using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] CharacterController cc;
    [SerializeField] InputRecieve inputRecieve;
    [SerializeField] Transform cam;
    [SerializeField] float Speed;
    [SerializeField] float LookSpeed;
    public float CurrentSpeed { get; private set; }
    public Vector2 inputDirection { get; private set; }
    [SerializeField] float CameraHeightDif;

    Vector2[] lookArr = new Vector2[3] { new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0) };


    void Start()
    {
        inputRecieve.MoveF = Movement;
        inputRecieve.LookF = GetLook;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Movement(Vector2 direction)
    {
        inputDirection = direction;
        Vector3 moveDir = transform.forward * direction.y + transform.right * direction.x;  
        CurrentSpeed = moveDir.magnitude;
        cc.Move(moveDir * Speed * Time.deltaTime);
    }

    void GetLook(Vector2 direction)
    {
        GetNewLookDir(direction);
        Rotate(CalculateDirection());
    }
    void Rotate(Vector2 direction)
    {
        transform.Rotate(Vector3.up * direction.x * LookSpeed  );
        cam.transform.Rotate(Vector3.left * direction.y * LookSpeed);
    }

    Vector2 CalculateDirection()
    {
        Vector2 v = new Vector2();
        v += lookArr[0] * 0.33f;
        v += lookArr[1] * 0.33f;
        v += lookArr[2] * 0.33f;
        return v;
    }

    void GetNewLookDir(Vector2 dir)
    {
        lookArr[0] = lookArr[1];
        lookArr[1] = lookArr[2];
        lookArr[2] = dir;
    }

    
}
