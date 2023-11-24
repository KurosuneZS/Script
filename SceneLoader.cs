using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject pauseMenuUI;
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

    
}
