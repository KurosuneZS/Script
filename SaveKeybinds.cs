using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SaveKeybinds : MonoBehaviour
{
    public TextMeshProUGUI firstText;
    public TextMeshProUGUI secondText;
    public TextMeshProUGUI thirthText;
    public TextMeshProUGUI forthText;
    public TextMeshProUGUI fifthText;

    public void SaveKeybindsToNextSecene()
    {
        PlayerPrefs.SetString("SaveFirstText", firstText.text);
        PlayerPrefs.SetString("SaveSecondText", secondText.text);
        PlayerPrefs.SetString("SaveThithText", thirthText.text);
        PlayerPrefs.SetString("SaveForthText", forthText.text);
        PlayerPrefs.SetString("SaveFifthText", fifthText.text);
    }
}
