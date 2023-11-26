using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyCodeToString : MonoBehaviour
{
    public Button targetButton;
    public TextMeshProUGUI titleLabel;
    public string defaultTitle;

    private bool isWaitingForKey = false;

    void Start()
    {

        if (targetButton != null)
        {
            targetButton.onClick.AddListener(StartKeyDetection);
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

                    if (targetButton != null && targetButton.GetComponentInChildren<Text>() != null)
                    {
                        targetButton.GetComponentInChildren<Text>().text = "Key: " + keyName;
                    }

                    if (titleLabel != null)
                    {
                        titleLabel.text = keyName;
                    }

                    isWaitingForKey = false;
                    break;
                }
            }
        }
    }

    void StartKeyDetection()
    {
        isWaitingForKey = true;

        if (targetButton != null && targetButton.GetComponentInChildren<Text>() != null)
        {
            targetButton.GetComponentInChildren<Text>().text = defaultTitle;
        }

        if (titleLabel != null)
        {
            titleLabel.text = "Press a key";
        }
    }
}
