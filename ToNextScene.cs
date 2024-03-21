using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToNextScene : MonoBehaviour
{
    public string NextScene;

    public void ChangeScene()
    {
        SceneManager.LoadScene(NextScene);
    }
}
