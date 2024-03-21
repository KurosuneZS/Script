using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheFieldCamera : MonoBehaviour
{
    [Header("Input")]
    public Transform targetCharacter;
    public float smoothTime = 0f;
    public Vector3 offset;
    [Header("XLimit")]
    public float xMinLimit;
    public float xMaxLimit;
    [Header("YLimit")]
    public float yMinLimit;
    public float yMaxLimit;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        SetCamera();
    }

    void SetCamera()
    {
        if (targetCharacter != null)
        {
            Vector3 targetPosition = targetCharacter.position + offset;
            targetPosition.x = Mathf.Clamp(targetPosition.x, xMinLimit, xMaxLimit);
            targetPosition.y = Mathf.Clamp(targetPosition.y, yMinLimit, yMaxLimit);

            if (targetPosition.x >= xMinLimit && targetPosition.x <= xMaxLimit)
            {
                yMinLimit = 1f;
                yMaxLimit = 1f;
                if (targetCharacter.position.x >= 49)
                {
                    yMaxLimit = -4.2f;
                    yMinLimit = -4.2f;
                    xMinLimit = 54.6f;
                }
                else
                {
                    yMinLimit = 1f;
                    yMaxLimit = 1f;
                    xMinLimit = -133f;
                }
            }
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}