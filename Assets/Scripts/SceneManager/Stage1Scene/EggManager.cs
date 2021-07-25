using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;



public class EggManager : MonoBehaviour , IDragHandler, IEndDragHandler//  IPointerEnterHandler
{
    // EggManager의 역할은 EggPrefab 객체의 모든 행동과 정보, 객체 생성과 소멸을 담당한다.
    // EggPrefab 객체에만 달려있는 component라고 생각하자.


    // ===================== [ constant fields ] =========================
    const string eggPrefabPath = "Prefabs/EggPrefab"; // eggPrefab의 위치정보.

    // ====================== [ static eggManagers ] ==========================
    // static 변수로 선언되어 eggPrefab 객체들의 갯수를 관리한다.
    static public List<EggManager> eggManagers = new List<EggManager>(); 


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
    static public void DestroyEgg(EggManager eggManager)
    {
        eggManagers.Remove(eggManager); // eggManagers에서 갯수를 하나 줄이고
        Destroy(eggManager.gameObject); // 게임세상 내 객체를 소멸시킨다.
        if(eggManager.gameObject.tag == "Player")
        {
            GameManager.userUnitCount -= 1;
        }
        else if (eggManager.gameObject.tag == "Enemy")
        {
            GameManager.enemyUnitCount -= 1;
        }
    }

    // ===================== [ static private fields ] ===================
    static private GameObject eggPrefab;



    // ====================== [ private fields ] ==========================
    // egg의 sprite 관련 변수
    public SpriteRenderer spriteRenderer;

    // egg의 이동 관련 변수
    private Vector2 force = new Vector2(0, 0);
    public float speed = 100;
    public float mass;


    public bool holding = false;
    public Vector2 mousePos;
    public Camera mainCamera;
    

    private float range;

    // egg의 Hp 관련 변수
    public float maxHp = 100;
    public float curHp;
    private HpBarController hpBarController;
    public float damage = 10;




    // egg 그 외 기타 정보
    private bool isEnter = false;

    // protected virtual을 추가해줘서 상속.
    // Egg의 메소드 관련 초기화.
    protected virtual void Start()
    {
        range = GetComponent<CircleCollider2D>().radius;
        curHp = maxHp;
        hpBarController = gameObject.AddComponent<HpBarController>();
        hpBarController.Init(curHp, maxHp);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

 

    // protected virtual을 추가해줘서 상속.
    protected virtual void Update()
    {

        // 게임판을 벗어나면 egg 소멸 << 낙사 >>
        if (transform.position.x > 6.15 || transform.position.x < -6.15 || transform.position.y > 3.7 || transform.position.y < -3.7)
        {
            DestroyEgg(this);
        }
        if (curHp <= 0)
        {
            DestroyEgg(this);
        }
        
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnDrag(PointerEventData data)
    {
        force = (Vector2)transform.position - mousePos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        MoveEgg();
        if (isEnter != true)
        {
            GameManager.isUserTurn = !GameManager.isUserTurn;
        }
    }

    // egg 이동
    // EggManager Update()에서 매 순간 마우스 위치를 체크해 egg move에 필요한 정보를 넘겨준다.
    public void MoveEgg()
    {
        GetComponent<Rigidbody2D>().AddForce(force * speed);
        force = new Vector2(0, 0);
    }

    //Detect if the Cursor starts to pass over the GameObject
/*    public void OnPointerExit(PointerEventData pointerEventData)
    {
        //Output to console the GameObject's name and the following message
        Debug.Log("Cursor Entering " + name + " GameObject");

    }*/


    // Egg한테 충돌이 발생하면 자동으로 호출된다.
    // HpBarControl 관련 정보를 발생시키고 객체 소멸에 도움을 준다.
    // tag정보를 통해 HpBar 관련 정보를 제공하고 있다.
    // Turn 정보제공 메소드를 완성한다면 Turn 정보를 제공하여 충돌이 일어났을때의 추가적인 정보를 제공필요.
    private void OnCollisionEnter2D(Collision2D other)
    {
        isEnter = true;
        GameObject otherObject = other.gameObject;
        EggManager otherEggManager = otherObject.GetComponent<EggManager>();



        if (otherObject.CompareTag("Trap"))
        {
            DestroyEgg(this);
        }

        if (otherObject.CompareTag("Enemy") && !GameManager.isUserTurn)
        {
            if (this.gameObject.tag == "Player")
            {
                otherEggManager.curHp -= damage;
            }
            otherObject.GetComponent<HpBarController>()
                        .SetHealth(otherEggManager.curHp, otherEggManager.maxHp);
        }
        else if (otherObject.CompareTag("Player") && GameManager.isUserTurn)
        {
            if (this.gameObject.tag == "Enemy")
            {
                otherEggManager.curHp -= damage;
            }
            otherObject.GetComponent<HpBarController>()
                        .SetHealth(otherEggManager.curHp, otherEggManager.maxHp);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isEnter = false;
        GameManager.isUserTurn = !GameManager.isUserTurn;
    }

}



