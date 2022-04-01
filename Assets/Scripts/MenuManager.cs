using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public string UserName;
    public string HighScoreUserName;
    public int HighScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string HighScoreUserName;
        public int HighScore;   
    }

    public void SaveHighScore()
    {
        Debug.Log("SaveHighScore: " + HighScoreUserName);
        Debug.Log("SaveHighScore: " + HighScore);

        SaveData data = new SaveData();
        data.HighScoreUserName = HighScoreUserName;
        data.HighScore = HighScore;

        string json = JsonUtility.ToJson(data);
  
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScoreUserName = data.HighScoreUserName;
            HighScore = data.HighScore;
        }
        Debug.Log("Path: " + Application.persistentDataPath);
        Debug.Log("LoadHighScore: " + HighScoreUserName);
        Debug.Log("LoadHighScore: " + HighScore);
    }

}
