using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject highlight;
    private Collider2D collider2D;
    private Animator animator;
    public bool Open = false;
    private bool playerIn = false;

    void Start()
    {
        collider2D = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(playerIn == true) Interact();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            highlight.SetActive(true);
            playerIn = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            highlight.SetActive(false);
            playerIn = false;
        }
    }

    void Interact()
    {
        string Interactive = PlayerPrefs.GetString("SaveFifthText", "Default Text");
        KeyCode keyCode = (KeyCode)Enum.Parse(typeof(KeyCode), Interactive);
        if(Input.GetKeyDown(keyCode))
        {
            animator.Play("Vanishing");
            collider2D.enabled = false;
            Open = true;
        }
    }
}
