using System;
using UnityEngine;

public class PlayerAudioMovement : MonoBehaviour
{
    public AudioClip[] audioClips;
    private AudioSource audioSource;
    private bool isPlaying;
    private Animator animator;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        string press = "Press a key";
        string right = PlayerPrefs.GetString("SaveFirstText", "Default Text");
        string left = PlayerPrefs.GetString("SaveSecondText", "Default Text");

        if (string.Equals(left, press) || string.Equals(right, press))
        {
            return;
        }
        else
        {
            KeyCode Backward = (KeyCode)Enum.Parse(typeof(KeyCode), left);
            KeyCode Forward = (KeyCode)Enum.Parse(typeof(KeyCode), right);

            if ((Input.GetKey(Forward) || Input.GetKey(Backward)) && !isPlaying)
            {
                StartCoroutine(PlayRandomClipAndWait());
            }
        }
    }

    private System.Collections.IEnumerator PlayRandomClipAndWait()
    {
        isPlaying = true;
        bool jump = animator.GetBool("Jump");

        if (audioClips.Length > 0 && !jump)
        {
            int randomIndex = UnityEngine.Random.Range(0, audioClips.Length);
            audioSource.clip = audioClips[randomIndex];
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);
        }
        else if (jump)
        {
            audioSource.Stop();
        }

        isPlaying = false;
    }
}
