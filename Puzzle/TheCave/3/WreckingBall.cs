using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingBall : MonoBehaviour
{
    private Animator animator;
    public CellingToFloor cellingToFloor;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Receive(string message)
    {
        animator.Play("Rock");
        Debug.Log(message);
    }

    public void Sender()
    {
        cellingToFloor.Receive("Start");
    }
}
