using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheDarksPuzzle3 : MonoBehaviour
{
    public GameObject highlight;
    private Collider2D collider2D;
    private bool playerIn = false;
    private Animator animator;
    public bool objectIsActivate = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        collider2D = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (playerIn == true)
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
            animator.Play("Vanishing");
            objectIsActivate = true;
            collider2D.enabled = false;
            Invoke("ObjectNotActivate", 4f);
            Invoke("PlayIdle", 7f);
        }
    }

    void ObjectNotActivate()
    {
        objectIsActivate = false;
    }
    void PlayIdle()
    {
        animator.Play("Idle");
        collider2D.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            highlight.SetActive(true);
            playerIn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            highlight.SetActive(false);
            playerIn = false;
        }
    }
}
