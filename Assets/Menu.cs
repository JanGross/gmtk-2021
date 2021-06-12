using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string gameSceneName;

    public void PlayButtonPressed()
    {
        if (!string.IsNullOrEmpty(gameSceneName))
            SceneManager.LoadScene(gameSceneName, LoadSceneMode.Single);
    }

    public void ExitButtonPressed()
    {
        Application.Quit();
    }
}
