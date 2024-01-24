using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneLoader : MonoBehaviour
{
    public static bool GameIsPause = false;
    public string sceneToActivate;
    // public AudioSource audioSource;

    public void QuitGame() 
    {
        Application.Quit();
        Debug.Log("QuitGame!");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }   

    public async void SwitchScene()
    {
        // audioSource.Play();
        // while (audioSource.isPlaying)
        // {
        //     await Task.Yield();
        // }
        SceneManager.LoadScene(sceneToActivate);
    }

    public void ResetScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
