using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingElevator : MonoBehaviour
{
    private bool playerIn = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(playerIn == true)
        {
            animator.Play("Elevator");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerIn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerIn = false;
        }
    }
}
