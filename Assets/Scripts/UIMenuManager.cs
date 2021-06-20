using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIMenuManager : MonoBehaviour
{
    [SerializeField] Text highScoreText;
    [SerializeField] InputField currentPlayerNameInputField;

    private void Start()
    {
        DataManager.Instance.LoadHighScore();
        highScoreText.text = "Top Murderer: " + DataManager.Instance.topPlayerName + ", " +
            DataManager.Instance.highScore + " Murders";
    }

    public string GetCurrentPlayerName()
    {
        return DataManager.Instance.currentPlayerName;
    }

    public void SetCurrentPlayerName()
    {
        DataManager.Instance.currentPlayerName = currentPlayerNameInputField.text;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
