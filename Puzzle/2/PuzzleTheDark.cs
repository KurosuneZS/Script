using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleTheDark : MonoBehaviour
{
    private Animator animator;
    public string animation;
    public GameObject gameObject;
    private Collider2D collider2D;

    [Header("Value")]
    public IntEvent onSendIntValue = new IntEvent();
    public int intValueToSend;

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
                ScriptSender();
                collider2D.enabled = false;
                animator.Play(animation);
                // Debug.Log("Interact");
            }
        }
    }

    // public void EnableColliders()
    // {
    //     collider2D.enabled = true;
    //     animator.Play("Idle");
    // }

    void ScriptSender()
    {
        onSendIntValue.Invoke(intValueToSend);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(true);
            // Debug.Log("Player is in");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            // Debug.Log("Player is out");
        }
    }

    public void ReceiveTheString(string message)
    {
        if (message == "Reset")
        {
            collider2D.enabled = true;
            animator.Play("Idle");
            Debug.Log(message);
        }
    }
}

[System.Serializable]
public class IntEvent : UnityEvent<int> { }
