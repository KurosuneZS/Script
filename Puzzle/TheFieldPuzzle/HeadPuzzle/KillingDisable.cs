using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingDisable : MonoBehaviour
{
    public KillPlayer killPlayer;

    public void Disable()
    {
        killPlayer.disable("disable");
    }
}
