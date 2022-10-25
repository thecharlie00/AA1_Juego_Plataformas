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

        /*Vector3 finalPosition = Vector3.Lerp(transform.position, target.transform.position -
        transform.forward * targetDistance, cameraLerp * Time.deltaTime);*/
        Vector3 finalPosition = target.transform.position -
        transform.forward * targetDistance;
        RaycastHit hit;
        if (Physics.Linecast(target.transform.position, finalPosition, out hit))
        {
            finalPosition = hit.point;
            Debug.Log("hit");
        }
        transform.position = finalPosition;


    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(target.transform.position, 0.5f);
    }*/
}
