using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyCodeToString : MonoBehaviour
{
    public Button targetButton;
    public TextMeshProUGUI firstTextSelect;
    public TextMeshProUGUI secondTextSelect;
    public TextMeshProUGUI thirthTextSelect;
    public TextMeshProUGUI forthTextSelect;
    public TextMeshProUGUI fifthTextSelect;
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
                    string first = firstTextSelect.text;
                    string second = secondTextSelect.text;
                    string thirth = thirthTextSelect.text;
                    string forth = forthTextSelect.text;
                    string fifth = fifthTextSelect.text;
                    Debug.Log("Key: " + keyName);

                    if (targetButton != null && targetButton.GetComponentInChildren<Text>() != null)
                    {
                        targetButton.GetComponentInChildren<Text>().text = "Key: " + keyName;
                    }
                    
                    if (keyName == second)
                    {
                        firstTextSelect.text = keyName;
                        secondTextSelect.text = "Press a Key";
                    }
                    else if (keyName == thirth)
                    {
                        firstTextSelect.text = keyName;
                        thirthTextSelect.text = "Press a Key";
                    }
                    else if (keyName == forth)
                    {
                        firstTextSelect.text = keyName;
                        forthTextSelect.text = "Press a Key";
                    }
                    else if (keyName == fifth)
                    {
                        firstTextSelect.text = keyName;
                        fifthTextSelect.text = "Press a Key";
                    }
                    else if (firstTextSelect != null)
                    {
                        firstTextSelect.text = keyName;
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

        if (firstTextSelect != null)
        {
            firstTextSelect.text = "Press a Key";
        }
    }
}
