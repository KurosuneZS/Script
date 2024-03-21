using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public KillPlayer killPlayer;

    public void PosPlayer()
    {
        killPlayer.PlayerPos("Position");
    }
}
