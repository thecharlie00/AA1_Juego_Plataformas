using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private Player_Inputs playerInputs;
    public static InputManager _INPUT_MANAGER;
    private float timeSinceJumppPressed = 0f;
    public Vector2 leftAxisValue = Vector2.zero;

    private void Awake()
    {
        if (_INPUT_MANAGER != null && _INPUT_MANAGER != this)
        {
            Destroy(_INPUT_MANAGER);

        }
        else
        {
            playerInputs = new Player_Inputs();
            playerInputs.Player.Enable();
            playerInputs.Player.Jump.performed += JumpButtonPressed;
            playerInputs.Player.Move.performed += LeftAxisUpdate;
            _INPUT_MANAGER = this;
            DontDestroyOnLoad(this);
        }

    }
    private void Update()
    {
        timeSinceJumppPressed += Time.deltaTime;
        InputSystem.Update();
    }
    private void JumpButtonPressed(InputAction.CallbackContext context)
    {

        timeSinceJumppPressed = 0f;
    }
    private void LeftAxisUpdate(InputAction.CallbackContext context)
    {
        leftAxisValue = context.ReadValue<Vector2>();
        Debug.Log("Magnitude" + leftAxisValue.magnitude);
        Debug.Log("Magnitude" + leftAxisValue.normalized);
    }
    public bool GetSouthButtonPressed()
    {
        return this.timeSinceJumppPressed == 0f;
    }
    public float TimeSinceSouthButtonPressed()
    {
        return this.timeSinceJumppPressed;
    }
}