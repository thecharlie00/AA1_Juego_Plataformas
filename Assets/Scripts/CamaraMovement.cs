using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMovement : MonoBehaviour
{
    Camera camera;
    Rigidbody rb;
    private float directionValue;
    private float lastValue;
    float tiltAroundz;
    float tiltAngle = 180.0f;
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
        }if(InputManager._INPUT_MANAGER.rightAxisValue.x != 0)
        {
            lastValue = InputManager._INPUT_MANAGER.rightAxisValue.x;
        }
        
        Debug.Log(lastValue);
        if(InputManager._INPUT_MANAGER.rightAxisValue.x == 0)
        {
            InputManager._INPUT_MANAGER.rightAxisValue.x = lastValue;
        }
        tiltAroundz = InputManager._INPUT_MANAGER.rightAxisValue.x * tiltAngle;
       
       

        //Debug.Log(InputManager._INPUT_MANAGER.rightAxisValue.x);
        Quaternion target = Quaternion.Euler(0, tiltAroundz, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * cameraMovementSpeed);
    }
}
