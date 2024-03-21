
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDown : MonoBehaviour
{
    public SpriteRenderer secondObject;
    private SpriteRenderer spriteRenderer;
    public Animator animator;
    private BoxCollider2D boxCollider2D;
    public bool animatorIsComplete = false;

    public Collider2D secondCollider;
    private Collider2D collider2D;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        collider2D = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Puzzle")
        {
            animator.Play("Elevator");
            AnimatorComplete();
        }
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     secondObject = collision.gameObject.GetComponent<SpriteRenderer>();
    //     if(secondObject != null)
    //     {
    //         animator.Play("Elevator");
    //         Debug.Log("Playing " + animator.name + " Animation");
    //         Debug.Log("First SpriteRenderer is hitting Second SpriteRenderer.");
    //         Debug.Log("Collision Details: " + collision.ToString());
    //     }
    //     boxCollider2D.enabled = false;
    //     AnimatorComplete();
    // }

    void AnimatorComplete()
    {
        animatorIsComplete = true;
    }
}
