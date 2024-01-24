using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TheDarkManage : MonoBehaviour
{
    private int Dark1 = 1, Dark2 = 2, Dark3 = 3, Dark4 = 4, Dark5 = 5, Dark6 = 6, Dark7 = 7, Dark8 = 8, Dark9 = 9, Dark10 = 10;

    [Header("RootAnimation")]
    public Animator animator;
    public string animation;

    [Header("Input")]
    public GameObject[] theDarks;
    private int[] expectedDarkValues = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    private int receivedCount = 0;
    private string StringToSend = "Reset";

    void OnEnable()
    {
        PuzzleTheDark[] senderScripts = FindObjectsOfType<PuzzleTheDark>();

        foreach (PuzzleTheDark senderScript in senderScripts)
        {
            senderScript.onSendIntValue.AddListener(value => ReceiveIntValue(value, senderScript));
        }
    }

    void OnDisable()
    {
        PuzzleTheDark[] senderScripts = FindObjectsOfType<PuzzleTheDark>();

        foreach (PuzzleTheDark senderScript in senderScripts)
        {
            senderScript.onSendIntValue.RemoveListener(value => ReceiveIntValue(value, senderScript));
        }
    }

    void ReceiveIntValue(int receivedValue, PuzzleTheDark sender)
    {
        Debug.Log("Received Integer Value from " + sender.name + ": " + receivedValue);

        receivedCount++;

        if (receivedCount <= expectedDarkValues.Length)
        {
            if (receivedValue != expectedDarkValues[receivedCount - 1])
            {
                Sender(StringToSend);
                Log();
                // EnableAllColliders();
                receivedCount = 0;
            }
        }

        if (receivedCount == expectedDarkValues.Length)
        {
            animator.Play(animation);
        }
    }
    void Log()
    {
        Debug.Log("Return");
    }

    // void EnableAllColliders()
    // {
    //     foreach (var dark in theDarks)
    //     {
    //         dark.GetComponent<Collider2D>().enabled = true;
    //         dark.GetComponent<Animator>().Play("Idle");
    //     }
    // }

    void Sender(string message)
    {
        PuzzleTheDark[] receivers = FindObjectsOfType<PuzzleTheDark>();
        foreach(PuzzleTheDark receiver in receivers)
        {
            gameObject.SetActive(true);
            receiver.ReceiveTheString(message);
        }
    }
}