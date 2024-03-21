using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitforSec : MonoBehaviour
{
    public float waitForSeconds;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(PlayAnimationWithDelay());
    }

    IEnumerator PlayAnimationWithDelay()
    {
        yield return new WaitForSeconds(waitForSeconds);

        animator.Play("Activate");
    }
}
