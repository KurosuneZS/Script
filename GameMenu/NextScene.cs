using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScene : MonoBehaviour
{
    public string NextSceneName;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
}
