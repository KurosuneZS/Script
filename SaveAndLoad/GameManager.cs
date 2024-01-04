using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [System.Serializable]
    public class GameData
    {
        public int playerScore;
    }

    private GameData currentGameData;

    public void SaveGame()
    {
        currentGameData = new GameData();
        string jsonData = JsonUtility.ToJson(currentGameData);
        PlayerPrefs.SetString("SaveGameData", jsonData);
        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        string jsonData = PlayerPrefs.GetString("SaveGameData", "");
        if (!string.IsNullOrEmpty(jsonData))
        {
            currentGameData = JsonUtility.FromJson<GameData>(jsonData);
        }
        else{
            Debug.LogWarning("No Saved Game Data Found");
        }
    }
}
