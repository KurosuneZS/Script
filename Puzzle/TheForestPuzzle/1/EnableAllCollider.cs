using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAllCollider : MonoBehaviour
{
    private Collider2D collider2D;
    private Animator animator;
    public string animation;

    void Start()
    {
        collider2D = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    public void ReceiveTheString(string message)
    {
        if (message == "Reset")
        {
            collider2D.enabled = true;
            animator.Play(animation);
            Debug.Log(message);
        }
    }
}
