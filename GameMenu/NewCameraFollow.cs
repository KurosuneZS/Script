using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraFollow : MonoBehaviour
{
    [Header("Input")]
    public Transform targetCharacter;
    public float smoothTime = 0f;
    public Vector3 offset;
    [Header("X = Left, Y = right")]
    public Vector2 xLimits = new Vector2(-Mathf.Infinity, Mathf.Infinity);
    [Header("X = Down, Y = Up")]
    public Vector2 yLimits = new Vector2(-Mathf.Infinity, Mathf.Infinity);

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (targetCharacter != null)
        {
            Vector3 targetPosition = targetCharacter.position + offset;
            targetPosition.x = Mathf.Clamp(targetPosition.x, xLimits.x, xLimits.y);
            targetPosition.y = Mathf.Clamp(targetPosition.y, yLimits.x, yLimits.y);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
