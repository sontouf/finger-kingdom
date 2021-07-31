using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class EggManager : MonoBehaviour//  IPointerEnterHandler
{
    // EggManager의 역할은 EggPrefab 객체의 모든 행동과 정보, 객체 생성과 소멸을 담당한다.
    // EggPrefab 객체에만 달려있는 component라고 생각하자.


    // ===================== [ constant fields ] =========================
    const string eggPrefabPath = "Prefabs/EggPrefab"; // eggPrefab의 위치정보.

    // ====================== [ static eggManagers ] ==========================
    // static 변수로 선언되어 eggPrefab 객체들의 갯수를 관리한다.
    static public List<EggManager> eggManagers = new List<EggManager>();
    static public List<EnemyEggManager> enemyEggManagers = new List<EnemyEggManager>();

    static public void ClearAll()
    {
        eggManagers.Clear();
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
    static public void CreateEgg<EggType>(Vector3 position, string tagName) where EggType : EggManager
    {
        eggPrefab = Resources.Load(eggPrefabPath) as GameObject;
        // 객체 생성
        GameObject newEggObject =
            Instantiate(eggPrefab, position, Quaternion.identity);
        newEggObject.tag = tagName;

        // 컴포넌트들 추가
        EggType newEggManager = newEggObject.AddComponent<EggType>();

        // static 리스트에 추가, 생성된 egg 객체들의 갯수 관리.
        eggManagers.Add(newEggManager);
    }


    // eggManager의 eggManagers에 접근하여 객체를 하나 소멸시킨다. 
    // 소멸될때 이펙트 추가해도 좋다.
    protected virtual void DestroyEgg()
    {
        eggManagers.Remove(this); // eggManagers에서 갯수를 하나 줄이고
        Destroy(this.gameObject); // 게임세상 내 객체를 소멸시킨다.
        if (gameObject.tag == "Player")
        {
            GameManager.userUnitCount -= 1;
        }
        else if (gameObject.tag == "Enemy")
        {
            GameManager.enemyUnitCount -= 1;
        }
    }

    // ===================== [ static private fields ] ===================
    static private GameObject eggPrefab;



    // ====================== [ private fields ] ==========================
    // egg의 sprite 관련 변수
    public SpriteRenderer spriteRenderer;
    new public Rigidbody2D rigidbody2D;
    // egg의 이동 관련 변수
    public float speed = 100;
    public float mass;

    // egg의 Hp 관련 변수
    public float maxHp = 100;
    public float curHp;
    private HpBarController hpBarController;
    public float damage = 10;

    // egg 그 외 기타 정보

    // protected virtual을 추가해줘서 상속.
    // Egg의 메소드 관련 초기화.
    protected virtual void Start()
    {
        curHp = maxHp;
        hpBarController = gameObject.AddComponent<HpBarController>();
        hpBarController.Init(curHp, maxHp);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }



    // protected virtual을 추가해줘서 상속.
    protected virtual void FixedUpdate()
    {
        // 게임판을 벗어나면 egg 소멸 << 낙사 >>
        if (transform.position.x > 6.15 || transform.position.x < -6.15 || transform.position.y > 3.7 || transform.position.y < -3.7)
        {
            DestroyEgg();
        }
        if (curHp <= 0)
        {
            DestroyEgg();
        }

    }

    public void MoveEgg(Vector2 force)
    {
        rigidbody2D.AddForce(force * speed);
        force = new Vector2(0, 0);
    }
}



