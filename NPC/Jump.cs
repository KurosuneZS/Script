using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpForce = 10f;
    public float delay = 1f;
    private bool canJump = true;

    public void JumpCheck(string message)
    {
        StartCoroutine(JumpWithDelay());
    }

    private IEnumerator JumpWithDelay()
    {
        canJump = false;
        yield return new WaitForSeconds(delay);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * jumpForce;

        yield return new WaitForSeconds(0.5f);

        canJump = true;
    }
}
