using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private void Update()
    {
        if (InputManager._INPUT_MANAGER.GetSouthButtonPressed())
        {
            Debug.Log("Boton Pressed");
        }
        
    }
}