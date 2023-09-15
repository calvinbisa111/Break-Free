using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricObstacle : MonoBehaviour
{
    public float onDuration = 3f; // Durasi listrik nyala
    public float offDuration = 3f; // Durasi listrik mati
    private bool isOn = false; // Status listrik saat ini
    [SerializeField] private AudioSource electricObstacleSoundEffect;
    public Transform player; // Referensi transform pemain atau sumber suara
    public float maxVolume = 1.0f; // Volume maksimal suara
    public float minDistance = 1.0f; // Jarak minimal suara terdengar
    public float maxDistance = 10.0f;

    private Collider2D obstacleCollider;

    private void Start()
    {
        obstacleCollider = GetComponent<Collider2D>();
        electricObstacleSoundEffect = GetComponent<AudioSource>();


        // Panggil fungsi untuk mengatur listrik berulang
        InvokeRepeating("ToggleElectricity", 0f, onDuration + offDuration);
    }

    private void ToggleElectricity()
    {
        isOn = !isOn;
        electricObstacleSoundEffect.Play();
        // Aktifkan atau nonaktifkan komponen Collider2D
        obstacleCollider.enabled = isOn;

        // Aktifkan atau nonaktifkan GameObject ini (mengubah visibilitas)
        gameObject.SetActive(isOn);

        float distance = Vector3.Distance(player.position, transform.position);

        // Menghitung volume berdasarkan jarak
        float volume = Mathf.Lerp(maxVolume, 0, (distance - minDistance) / (maxDistance - minDistance));
        volume = Mathf.Clamp01(volume);
        electricObstacleSoundEffect.volume = volume;

    }
}