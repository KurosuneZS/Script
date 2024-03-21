using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject highlight;
    public Elevator elevator;
    private Animator animator;
    private Collider2D collider2D;
    private bool playerIn = false;

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
            collider2D.enabled = false;
            StartCoroutine(WaitAnimation());
        }
    }

    public void Sender()
    {
        elevator.Receive("");
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

    IEnumerator WaitAnimation()
    {
        animator.Play("PullLever");
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("PullLever"))
        {
            yield return null;
        }
        
        collider2D.enabled = true;
        Sender();
    }
}
