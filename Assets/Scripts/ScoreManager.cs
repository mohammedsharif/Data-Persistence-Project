using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int highScore;
    public string playerName;
    public int currentScore;
    public string currentPlayer;
    public bool IsRecordBreaked = false;

	//prevent the destruction of the instance between the scenes
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

	//define the format of data to be saved
    [System.Serializable]
    class SaveData 
    {
        public int highSore;
        public string playerName;
    }

	//write the player name and the highSore in a json file if the current score is better than the high score
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

	//get the player name and the high score from the save file
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highSore;
            playerName = data.playerName;
        }
    }
}
