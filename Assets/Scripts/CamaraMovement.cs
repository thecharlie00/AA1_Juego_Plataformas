using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMovement : MonoBehaviour
{
    public GameObject referenceObject;
    public float oSpeed;
    private float directionValue;

   
    private void Update()
    {
        if(InputManager._INPUT_MANAGER.rightAxisValue.x < 0)
        {
            directionValue = 1f;
        }
        if(InputManager._INPUT_MANAGER.rightAxisValue.x > 0)
        {
            directionValue = -1f;
        }
        if (InputManager._INPUT_MANAGER.rightAxisValue.x == 0)
        {
            directionValue = 0;
        }
        transform.RotateAround(referenceObject.transform.position, new Vector3(0, 1, 0), oSpeed * Time.deltaTime*directionValue);
    }
}
