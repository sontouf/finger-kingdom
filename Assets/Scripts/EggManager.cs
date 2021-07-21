using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



public class EggManager : MonoBehaviour
{
    // ===================== [ constant fields ] =========================
    const string circlePrefabPath = "Prefabs/CirclePrefab";

    // ====================== [ static eggManagers ] ==========================
    static private List<EggManager> eggManagers = new List<EggManager>();

    static public void CreateEgg<EggType>(Vector3 position, string tagName) where EggType : EggManager
    {
        // 객체 생성
        GameObject newEggObject =
            Instantiate(circlePrefab, position, Quaternion.identity);

        EggType newEggManager = newEggObject.AddComponent<EggType>();
        // 컴포넌트들 추가

        // static 리스트에 추가
        eggManagers.Add(newEggManager);
        newEggObject.tag = tagName;
    }



    static public void DestroyEgg(EggManager eggManager)
    {
        eggManagers.Remove(eggManager);
        Destroy(eggManager.gameObject);
    }

    // ===================== [ static private fields ] ===================
    [SerializeField]
    static private GameObject circlePrefab = Resources.Load(circlePrefabPath) as GameObject;

    // ====================== [ private fields ] ==========================
    public SpriteRenderer spriteRenderer;

    private Vector2 force = new Vector2(0, 0);
    private float speed = 50;
    private Vector2 mousePos;
 
    private bool holding = false;
    private float range;

    private float maxHp = 100;
    public float curHp;
 
    private HpBarController hpBarController;

    public float damage = 10;

    public Camera mainCamera;
 
    protected virtual void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        range = gameObject.GetComponent<CircleCollider2D>().radius;
        curHp = maxHp;
        hpBarController = gameObject.AddComponent<HpBarController>();
        hpBarController.Init(curHp, maxHp);

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    protected virtual void Update()
    {
        MoveEgg();
    }




    public void MoveEgg()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        if (transform.position.x > 6 || transform.position.x < -6 || transform.position.y > 4 || transform.position.y < -4)
        {
            DestroyEgg(this);
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && Vector2.Distance(mousePos, transform.position) <= range)
            {
                holding = true;
            }
            if (Input.GetMouseButton(0) && holding)
            {
                force = (Vector2)transform.position - mousePos;
            }
            if (Input.GetMouseButtonUp(0))
            {
                transform.GetComponent<Rigidbody2D>().AddForce(force * speed);
                force = new Vector2(0, 0);
                holding = false;
            }
      
        }
    }


    private void OnCollisionExit2D(Collision2D other)
    {
        GameObject otherObject = other.gameObject;
        EggManager otherEggManager = otherObject.GetComponent<EggManager>();

        if (otherObject.tag == "Enemy")
        {
            if (this.gameObject.tag == "Player")
            {
                otherEggManager.curHp -= damage;
            }
            otherObject.GetComponent<HpBarController>()
                        .SetHealth(otherEggManager.curHp, otherEggManager.maxHp);
            if (otherEggManager.curHp <= 0)
            {
                DestroyEgg(otherEggManager);
            }

        }
    }
}



