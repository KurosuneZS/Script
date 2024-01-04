using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadKeyBinds : MonoBehaviour
{
    public TextMeshProUGUI forward;
    public TextMeshProUGUI backward;
    public TextMeshProUGUI sprint;
    public TextMeshProUGUI jump;
    public TextMeshProUGUI interact;

    void Start()
    {
        string Forward = PlayerPrefs.GetString("SaveFirstText", "Default Text");
        string Backward = PlayerPrefs.GetString("SaveSecondText", "Default Text");
        string Sprint = PlayerPrefs.GetString("SaveThithText", "Default Text");
        string Jump = PlayerPrefs.GetString("SaveForthText", "Default Text");
        string Interact = PlayerPrefs.GetString("SaveFifthText", "Default Text");

        forward.text = Forward;
        backward.text = Backward;
        sprint.text = Sprint;
        jump.text = Jump;
        interact.text = Interact;
    }
}
