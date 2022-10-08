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

    public float maxSpeed;
    public bool isMoving;
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


            speed = Mathf.Clamp(initSpeed, maxSpeed, 0);
            if (speed == maxSpeed)
            {
                speed = maxSpeed;
            }


            Vector3 newPosition = transform.position + (transform.forward * (speed * Time.fixedDeltaTime));
            rb.MovePosition(newPosition);

        }
        if(InputManager._INPUT_MANAGER.leftAxisValue.y <= 0 )
        {
           
            
                
                isMoving = false;
            
        }
        if(InputManager._INPUT_MANAGER.leftAxisValue.y < 0)
        {
            isMoving = true;
            timePassed += Time.deltaTime;
            speed = acceleration * timePassed / Time.deltaTime;


            speed = Mathf.Clamp(initSpeed, maxSpeed, 0);
            if (speed == maxSpeed)
            {
                speed = maxSpeed;
            }


            Vector3 newPosition = transform.position + (transform.forward * (-1*speed * Time.fixedDeltaTime));
            rb.MovePosition(newPosition);
        }
        if (!isMoving && speed >0)
        {
            
                speed-=Time.deltaTime*2;
                Vector3 newPosition = transform.position + (transform.forward * (speed * Time.fixedDeltaTime));
                rb.MovePosition(newPosition);
            if(speed <= 0)
            {
                speed = 0;
            }
            
            
        }
       
    }
}