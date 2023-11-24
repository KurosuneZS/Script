using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCodeToString : MonoBehaviour
{
    public Button targetButton; // Reference to the UI button
    public Text titleLabel; // Reference to the UI Text for the title
    public string defaultTitle = "Press a key..."; // Default title

    private bool isWaitingForKey = false;

    void Start()
    {
        if (targetButton != null)
        {
            targetButton.onClick.AddListener(StartKeyDetection);
        }

        // Set the default title
        if (titleLabel != null)
        {
            titleLabel.text = defaultTitle;
        }
    }

    void Update()
    {
        if (isWaitingForKey && Input.anyKeyDown)
        {
            foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(keyCode))
                {
                    string keyName = Enum.GetName(typeof(KeyCode), keyCode);
                    Debug.Log("Pressed: " + keyName);

                    // Display the keyName on the button text
                    if (targetButton != null && targetButton.GetComponentInChildren<Text>() != null)
                    {
                        targetButton.GetComponentInChildren<Text>().text = "Key: " + keyName;
                    }

                    // Set the title text to the pressed key
                    if (titleLabel != null)
                    {
                        titleLabel.text = "Title: " + keyName;
                    }

                    isWaitingForKey = false;
                    break;
                }
            }
        }
    }

    void StartKeyDetection()
    {
        // Set a flag to indicate that we are waiting for a key press
        isWaitingForKey = true;

        // Clear the button text while waiting for input
        if (targetButton != null && targetButton.GetComponentInChildren<Text>() != null)
        {
            targetButton.GetComponentInChildren<Text>().text = defaultTitle;
        }

        // Reset the title text
        if (titleLabel != null)
        {
            titleLabel.text = defaultTitle;
        }
    }
}
