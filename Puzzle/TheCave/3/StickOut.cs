using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickOut : MonoBehaviour
{
    public Animator animator;
    public WreckingBall wreckingBall;
    private Collider2D collider2D;
    private bool playerIn = false;

    void Start()
    {
        collider2D = GetComponent<Collider2D>();
    }

    void Update()
    {
        if(playerIn == true)
        {
            Interact();
        }
    }

    void Interact()
    {
        string Interactive = PlayerPrefs.GetString("SaveFifthText", "Default Text");
        KeyCode keyCode = (KeyCode)Enum.Parse(typeof(KeyCode), Interactive);
        if(Input.GetKeyDown(keyCode))
        {
            animator.Play("Stick");
            Sender();
            Destroy(collider2D);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerIn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerIn = false;
        }
    }

    public void Sender()
    {
        wreckingBall.Receive("Start");
    }
}
