using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider slider;

    public void SetVolume()
    {
        float volume = slider.value;
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * -20);
    }
}
