using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveAudioSlider : MonoBehaviour
{
    public AudioSource audioSource;

    public void OnDisable()
    {
        if (audioSource != null)
        {
            PlayerPrefs.SetFloat("AudioVolume", audioSource.volume);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.LogWarning("Audio source is null.");
        }
    }
}
