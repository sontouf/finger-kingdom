using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;


public class PlayerEggMove : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector2 force = new Vector2(0, 0);
    public Vector2 mousePos;
    public Camera mainCamera;
    EggManager eggManager;

    private void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        eggManager = GetComponent<EggManager>();
    }

    private void Update()
    {
        if (GameManager.isUserTurn)
        {
            mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    public void OnDrag(PointerEventData data)
    {
        if (GameManager.isUserTurn)
        {
            force = (Vector2)transform.position - mousePos;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (GameManager.isUserTurn)
        {
            eggManager.MoveEgg(force);
            GameManager.isUserTurn = !GameManager.isUserTurn;
        }
    }

}
