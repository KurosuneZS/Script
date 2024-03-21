using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellingToFloor : MonoBehaviour
{
    private Animator animator;
    private Collider2D collider2D;

    void Start()
    {
        animator = GetComponent<Animator>();
        collider2D = GetComponent<Collider2D>();
    }

    public void Receive(string message)
    {
        StartCoroutine(WaitAnimation());
    }

    IEnumerator WaitAnimation()
    {
        animator.Play("CellingToFloor");
        while(!animator.GetCurrentAnimatorStateInfo(0).IsName("CellingToFloor") || animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
        {
            yield return null;
        }

        collider2D.enabled = true;
    }
}
