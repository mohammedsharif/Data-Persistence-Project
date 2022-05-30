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
	//initialize the text and the input field
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TMP_InputField playerNameField;

	//Set the high score text field in the menu scene
    private void Start() 
    {
        highScoreText.SetText("High Score : "+ScoreManager.Instance.playerName+" : "+ScoreManager.Instance.highScore);
    }

	//Load the main scene when the start button is clicked and get the player name 
    public void StartNew()
    {
        ScoreManager.Instance.currentPlayer = playerNameField.text;
        SceneManager.LoadScene(1);
    }

	//quit the unity play mode or the application based on the platform
    public void QuitGame()
    {
    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit();
    #endif
    }
}
