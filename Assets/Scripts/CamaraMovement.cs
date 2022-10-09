using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMovement : MonoBehaviour
{
    Camera camera;
    Rigidbody rb;
    private float directionValue;
    [SerializeField]
    private float cameraMovementSpeed;
    private void Awake()
    {
        camera = GetComponent<Camera>();
        rb = GetComponent<Rigidbody>();
        
    }

    
    void Update()
    {
        if (InputManager._INPUT_MANAGER.rightAxisValue.x > 0)
        {
            directionValue = 1;
        }
        if(InputManager._INPUT_MANAGER.rightAxisValue.x < 0)
        {
            directionValue = -1;
        }
        Vector3 newPosition = transform.position + (transform.forward * (directionValue * cameraMovementSpeed * Time.fixedDeltaTime));
        rb.MovePosition(newPosition);


    }
}
