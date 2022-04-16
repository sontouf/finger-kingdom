using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class EggManager : MonoBehaviour//  IPointerEnterHandler
{
    // EggManager의 역할은 EggPrefab 객체의 모든 행동과 정보, 객체 생성과 소멸을 담당한다.
    // EggPrefab 객체에만 달려있는 component라고 생각하자.


    // ===================== [ constant fields ] =========================
    const string eggPrefabPath = "Prefabs/newEggPrefab"; // eggPrefab의 위치정보.
    //const string Chapter1BossPrefabPath = "Prefabs/Boss/Chapter1BossPrefab";
    const string state_freezePrefabPath = "Prefabs/States/State_FreezePrefab";
    const string state_cursePrefabPath = "Prefabs/States/State_CursePrefab";
    const string AfterimagePrefabPath = "Prefabs/AfterimagePrefab"; // AfterimagePrefab의 위치정보.

    // ====================== [ static eggManagers ] ==========================
    // static 변수로 선언되어 eggPrefab 객체들의 갯수를 관리한다.
    static public List<EggManager> eggManagers = new List<EggManager>();
    static public List<EnemyEggManager> enemyEggManagers = new List<EnemyEggManager>();
    static public List<UserEggManager> userEggManagers = new List<UserEggManager>();


    // ===================== [ static private fields ] ===================
    static private GameObject eggPrefab;


    // ====================== [ private fields ] ==========================
    // egg의 sprite 관련 변수
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidbody2D;
    // egg의 이동 관련 변수
    public int speed = 100;
    public int heal = 0;
    public int cost = 1;
    public Slider child;
    // egg의 Hp 관련 변수
    public int maxHp = 100;
    public int curHp = 100;
    public HpBarController hpBarController;
    public int damage = 10;
    public GameObject state_freezePrefab;
    public GameObject state_cursePrefab;
    // egg 그 외 기타 정보
    private GameObject parentObject;

    // protected virtual을 추가해줘서 상속.
    // Egg의 메소드 관련 초기화.



    static public void ClearAll()
    {
        eggManagers.Clear();
        enemyEggManagers.Clear();
        userEggManagers.Clear();
    }

    static public List<EggType> GetEggManagersByType<EggType>() where EggType : EggManager
    {
        List<EggType> newEggManagers = new List<EggType>();
        Type eggType = typeof(EggType);
        foreach (EggManager eggManager in eggManagers)
        {
            if (eggManager.GetType().IsSubclassOf(eggType))
            {
                newEggManagers.Add((EggType)eggManager);
            }
        }
        return newEggManagers;
    }

    // Egg를 초기화하고 생성한다.객체를 만든다.
    // 이때 type을 매개변수로 만들어줘서 상속을 받게 해준다. warrior, archer, goblin등으로 변신가능
    static public GameObject CreateEgg<EggType>(Vector3 position, string tagName) where EggType : EggManager
    {
        position.z = 0;
        eggPrefab = Resources.Load(eggPrefabPath) as GameObject;
        // 객체 생성
        GameObject newEggObject =
            Instantiate(eggPrefab, position, Quaternion.identity);
        newEggObject.tag = tagName;
        newEggObject.name = "" + GetUserClassName<EggType>();
        // 컴포넌트들 추가
        EggType newEggManager = newEggObject.AddComponent<EggType>();

        // static 리스트에 추가, 생성된 egg 객체들의 갯수 관리.
        eggManagers.Add(newEggManager);
        return newEggObject;
    }

   


    static public GameObject CreateBossEgg<EggType>(Vector3 position, string tagName) where EggType : EnemyEggManager
    {
        //Debug.Log("Prefabs/" + "Boss/" + GetClassName<EggType>() + "Prefab");
        string bossPrefabPath = "Prefabs/" + "Boss/" + GetClassName<EggType>() + "Prefab";
        eggPrefab = Resources.Load(bossPrefabPath) as GameObject;
        //eggPrefab = Resources.Load(Chapter1BossPrefabPath) as GameObject;
        // 객체 생성
        GameObject newEggObject =
            Instantiate(eggPrefab, position, Quaternion.identity);
        newEggObject.tag = tagName;
        // 컴포넌트들 추가
        EggType newEggManager = newEggObject.AddComponent<EggType>();
        
        // static 리스트에 추가, 생성된 egg 객체들의 갯수 관리.
        eggManagers.Add(newEggManager);
        return newEggObject;
    }

    // eggManager의 eggManagers에 접근하여 객체를 하나 소멸시킨다. 
    // 소멸될때 이펙트 추가해도 좋다.
    public virtual void DestroyEgg()
    {
        Destroy(child.gameObject);
        GameObject AfterimagePrefab = Resources.Load(AfterimagePrefabPath) as GameObject;
        GameObject newAfterimage = Instantiate(AfterimagePrefab);
        newAfterimage.GetComponent<SpriteRenderer>().sprite = this.gameObject.GetComponent<SpriteRenderer>().sprite;
        newAfterimage.transform.position = this.gameObject.transform.position;
        newAfterimage.transform.rotation = this.gameObject.transform.rotation;
        newAfterimage.transform.localScale = this.gameObject.transform.localScale;

        eggManagers.Remove(this); // eggManagers에서 갯수를 하나 줄이고
        Destroy(this.gameObject); // 게임세상 내 객체를 소멸시킨다.
        Destroy(newAfterimage, 1f);
        if (gameObject.tag == "Player")
        {
            GameManager.userUnitCount -= 1;
        }
        else if (gameObject.tag == "Enemy")
        {
            GameManager.enemyUnitCount -= 1;
        }
        else if (gameObject.tag == "Boss")
        {
            GameManager.bossUnitCount -= 1;
            GameManager.enemyUnitCount -= 1;
        }
    }

    protected virtual void Start()
    {
        parentObject = GameObject.Find("Canvas");
        curHp = maxHp;
        Slider hp = Resources.Load<Slider>("Prefabs/Slider");
        child = Instantiate(hp);
        child.transform.SetParent(parentObject.transform);
        hpBarController = gameObject.AddComponent<HpBarController>();
        hpBarController.Init(curHp, maxHp);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        state_freezePrefab = Resources.Load(state_freezePrefabPath) as GameObject;
        state_cursePrefab = Resources.Load(state_cursePrefabPath) as GameObject;
        
    }



    // protected virtual을 추가해줘서 상속.
    protected virtual void FixedUpdate()
    {
        if (BattleReady.completeReady)
        {
            if (this.gameObject == GameObject.Find("Chapter2BossPrefab(Clone)"))
            {
                GameObject chapter2Boss = GameObject.Find("Chapter2BossPrefab(Clone)");
                EggManager bossEggManager = chapter2Boss.GetComponent<EggManager>();
                if (bossEggManager.curHp <= 0 && !Chapter2BossMove.phase2)
                {
                    maxHp = 700;
                    curHp = 700;
                    chapter2Boss.GetComponent<HpBarController>()
                        .SetHealth(bossEggManager.curHp, bossEggManager.maxHp);
                    Chapter2BossMove.phase2 = !Chapter2BossMove.phase2;
                }
                else if (bossEggManager.curHp <= 0 && Chapter2BossMove.phase2)
                {
                    DestroyEgg();
                }
            }
            else if(curHp <= 0)
            {
                DestroyEgg();
            }
        }
        child.transform.position = transform.position;

    }

    public void MoveEgg(Vector3 force)
    {
        rigidbody2D.AddForce(force * speed);
        force = new Vector3(0, 0, 0);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // 낙사
        if (collision.tag == "DieTrigger" && BattleReady.completeReady)
        {
            DestroyEgg();
        }
    }

    static private string GetClassName<EggType>() where EggType : EnemyEggManager
    {
        return typeof(EggType).Name;
    }
    static private string GetUserClassName<EggType>() where EggType : EggManager
    {
        return typeof(EggType).Name;
    }
}



