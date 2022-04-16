using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class UserEggManager : EggManager, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    const string audioAttackImpactPath = "Audio/AudioAttackImpact";
    const string directioTargetPrefabPath = "Prefabs/DirectionTargetPrefab";
    const string collisionEffectPath = "Prefabs/CollisionEffect";

    public AudioClip audioSourceClip;
    public AudioSource audioSource;
    public GameObject shakeManager;
    public GameObject collisionEffect;
    public Vector3 force = new Vector2(0, 0);
    public Vector3 mousePos;
    public Quaternion direction;
    public Camera mainCamera;
    GameObject directionTargetPrefab;
    GameObject directionTarget;
    protected int firstMove;
    public bool state_Freeze = false;
    public bool checkfreeze = false;
    public bool state_Curse = false;
    public bool checkCurse = false;

    public GameObject state_freeze;
    GameObject state_curse;
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
        collisionEffect = Resources.Load<GameObject>(collisionEffectPath);

    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (GameManager.isUserTurn && BattleReady.completeReady)
        {
            mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }
        direction = CalculateDirection(mousePos);
        if (state_Freeze && !checkfreeze)
        {
            state_freeze = Instantiate(state_freezePrefab, transform.position, Quaternion.identity);
            checkfreeze = !checkfreeze;
        }
        if (state_Curse && !checkCurse)
        {
            state_curse = Instantiate(state_cursePrefab, transform.position, Quaternion.identity);
            checkCurse = !checkCurse;
        }
        if(state_curse != null)
        {
            state_curse.transform.position = transform.position;
        }
        if (state_freeze != null)
        {
            state_freeze.transform.position = transform.position;
        }
        if (!GameManager.isUserTurn && state_Freeze)
        {
            state_Freeze = !state_Freeze;
            Destroy(state_freeze);
            checkfreeze = !checkfreeze;
        }
/*        if (GameManager.isUserTurn && state_Freeze && UserEggManager.userEggManagers.Count == 1)
        {
            state_Freeze = !state_Freeze;
            Destroy(state_freeze);
            checkfreeze = !checkfreeze;
            GameManager.isUserTurn = !GameManager.isUserTurn;
        }*/


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
        if (GameManager.isUserTurn && !state_Freeze && BattleReady.completeReady)
        {
            directionTarget = Instantiate(directionTargetPrefab, transform.position, direction);
        }
    }


    public void OnDrag(PointerEventData data)
    {
        Vector2 pos = transform.position - mousePos;
        float num = Vector2.Distance(transform.position, mousePos);
        if (directionTarget != null)
        {
            if (num > 15)
            {
                directionTarget.transform.position = pos.normalized * 15 + (Vector2)transform.position;
            }
            else
            {
                directionTarget.transform.position = pos.normalized * num + (Vector2)transform.position;
            }
            if (GameManager.isUserTurn && !state_Freeze && BattleReady.completeReady)
            {
                force = pos.normalized * num * 5;
            }
        }
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        Destroy(directionTarget);
        if (GameManager.isUserTurn && !state_Freeze && BattleReady.completeReady)
        {
            if (firstMove == 1)
            {
                firstMove--;
            }
            MoveEgg(force);
            GameManager.isUserTurn = !GameManager.isUserTurn;
        }
    }
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (BattleReady.completeReady)
        {
            if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss"))
            {
                Instantiate(collisionEffect, collision.contacts[0].point, collision.transform.rotation);
                shakeManager.GetComponent<ShakeManager>().Shake();
                audioSource.Play();
            }
            if (collision.gameObject.CompareTag("Player") && state_Curse)
            {
                curHp -= 5;
            }
        }
    }

    public override void DestroyEgg()
    {
        if (state_freeze != null)
        {
            Destroy(state_freeze);
        }
        if (state_curse != null)
        {
            Destroy(state_curse);
        }
        userEggManagers.Remove(this);
        base.DestroyEgg();
    }


/*    public int GetHp()
    {
        return maxHp;
    }
    public int GetDamage()
    {
        return damage;
    }

    public int GetSpeed()
    {
        return speed;
    }
    public float GetMass()
    {
        return rigidbody2D.mass;
    }
    public int GetHeal()
    {
        return heal;
    }
    public int GetCost()
    {
        return cost;
    }
*/
}