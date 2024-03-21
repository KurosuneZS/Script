using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowFloor : MonoBehaviour
{
    public GameObject inGame;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.transform.SetParent(inGame.transform);
        }
    }
}
