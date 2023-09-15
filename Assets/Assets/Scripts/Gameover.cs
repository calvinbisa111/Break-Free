using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    
    public string mainMenuSceneName = "Mainmenu"; // Nama scene menu utama

    public void OnRestartLevelButtonClick()
    {
        GameManager.instance.RestartCurrentLevel();
    }

    public void OnMainMenuButtonClick()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
