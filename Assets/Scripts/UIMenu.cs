using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TMP_InputField playerNameField;

    private void Start() 
    {
        highScoreText.SetText("High Score : "+ScoreManager.Instance.playerName+" : "+ScoreManager.Instance.hightScore);
    }

    public void StartNew()
    {
        ScoreManager.Instance.currentPlayer = playerNameField.text;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit();
    #endif
    }
}
