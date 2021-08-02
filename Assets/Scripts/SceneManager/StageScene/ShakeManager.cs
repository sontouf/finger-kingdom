using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeManager : MonoBehaviour
{
    public Camera mainCamera;
    private Vector3 cameraPos;
    private Vector3 cameraOriginalPos;

    public float shakeRange = 0.025f; 
    public float duration = 0.025f;

    private void Start()
    {
        cameraOriginalPos = mainCamera.transform.position;
    }
    public void Shake()
    {
        cameraPos = mainCamera.transform.position;
        InvokeRepeating("StartShake", 0f, 0.005f);
        Invoke("StopShake", duration);
    }

    void StartShake()
    {
        float cameraPosX = Random.value * shakeRange * 2 - shakeRange;
        float cameraPosY = Random.value * shakeRange * 2 - shakeRange;
        Vector3 cameraPos = mainCamera.transform.position;
        cameraPos.x += cameraPosX;
        cameraPos.y += cameraPosY;
        mainCamera.transform.position = cameraPos;
    }
    void StopShake()
    {
        CancelInvoke("StartShake");
        mainCamera.transform.position = cameraOriginalPos;
    }
}
