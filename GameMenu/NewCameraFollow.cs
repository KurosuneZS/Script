using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    public Vector3 offset;
     public Vector2 xLimits = new Vector2(-Mathf.Infinity, Mathf.Infinity);
    public Vector2 yLimits = new Vector2(-Mathf.Infinity, Mathf.Infinity);



    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position + offset;
            targetPosition.x = Mathf.Clamp(targetPosition.x, xLimits.x, xLimits.y);
            targetPosition.y = Mathf.Clamp(targetPosition.y, yLimits.x, yLimits.y);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
