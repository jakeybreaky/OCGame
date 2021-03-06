using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //Makes the camera follow the player while staying within the boundry set in the inspector.

    public Transform target;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;

    void Start()
    {
        transform.position = GetClampedCameraPosition();
    }

    void FixedUpdate()
    {
        if(transform.position != target.position)
        {
            transform.position = Vector3.Lerp(transform.position, GetClampedCameraPosition(), smoothing);
        }
    }

    private Vector3 GetClampedCameraPosition()
    {
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

        targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

        return targetPosition;
    }
}
