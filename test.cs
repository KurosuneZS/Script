using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class test : MonoBehaviour
{
    public TextMeshPro InteractKey;
    public Camera camera;
    private float cameraSize;
    private float num = 0.1f;

    void Start()
    {
        cameraSize = camera.orthographicSize;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            string interact = InteractKey.text;
            KeyCode keyCode = (KeyCode)Enum.Parse(typeof(KeyCode), interact);
            if (Input.GetKey(keyCode))
            {
                while (camera.orthographicSize > 4)
                {
                    camera.orthographicSize -= num;
                }
            }
        }
    }
}
