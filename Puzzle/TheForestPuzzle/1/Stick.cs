using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    private string StringToSend = "Start";
    public Collider2D RockBase;
    public Rock rock;
    public GameObject gameObject;
    public Animator animator;
    public string animation;
    private bool playerIn;

    void Update()
    {
        if (playerIn == true)
        {
            interact();
        }
    }

    void interact()
    {
        string Interactive = PlayerPrefs.GetString("SaveFifthText", "Default Text");
        KeyCode keyCode = (KeyCode)Enum.Parse(typeof(KeyCode), Interactive);
        if (Input.GetKey(keyCode))
        {
            Sender();
            RockBase.enabled = false;
            animator.Play(animation);
        }
    }

    void Sender()
    {
        rock.ReceiveString(StringToSend);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(true);
            playerIn = true;
            // Debug.Log("Player is in");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            playerIn = false;
            // Debug.Log("Player is out");
        }
    }
}
