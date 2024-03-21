using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPause = false;
    public GameObject pauseMenuUI;
    public Animator animation;
    private bool animationIsPlaying = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                Resume();
                return;
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        animation.Play("Resume");
        Time.timeScale = 1f;
        GameIsPause = false;
        Debug.Log("Resumed");
    }

    public void Pause()
    {
        
        animation.Play("Pause");
        if (!animationIsPlaying)
        {
            StartCoroutine(WaitForAnimarion());
        }
    }

    private IEnumerator WaitForAnimarion()
    {
        animationIsPlaying = true;
        yield return null;

        while (animation.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            yield return null;
        }

        Time.timeScale = 0f;
        GameIsPause = true;
        Debug.Log("Paused");

        animationIsPlaying = false;
    }
}
