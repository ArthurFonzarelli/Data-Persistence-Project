using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string topPlayerName;
    public int highScore;

    public string currentPlayerName = "";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.playerName = topPlayerName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "savedscoredata.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "savedscoredata.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            topPlayerName = data.playerName;
            highScore = data.highScore;
        }
        else
        {
            topPlayerName = "None";
            highScore = 0;
        }
    }
}

public class SaveData
{
    public string playerName;
    public int highScore;
}
