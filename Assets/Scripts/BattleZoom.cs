using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleZoom : MonoBehaviour
{
    public float speed = 10.0f;
    //public Transform cameraTarget;

    private Camera thisCamera;

    private void Start()
    {
        thisCamera = GetComponent<Camera>();
    }
    private void Update()
    {
        if (BattleReady.completeReady)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel") * speed;
            if (thisCamera.orthographicSize <= 5 && scroll < 0)
            {
                thisCamera.orthographicSize = 5;
            }
            else if (thisCamera.orthographicSize >= 8f && scroll > 0)
            {

                thisCamera.orthographicSize = 8f;
            }
            else
            {
                thisCamera.orthographicSize += scroll;
            }
        }
    }
}
