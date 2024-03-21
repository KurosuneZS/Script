using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheDarkInract : MonoBehaviour
{
    public GameObject highlight;
    public Animator RootAnimator;
    private bool playerIn = false;
    private Collider2D collider2D;
    private Animator animator;

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
        if (Input.GetKeyDown(keyCode))
        {
            animator.Play("Vanishing");
            collider2D.enabled = false;
            RootAnimator.Play("RootActivate");
        }
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
