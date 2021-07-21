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


        // 컴포넌트들 추가
        EggManager newEggManager = new EggManager();
        InitEgg(newEggObject, newEggManager);

        newEggObject.AddComponent<EggMoveController>().eggManager = newEggManager;
        // static 리스트에 추가
        eggManagers.Add(newEggManager);
        newEggObject.tag = tagName;
    }

    static public void InitEgg(GameObject newEggObject, EggManager newEggManager)
    {
        newEggManager.range = newEggObject.GetComponent<CircleCollider2D>().radius;
        newEggManager.canvasObject = newEggObject.gameObject.transform.GetChild(0).gameObject;
        newEggManager.eggObject = newEggObject;
        newEggManager.transform = newEggObject.GetComponent<Transform>();
        newEggManager.hpBarController = newEggObject.AddComponent<HpBarController>();
        newEggManager.curHp = newEggManager.maxHp;
        newEggManager.hpBarController.hpBar = newEggObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Slider>();
        newEggManager.hpBarController.SetHealth(newEggManager.curHp, newEggManager.maxHp);
    }

    static public void DestroyEgg(EggManager eggManager)
    {
        eggManagers.Remove(eggManager);
        Destroy(eggManager.eggObject);
    }

    // ===================== [ static private fields ] ===================
    [SerializeField]
    static private GameObject circlePrefab;

    // ====================== [ private fields ] ==========================

    private GameObject canvasObject;
    new private Transform transform;
    public GameObject eggObject;

    private Vector2 force = new Vector2(0, 0);
    private float speed = 50;
    private Vector2 mousePos;
 
    private bool holding = false;
    private float range;

    private float maxHp = 100;
    public float curHp;
    public float CurHp { get; set; }
    private HpBarController hpBarController;

    public float damage = 10;
    public float Damage { get; set; }

    private void Awake()
    {
        circlePrefab = Resources.Load(circlePrefabPath) as GameObject;
    }

    public void MoveEgg(Camera camera, Transform transform, EggManager eggManager)
    {
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        if (transform.position.x > 6 || transform.position.x < -6 || transform.position.y > 4 || transform.position.y < -4)
        {

            DestroyEgg(eggManager);
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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collider O1n");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            CurHp -= Damage;
            Debug.Log("collider On");
        }
    }
}



