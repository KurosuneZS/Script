using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDown : MonoBehaviour
{
    public GameObject gameObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Rock is on");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Rock isn't on");
        }
    }

}
