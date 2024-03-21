using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoSelect : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;
    public GameObject choiceObject;
    public GameObject EndingVideoObject;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayVideo(VideoClip videoClip)
    {
        StartCoroutine(WaitAnimationForPlayVideo(videoClip));
    }

    public void PlayAudio(AudioClip audioClip)
    {
        StartCoroutine(WaitAnimationForPlayAudio(audioClip));
    }

    IEnumerator WaitAnimationForPlayAudio(AudioClip audioClip)
    {
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("BeforePlayVideo") || animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
        {
            yield return null;
        }

        audioSource.clip = audioClip;

        audioSource.Play();
    }

    IEnumerator WaitAnimationForPlayVideo(VideoClip videoClip)
    {
        animator.Play("BeforePlayVideo");
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("BeforePlayVideo") || animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
        {
            yield return null;
        }

        choiceObject.SetActive(false);
        EndingVideoObject.SetActive(true);

        videoPlayer.clip = videoClip;
        videoPlayer.Play();
    }
}
