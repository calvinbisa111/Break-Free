using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private string currentLevel; // Level saat ini

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCurrentLevel(string levelName)
    {
        currentLevel = levelName;
    }

    public void RestartCurrentLevel()
    {
        SceneManager.LoadScene(currentLevel);
    }
}