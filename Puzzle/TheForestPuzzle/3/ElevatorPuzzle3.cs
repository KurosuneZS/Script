using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPuzzle3 : MonoBehaviour
{
    public TheDarksPuzzle3 theDarksPuzzle3;
    private Animator animator;
    public bool animatorIsPlay;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (theDarksPuzzle3.objectIsActivate == true)
        {
            animator.Play("ElevatorActivate");
            animatorIsPlay = true;
        }
        else if (theDarksPuzzle3.objectIsActivate == false)
        {
            animator.Play("ElevatorDeactivate");
            animatorIsPlay = false;
        }
    }
}