using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 2f;
    public float stoppingDistance = 2f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        Movement();
        Flip();
    }

    void Flip()
    {
        if (player.transform.position.x > transform.position.x)
        {
            sr.flipX = true;
        }
        else if(player.transform.position.x < transform.position.x)
        {
            sr.flipX = false;
        }
    }

    void Movement()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer > stoppingDistance)
            {
                Vector2 targetPosition = new Vector2(player.position.x, rb.position.y);
                Vector2 newPosition = Vector2.MoveTowards(rb.position, targetPosition, moveSpeed * Time.deltaTime);
                rb.MovePosition(newPosition);

                if (newPosition.x > rb.position.x)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }
        }
    }
}