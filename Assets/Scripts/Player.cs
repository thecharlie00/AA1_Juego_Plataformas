using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float acceleration;
    public float timePassed;
    public float timeToMaxSpeed;
    public float speed;
    public float initSpeed;
    [SerializeField]
    private float directionValue;

    public float maxSpeed;
    public bool isMoving;
    public bool goingBackwards;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (InputManager._INPUT_MANAGER.GetSouthButtonPressed())
        {
            Debug.Log("Boton Pressed");
        }
        if(InputManager._INPUT_MANAGER.leftAxisValue.y > 0)
        {
            isMoving = true;
            timePassed += Time.deltaTime;
            speed = acceleration * timePassed / Time.deltaTime;
            directionValue = 1;

            speed = Mathf.Clamp(initSpeed, maxSpeed, 0);
            if (speed == maxSpeed)
            {
                speed = maxSpeed;
            }
            
        }
        if(InputManager._INPUT_MANAGER.leftAxisValue.y < 0)
        {
            isMoving = true;
            directionValue = -1;
            timePassed += Time.deltaTime;
            speed = acceleration * timePassed / Time.deltaTime;
            speed = Mathf.Clamp(initSpeed, maxSpeed, 0);
            if (speed == maxSpeed)
            {
                speed = maxSpeed;
            }
           
        }
        if (InputManager._INPUT_MANAGER.leftAxisValue.y <= 0)
        {
            isMoving = false;
        }
        if (!isMoving && speed >0)
        {
            
                speed-=Time.deltaTime*10;
            if(directionValue == 1)
            {
                directionValue = 1;
            }
            

            if (directionValue == -1)
            {
                directionValue = -1;
            }
            if(speed <= 0)
            {
                speed = 0;
                timePassed = 0;
            }
            
            
        }
        Vector3 newPosition = transform.position + (transform.forward * (directionValue*speed * Time.fixedDeltaTime));
        rb.MovePosition(newPosition);
    }
}