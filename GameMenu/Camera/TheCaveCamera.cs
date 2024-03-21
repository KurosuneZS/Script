using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheCaveCamera : MonoBehaviour
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
                yMinLimit = -4.9f;
                yMaxLimit = -4.9f;
                if (targetPosition.x >= -93) yMaxLimit = -2f;
                if (targetPosition.x >= -77) yMinLimit = -2f; yMaxLimit = 1.1f;
                if (targetPosition.x >= -70) yMinLimit = 1.1f; yMaxLimit = 1.2f;
                if (targetPosition.x >= -60) yMinLimit = 1.2f; yMaxLimit = 1.3f;
                if (targetPosition.x >= -53) yMinLimit = 1.3f; yMaxLimit = 2f;
                if (targetPosition.x >= -48.5) yMinLimit = 2f; yMaxLimit = 2.4f;
                if (targetPosition.x >= -46.5) yMinLimit = 2.4f;
                if (targetPosition.x >= -39.5) yMaxLimit = 7.6f;
                if (targetPosition.x >= -35) yMinLimit = 7.6f; smoothTime = 0.2f;
                if (targetCharacter.position.x >= -35 && targetCharacter.position.x <= -26.9)
                {
                    xMinLimit = -30f;
                    xMaxLimit = -30f;
                }
                else
                {
                    xMinLimit = -142f;
                    xMaxLimit = 142f;
                }
                if (targetCharacter.position.x >= -26.9) yMinLimit = 1.47f;
                if (targetPosition.x >= -19) yMaxLimit = 1.47f;
                if (targetPosition.x >= 25.4) yMinLimit = -2f;
                if (targetPosition.x >= 46.7) yMaxLimit = -2f;
                if (targetCharacter.position.x >= 56.8 && targetCharacter.position.x <= 75)
                {
                    smoothTime = 0.15f;
                    yMinLimit = 0f;
                    xMinLimit = 64.4f;
                    xMaxLimit = 68f;
                }
                else
                {
                    smoothTime = 0.1f;
                    xMinLimit = -142f;
                    xMaxLimit = 142f;
                }
                if (targetPosition.x >= 75) yMinLimit = -2.2f;
                if(targetPosition.x >= 80) yMinLimit = -3.6f;
                if (targetPosition.x >= 82) yMaxLimit = -3.6f;
                if(targetPosition.x >= 93) yMinLimit = -5.5f;
                if(targetPosition.x >= 130) yMaxLimit = -2f;
                if(targetPosition.x >= 140) yMinLimit = -2f;
            }
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
