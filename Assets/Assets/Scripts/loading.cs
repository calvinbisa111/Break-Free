using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loading : MonoBehaviour
{
    public Transform loadingBar;

    [SerializeField]
    private float nilaiSekarang;
    [SerializeField]
    private float nilaiKecepatan;

    // Update is called once per frame
    void Update()
    {
        if (nilaiSekarang < 100)
        {
            nilaiSekarang += nilaiKecepatan * Time.deltaTime;
            Debug.Log((int)nilaiSekarang);

            if (Random.Range(0, 100) < 20) // 20% kemungkinan ngelag
            {
                float jeda = Random.Range(0.1f, 0.5f); // Durasi ngelag acak
                System.Threading.Thread.Sleep((int)(jeda * 1000));
            }
        }
        else
        {
            SceneManager.LoadSceneAsync("Mainmenu");
        }

        loadingBar.GetComponent<Image>().fillAmount = nilaiSekarang / 100;
    }
}
