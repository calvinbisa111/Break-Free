using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceBasedSound : MonoBehaviour
{
    public Transform player; // Referensi ke Transform pemain
    public AudioSource audioSource; // Referensi ke komponen AudioSource obstacle
    public float maxDistance = 10f; // Jarak maksimum untuk suara terdengar
    public float sfxVolume = 1f;

    private void Start()
    {
        // Inisialisasi volume suara saat awal permainan
        audioSource.volume = sfxVolume;
    }

    private void Update()
    {
        // Hitung jarak antara obstacle dan pemain
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Hitung persentase jarak terhadap jarak maksimum
        float distancePercentage = Mathf.Clamp01(distanceToPlayer / maxDistance);

        // Hitung volume suara berdasarkan persentase jarak
        float targetVolume = sfxVolume * (1f - distancePercentage); // semakin dekat, semakin keras

        // Atur volume suara obstacle
        audioSource.volume = targetVolume;
    }

    // Fungsi untuk mengatur volume suara dari luar
    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        audioSource.volume = sfxVolume;
    }
}
