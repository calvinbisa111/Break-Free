using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoorToLevel2 : MonoBehaviour
{
    public string levelToLoad = "Level2"; // Nama scene Level 2
    private bool hasKey; // Status memiliki kunci

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ubah tag sesuai dengan tag pemain
        {
            if (hasKey) // Cek apakah pemain memiliki kunci
            {
                Debug.Log("Pemain tidak memiliki kunci untuk membuka pintu.");
            }
            else
            {
                SceneManager.LoadScene(levelToLoad);
            }
        }
    }

    public void SetHasKey(bool value)
    {
        hasKey = value;
    }
}