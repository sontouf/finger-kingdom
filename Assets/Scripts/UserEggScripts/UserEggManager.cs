using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class UserEggManager : EggManager, IBeginDragHandler,IDragHandler, IEndDragHandler
{
    const string audioAttackImpactPath = "Audio/AudioAttackImpact";
    const string directioTargetPrefabPath = "Prefabs/DirectionTargetPrefab";

    public AudioClip audioSourceClip;
    public AudioSource audioSource;
    public GameObject shakeManager;
    public Vector3 force = new Vector2(0, 0);
    public Vector3 mousePos;
    public Quaternion direction;
    public Camera mainCamera;
    GameObject directionTargetPrefab;
    GameObject directionTarget;



    protected override void Start()
    {
        base.Start();
        this.gameObject.layer = 11;
        shakeManager = GameObject.Find("Master");
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = 0.3f;
        audioSourceClip = Resources.Load(audioAttackImpactPath) as AudioClip;
        directionTargetPrefab = Resources.Load(directioTargetPrefabPath) as GameObject;
        audioSource.clip = audioSourceClip;
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (GameManager.isUserTurn)
        {
            mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }
        direction = CalculateDirection(mousePos);
    }

    public Quaternion CalculateDirection(Vector3 pos)
    {
        Vector2 len = pos - transform.position;
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        direction = Quaternion.Euler(0, 0, 180 + z);
        return direction;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        directionTarget = Instantiate(directionTargetPrefab, transform.position, direction);
    }


    public void OnDrag(PointerEventData data)
    {
        Vector3 pos = transform.position - mousePos;
        float num = pos.x / pos.normalized.x; // num 배
        directionTarget.transform.position = pos.normalized * (num+2) + transform.position;
        if (GameManager.isUserTurn)
        {
            force = pos.normalized * num * 3;
        }
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        Destroy(directionTarget);
        if (GameManager.isUserTurn)
        {
            MoveEgg(force);
            GameManager.isUserTurn = !GameManager.isUserTurn;
        }
    }
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            shakeManager.GetComponent<ShakeManager>().Shake();
            audioSource.Play();
        }
    }

}