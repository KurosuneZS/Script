using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public GameObject gameObject;
    private SpriteRenderer spriteRenderer;
    private Collider2D collider2D;
    public bool start = false;

    void Start()
    {
        collider2D = GetComponent<Collider2D>();
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }
    }

    public void ReceiveString(string message)
    {
        if (message == "Start")
        {
            collider2D.enabled = true;
            Debug.Log(message);
            start = true;
        }
    }
}
