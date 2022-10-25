using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    [SerializeField]
    private float targetDistance;

    [SerializeField]
    private float cameraLerp; //12f

    public float rotationX;
    public float rotationY;

    private void LateUpdate()
    {
        //rotationX -= InputManager._INPUT_MANAGER.rightAxisValue.y;
        rotationY += InputManager._INPUT_MANAGER.rightAxisValue.x;

        

        transform.eulerAngles = new Vector3(0, rotationY, 0);

        transform.position = Vector3.Lerp(transform.position, target.transform.position - transform.forward * targetDistance, cameraLerp * Time.deltaTime);

    }
}
