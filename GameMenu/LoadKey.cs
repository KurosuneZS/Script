using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class LoadKey : MonoBehaviour
{
    private TextMeshPro interact;
    
    void Start()
    {
        interact = GetComponent<TextMeshPro>();
        string Interact = PlayerPrefs.GetString("SaveFifthText", "Default Text");

        interact.text = Interact;
    }
}
