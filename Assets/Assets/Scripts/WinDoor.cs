using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinDoor : MonoBehaviour
{
    public string levelToLoad = "Win"; // Nama scene Level 2


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ubah tag sesuai dengan tag pemain
            {
                SceneManager.LoadScene("Win");
            }
        
    }

    }

   