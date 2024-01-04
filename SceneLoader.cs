using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static bool GameIsPause = false;
    public string sceneToActivate;

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

    public void SwitchScene()
    {
        SceneManager.LoadScene(sceneToActivate);
    }
}
