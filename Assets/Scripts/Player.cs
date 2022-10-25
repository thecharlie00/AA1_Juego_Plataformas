using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Movimiento
    Rigidbody rb;
    [SerializeField]
    private float directionValue;
    public Camera camera;
    public float acceleration;
    public float timePassed;
    public float timeToMaxSpeed;
    public float speed;
    public float initSpeed;
    
    public float maxSpeed;
    public bool isMoving;
    public bool goingBackwards;
    public GameObject Target;
    #endregion
    #region Salto
    [SerializeField]
    private bool isGrounded;
    public float jumpForce;
    private Vector3 jump;
    #endregion

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0, 2.0f, 0);
    }
    private void Update()
    {
        if (InputManager._INPUT_MANAGER.GetSouthButtonPressed() && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        }



        if (InputManager._INPUT_MANAGER.leftAxisValue.y > 0)
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
        transform.rotation = camera.transform.rotation;
    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
    public float GetCurrentSpeed()
    {
        return this.speed;
    }


}