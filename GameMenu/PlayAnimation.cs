using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    public Animator Animate;
    public string AnimateGoLeft;
    public string AnimateGoRight;
    public TextMeshProUGUI left;
    public TextMeshProUGUI right;
    
    void Update()
    {
        string Left = left.text;
        string Right = right.text;
        string press = "Press a Key";

        if(string.Equals(Left, press) || string.Equals(Right, press))
        {
            return;
        }
        else
        {
            foreach(char L in Left)
            {
                Animate.Play(AnimateGoLeft);
            }
            foreach(char R in Right)
            {
                Animate.Play(AnimateGoRight);
            }
        }
    }
}
