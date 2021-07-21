using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class EggManager : MonoBehaviour
{
    // ===================== [ constant fields ] =========================
    const string circlePrefabPath = "Prefabs/CirclePrefab";

    // ====================== [ static eggManagers ] ==========================
    static private List<EggManager> eggManagers = new List<EggManager>();

    static public void CreateEgg(Vector3 position, string tagName)
    {
        // 객체 생성
        GameObject newEggObject =
            Instantiate(circlePrefab, position, Quaternion.identity);

        EggManager newEggManager = newEggObject.AddComponent<EggManager>();
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
 
    private void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();

        range = gameObject.GetComponent<CircleCollider2D>().radius;
        curHp = maxHp;
        hpBarController = gameObject.AddComponent<HpBarController>();
        hpBarController.Init(curHp, maxHp);
    }
    private void Update()
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
        if (other.gameObject.tag == "Enemy")
        {
            if (this.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<EggManager>().curHp -= this.gameObject.GetComponent<EggManager>().damage;
            }
            other.gameObject.GetComponent<HpBarController>().SetHealth(other.gameObject.GetComponent<EggManager>().curHp, other.gameObject.GetComponent<EggManager>().maxHp);
            if (other.gameObject.GetComponent<EggManager>().curHp <= 0)
            {
                DestroyEgg(other.gameObject.GetComponent<EggManager>());
            }

        }
    }
}



