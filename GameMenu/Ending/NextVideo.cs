using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class NextVideoScript : MonoBehaviour
{
    public VideoClip videoClip;
    public string MainMenuSceneName;
    private VideoPlayer videoPlayer;
    private NextVideoScript nextVideoScript;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        nextVideoScript = GetComponent<NextVideoScript>();

        videoPlayer.loopPointReached += NextVideo;
    }

    void NextVideo(VideoPlayer vp)
    {
        videoPlayer.clip = videoClip;
        videoPlayer.loopPointReached -= NextVideo;
        videoPlayer.Play();
        Debug.Log("Next Video");
        videoPlayer.loopPointReached += BackToMainMenu;
    }

    void BackToMainMenu(VideoPlayer vp)
    {
        SceneManager.LoadScene(MainMenuSceneName);
        videoPlayer.loopPointReached -= BackToMainMenu;
    }
}
