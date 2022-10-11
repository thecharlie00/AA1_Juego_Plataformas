using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMovement : MonoBehaviour
{
    Camera camera;
    Rigidbody rb;
    private float directionValue;
    float tiltAngle = 60.0f;
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
        float tiltAroundz = InputManager._INPUT_MANAGER.rightAxisValue.x * tiltAngle;
        Quaternion target = Quaternion.Euler(0, tiltAroundz,0 );

        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * cameraMovementSpeed);

        //Vector3 newPosition = transform.position + (transform.right * (directionValue * cameraMovementSpeed * Time.fixedDeltaTime));
        //rb.MovePosition(newPosition);


    }
}
