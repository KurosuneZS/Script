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

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        secondObject = collision.gameObject.GetComponent<SpriteRenderer>();
        if(secondObject != null)
        {
            animator.Play("Elevator");
            Debug.Log("Playing " + animator.name + " Animation");
            Debug.Log("First SpriteRenderer is hitting Second SpriteRenderer.");
            Debug.Log("Collision Details: " + collision.ToString());
        }
        boxCollider2D.enabled = false;
        AnimatorComplete();
    }

    void AnimatorComplete()
    {
        animatorIsComplete = true;
    }
}
