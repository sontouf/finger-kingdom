using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class UserEggManager : EggManager,IDragHandler, IEndDragHandler
{
    private Vector2 force = new Vector2(0, 0);
    public Vector2 mousePos;
    public Camera mainCamera;
    EggManager eggManager;



    protected override void Start()
    {
        base.Start();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        eggManager = GetComponent<EggManager>();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
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