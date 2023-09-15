using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricSfx : MonoBehaviour
{
    public Transform player; // Referensi transform pemain atau sumber suara
    public AudioSource ElectricAudioSource; // Komponen AudioSource
    public float maxVolume = 1.0f; // Volume maksimal suara
    public float minDistance = 1.0f; // Jarak minimal suara terdengar
    public float maxDistance = 10.0f; // Jarak maksimal suara terdengar

    private void Update()
    {
        // Menghitung jarak antara pemain dan obstacle
        float distance = Vector3.Distance(player.position, transform.position);

        // Menghitung volume berdasarkan jarak
        float volume = Mathf.Lerp(maxVolume, 0, (distance - minDistance) / (maxDistance - minDistance));
        volume = Mathf.Clamp01(volume); // Memastikan nilai volume antara 0 dan 1

        // Mengatur volume pada AudioSource
        ElectricAudioSource.volume = volume;

        // Play sound only when player is close
        if (distance <= maxDistance)
        {
            ElectricAudioSource.Play();
        }
        else
        {
            ElectricAudioSource.Stop();
        }
    }
}
