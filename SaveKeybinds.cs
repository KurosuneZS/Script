using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SaveKeybinds : MonoBehaviour
{
    public TextMeshProUGUI Forward;
    public TextMeshProUGUI Backward;
    public TextMeshProUGUI Sprint;
    public TextMeshProUGUI Jump;
    public TextMeshProUGUI Interact;

    public void SaveKeybindsToNextSecene()
    {
        PlayerPrefs.SetString("SaveFirstText", Forward.text);
        PlayerPrefs.SetString("SaveSecondText", Backward.text);
        PlayerPrefs.SetString("SaveThithText", Sprint.text);
        PlayerPrefs.SetString("SaveForthText", Jump.text);
        PlayerPrefs.SetString("SaveFifthText", Interact.text);
        PlayerPrefs.Save();
    }
}
