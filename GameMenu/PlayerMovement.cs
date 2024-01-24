using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEditor;
using UnityEngine.Video;

public class PlayerMovement : MonoBehaviour
{
    [Header("Animation")]
    private Animator animation;
    public string idle = "None";
    public string WalkAnimation;
    public string SprintAnimation;
    private string JumpAnimation;

    [Header("Game System")]
    public float walkspeed = 0.5f;
    public float sprintspeed = 1f;
    public float JumpForce = 10f;
    private bool isGrounded;
    private bool gameIsPause = false;

    [Header("Input")]
    public LayerMask groundLayer;
    public Transform feetPosition;
    public float groundCheckCircle;
    private Rigidbody2D rb;
    private float input = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPause)
            {
                Resume();
                return;
            }
            else
            {
                Pause();
            }
        }

        if (!gameIsPause)
        {
            Movement();
            Jump();
        }
    }

    public void Resume()
    {
        gameIsPause = false;
    }
    public void Pause()
    {
        gameIsPause = true;
    }

    void Movement()
    {
        string press = "Press a key";
        string right = PlayerPrefs.GetString("SaveFirstText", "Default Text");
        string left = PlayerPrefs.GetString("SaveSecondText", "Default Text");
        string sprint = PlayerPrefs.GetString("SaveThithText", "Default Text");

        float horizontalInput = 0f;

        if (string.Equals(sprint, press) || string.Equals(left, press) || string.Equals(right, press))
        {
            return;
        }
        else
        {
            foreach (char s in sprint)
            {
                KeyCode sm = (KeyCode)Enum.Parse(typeof(KeyCode), sprint);
                KeyCode Backward = (KeyCode)Enum.Parse(typeof(KeyCode), left);
                KeyCode Forward = (KeyCode)Enum.Parse(typeof(KeyCode), right);

                float speed = Input.GetKey(sm) ? sprintspeed : walkspeed;
                Vector2 movement = new Vector2(horizontalInput, 0f);
                transform.Translate(movement * speed * Time.deltaTime);

                if (Input.GetKey(sm))
                {
                    if (Input.GetKey(sm))
                    {
                        foreach (char f in left)
                        {
                            foreach (char r in right)
                            {
                                if (Input.GetKey(Backward))
                                {
                                    GetComponent<SpriteRenderer>().flipX = true;
                                    horizontalInput = -1f;
                                    // Debug.Log(Backward);
                                    animation.Play(SprintAnimation);
                                }
                                else if (Input.GetKey(Forward))
                                {
                                    if (Time.timeScale == 1f)
                                    {
                                        GetComponent<SpriteRenderer>().flipX = false;
                                    }
                                    horizontalInput = 1f;
                                    // Debug.Log(Forward);
                                    animation.Play(SprintAnimation);
                                }
                                else
                                {
                                    animation.Play(idle);
                                }
                            }
                        }
                    }
                }
                else
                {
                    foreach (char f in left)
                    {
                        foreach (char r in right)
                        {
                            if (Input.GetKey(Forward))
                            {
                                GetComponent<SpriteRenderer>().flipX = false;
                                horizontalInput = 1f;
                                // Debug.Log(Forward);
                                animation.Play(WalkAnimation);
                            }
                            else if (Input.GetKey(Backward))
                            {
                                GetComponent<SpriteRenderer>().flipX = true;
                                horizontalInput = -1f;
                                // Debug.Log(Backward);
                                animation.Play(WalkAnimation);
                            }
                            else
                            {
                                animation.Play(idle);
                            }
                        }
                    }
                }
            }
        }
    }

    void Jump()
    {
        string press = "Press a key";
        string jump = PlayerPrefs.GetString("SaveForthText", "Default Text");

        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);

        if (string.Equals(jump, press))
        {
            return;
        }
        else
        {
            foreach (char c in jump)
            {
                KeyCode keyCode = (KeyCode)Enum.Parse(typeof(KeyCode), jump);

                if (Input.GetKey(keyCode) && isGrounded)
                {
                    rb.velocity = Vector2.up * JumpForce;
                    animation.Play(JumpAnimation);
                }
            }
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(input * walkspeed, rb.velocity.y);
    }
}