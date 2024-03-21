using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouDead : MonoBehaviour
{
    public GameObject gameOver;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameOver.SetActive(true);
            Destroy(collision.gameObject);
        }
    }
}
