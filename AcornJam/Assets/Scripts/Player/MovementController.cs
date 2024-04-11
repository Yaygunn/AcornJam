using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] CharacterController cc;
    [SerializeField] InputRecieve inputRecieve;
    [SerializeField] float Speed;
    
    void Start()
    {
        inputRecieve.MoveF = Movement;
        inputRecieve.LookF = Rotate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Movement(Vector2 direction)
    {
        cc.Move(new Vector3(direction.x, 0, direction.y) * Speed * Time.deltaTime);
    }
    void Rotate(Vector2 direction)
    {

    }
}
