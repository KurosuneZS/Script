using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public OpenDoor openDoor;
    private Animator animator;
    private Collider2D collider2D;

    void Start()
    {
        animator = GetComponent<Animator>();
        collider2D = GetComponent<Collider2D>();
    }

    void Update()
    {
        if(openDoor.Open == true)
        {
            animator.Play("Open");
            collider2D.enabled = false;
        }
    }
}