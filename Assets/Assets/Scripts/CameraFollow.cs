using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Transform karakter yang akan diikuti
    public Vector3 offset = new Vector3(0f, 0f, -10f); // Offset kamera dari karakter
    public float smoothSpeed = 0.125f; // Kecepatan pergerakan kamera

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
