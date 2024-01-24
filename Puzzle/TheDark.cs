using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TheDark : MonoBehaviour
{
    private Animator animator;
    public string animation;
    public GameObject gameObject;
    private Collider2D collider2D;

    void Start()
    {
        collider2D = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            string Interactive = PlayerPrefs.GetString("SaveFifthText", "Default Text");
            KeyCode keyCode = (KeyCode)Enum.Parse(typeof(KeyCode), Interactive);
            if (Input.GetKey(keyCode))
            {
                collider2D.enabled = false;
                animator.Play(animation);
                // Debug.Log("Interact");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(true);
            // Debug.Log("Player is in");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            // Debug.Log("Player is out");
        }
    }
}
