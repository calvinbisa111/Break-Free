using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void RestartLevel()
    {
        string lastLevel = PlayerPrefs.GetString("LastLevel", "Level1"); // Default to Level1
        SceneManager.LoadScene(lastLevel);
    }
}
