using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggMoveController : MonoBehaviour
{
    public Camera mainCamera;
    public EggManager eggManager;

    private void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    private void Update()
    {
        eggManager.MoveEgg(mainCamera, transform, eggManager);
    }
}
