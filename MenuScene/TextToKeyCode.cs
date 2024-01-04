using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.CompilerServices;
using UnityEditor;

public class TextToKeyCode : MonoBehaviour
{
    public TextMeshProUGUI left;
    public TextMeshProUGUI right;
    public TextMeshProUGUI jump;
    public TextMeshProUGUI interact;
    public TextMeshProUGUI sprint;
    public float walkspeed = 1f;
    public float sprintspeed = 1.5f;
    public Rigidbody2D playerRb;
    public float input;
    public SpriteRenderer spriteRenderer;
    public float JumpForce = 5f;

    public LayerMask groundLayer;
    private bool isGrounded;
    public Transform feetPosition;
    public float groundCheckCircle;


    void Update()
    {

        string leftmove = left.text;
        string rightmove = right.text;
        string jumpmove = jump.text;
        string interactive = interact.text;
        string sprintmove = sprint.text;
        string press = "Press a key";
        
        string KeyBinds = leftmove + rightmove + jumpmove + interactive + sprintmove;

        float horizontalInput = 0f;

        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);

        if (string.Equals(KeyBinds, press))
        {
            return;
        }
        else
        {
            foreach (char c in sprintmove)
            {
                KeyCode keyCode = (KeyCode)Enum.Parse(typeof(KeyCode), sprintmove);
                float speed = Input.GetKey(keyCode) ? sprintspeed : walkspeed;
                Vector2 movement = new Vector2(horizontalInput, 0f);
                transform.Translate(movement * speed * Time.deltaTime);

                foreach (char l in leftmove)
                {
                    KeyCode Forward = (KeyCode)Enum.Parse(typeof(KeyCode), leftmove);

                    if (Input.GetKey(Forward))
                    {
                        spriteRenderer.flipX = true;
                        horizontalInput = -1f;
                        Debug.Log(Forward);
                    }
                }

                foreach (char r in rightmove)
                {
                    KeyCode Backward = (KeyCode)Enum.Parse(typeof(KeyCode), rightmove);

                    if (Input.GetKey(Backward))
                    {
                        spriteRenderer.flipX = true;
                        horizontalInput = -1f;
                        Debug.Log(Backward);
                    }
                }

                foreach (char j in jumpmove)
            {
                KeyCode Jump = (KeyCode)Enum.Parse(typeof(KeyCode), jumpmove);

                if (isGrounded && Input.GetKey(Jump))
                {
                    playerRb.velocity = Vector2.up * JumpForce;
                }
            }
            }
        }
    }

    void FixedUpdate()
    {
        playerRb.velocity = new Vector2(input * walkspeed, playerRb.velocity.y);
    }
}