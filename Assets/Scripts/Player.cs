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
    public float jumpCount;
    public float forwardSpeed;
    private Vector3 jump;
    #endregion
    #region Animaciones
    Animator animator;
    #endregion
    #region Agacharse
    [SerializeField]
    private bool isCrouching;
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
        if (InputManager._INPUT_MANAGER.GetSouthButtonPressed() && !isGrounded && jumpCount <= 2)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            jumpCount++;
        }

        if (InputManager._INPUT_MANAGER.isCrouching == 0)
        {

            isCrouching = false;

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
            if (InputManager._INPUT_MANAGER.leftAxisValue.y < 0)
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
            if (!isMoving && speed > 0)
            {

                speed -= Time.deltaTime * 10;
                if (directionValue == 1)
                {
                    directionValue = 1;
                }


                if (directionValue == -1)
                {
                    directionValue = -1;
                }
                if (speed <= 0)
                {
                    speed = 0;
                    timePassed = 0;
                }


            }

            Vector3 newPosition = transform.position + (transform.forward * (directionValue * speed * Time.fixedDeltaTime));
            rb.MovePosition(newPosition);
            transform.rotation = camera.transform.rotation;
        }
        if (InputManager._INPUT_MANAGER.isCrouching == 1)
        {
            isCrouching = true;
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
            if (InputManager._INPUT_MANAGER.leftAxisValue.y < 0)
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
            if (!isMoving && speed > 0)
            {

                speed -= Time.deltaTime * 10;
                if (directionValue == 1)
                {
                    directionValue = 1;
                }


                if (directionValue == -1)
                {
                    directionValue = -1;
                }
                if (speed <= 0)
                {
                    speed = 0;
                    timePassed = 0;
                }


            }

            Vector3 newPosition = transform.position + (transform.forward * (directionValue * speed/2 * Time.fixedDeltaTime));
            rb.MovePosition(newPosition);
            transform.rotation = camera.transform.rotation;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            jumpCount = 0;
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
    public float GetCurrentJump()
    {
        return this.transform.position.y;
    }
    public float GetCrouch()
    {
        return InputManager._INPUT_MANAGER.isCrouching;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        WallJump(hit);
    }
    void WallJump(ControllerColliderHit hitSent)
    {
        if(!isGrounded && hitSent.normal.y < 0.1f)
        {
            if ((InputManager._INPUT_MANAGER.GetSouthButtonPressed())){
                transform.forward = hitSent.normal;
                transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            }
        }
    }
}