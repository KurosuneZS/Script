using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueEnd : MonoBehaviour
{
    public SpriteRenderer player;

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        if (mousePosition.x <= Screen.width / 2)
        {
            player.flipX = true;
        }
        else
        {
            player.flipX = false;
        }
    }

}
