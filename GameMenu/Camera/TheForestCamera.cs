using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheForestCamera : MonoBehaviour
{
    [Header("Input")]
    public Transform targetCharacter;
    public float smoothTime = 0f;
    public Vector3 offset;
    public TheDarksPuzzle3 theDarksPuzzle3;
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

            if (targetPosition.x >= -142f && targetPosition.x <= 142f)
            {
                yMaxLimit = -1.3f;
                yMinLimit = -1.3f;
                if (targetPosition.x >= -89f && targetPosition.x <= -62f) yMaxLimit = 3f;
                if (targetPosition.x >= -84) yMinLimit = 3f;
                if (targetPosition.x >= -62f) yMaxLimit = 4f;
                if (targetPosition.x >= -50f) yMinLimit = 4f;
                if (targetPosition.x >= -30f) yMinLimit = -5.4f;
                if (targetPosition.x >= -14f) yMaxLimit = -5.4f;
                if (targetPosition.x >= 7f) yMaxLimit = -2.6f;
                if (targetPosition.x >= 28f) yMaxLimit = -5.4f;
                if (targetPosition.x >= 47f) yMinLimit = -5.7f;
                if (targetPosition.x >= 53f) yMinLimit = -5.4f;
                if (targetPosition.x >= 61.2f) yMinLimit = -3.7f;
                if (theDarksPuzzle3.gameObject == true && targetPosition.x >= 70f) yMaxLimit = -2f;
                if (targetPosition.x >= 107f) yMaxLimit = -1f;
                if (targetPosition.x >= 123f) yMaxLimit = -0f;
                if (targetPosition.x >= 135f) yMinLimit = -2.4f;
                if (targetPosition.x >= 142f) yMaxLimit = -2.4f;
            }
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}