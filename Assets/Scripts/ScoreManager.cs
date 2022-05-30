using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int hightScore;
    public string playerName;
    public int currentScore;
    public string currentPlayer;
    public bool IsRecordBreaked = false;

    private void Awake() 
    {
        if(Instance != null)
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
        public int highSore;
        public string playerName;
    }

    public void SaveHighScore()
    {
        if(IsRecordBreaked)
        {
            SaveData data = new SaveData();
            data.highSore = currentScore;
            data.playerName = currentPlayer;

            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            hightScore = data.highSore;
            playerName = data.playerName;
        }
    }
}
