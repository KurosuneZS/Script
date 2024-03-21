using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAudioVolum : MonoBehaviour
{
    public AudioSource[] audioSources;

    void Start()
    {
        if (PlayerPrefs.HasKey("AudioVolume"))
        {
            float savedValue = PlayerPrefs.GetFloat("AudioVolume");
            foreach (var audioSource in audioSources)
            {
                audioSource.volume = savedValue;
            }
        }
    }
}
