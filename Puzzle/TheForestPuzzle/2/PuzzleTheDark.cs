using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleTheDark : MonoBehaviour
{
    private Animator animator;
    public string PlayAnimation;
    public GameObject gameObject;
    private Collider2D collider2D;

    [Header("Value")]
    public IntEvent onSendIntValue = new IntEvent();
    public int intValueToSend;
    private bool playerIn = false;

    void Start()
    {
        collider2D = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if(playerIn == true)
        {
            interact();
        }
    }

    void interact()
    {
            string Interactive = PlayerPrefs.GetString("SaveFifthText", "Default Text");
            KeyCode keyCode = (KeyCode)Enum.Parse(typeof(KeyCode), Interactive);
            if (Input.GetKeyDown(keyCode))
            {
                ScriptSender();
            }
    }

    public void ReceiveTheString(string message)
    {
        if (message == "Reset")
        {
            collider2D.enabled = true;
            animator.Play("Idle");
            Debug.Log("Reset");
        }
        else if (message == "Continue")
        {
            collider2D.enabled = false;
            animator.Play(PlayAnimation);
            Debug.Log("Continue");
        }
    }

    void ScriptSender()
    {
        onSendIntValue.Invoke(intValueToSend);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(true);
            playerIn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            playerIn = false;
        }
    }

}

[System.Serializable]
public class IntEvent : UnityEvent<int> { }