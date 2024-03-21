using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheDarknessStop : MonoBehaviour
{
    public GameObject theDarkness, Animation;
    public AudioClip audioClip;
    public AudioSource audioSource;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(theDarkness);
            Destroy(Animation);
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
}