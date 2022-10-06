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
    public float maxSpeed;
    public bool isMaxSpeed;
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
            if (!isMaxSpeed)
            {
                timePassed += Time.deltaTime;
                speed = acceleration * timePassed / Time.deltaTime;
            }
            if (speed == maxSpeed)
            {
                isMaxSpeed = true;
                speed = maxSpeed;
            }

            Vector3 newPosition = transform.position + (transform.forward * (speed * Time.fixedDeltaTime));
            rb.MovePosition(newPosition);
            
        }
       
    }
}