using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheDarknessStart : MonoBehaviour
{
    public GameObject theDarkness;
    public AudioSource audioSource;
    public AudioClip audioClip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            theDarkness.SetActive(true);
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
}
