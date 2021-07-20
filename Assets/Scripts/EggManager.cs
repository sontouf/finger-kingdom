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

    static public void CreateEgg(Vector3 position)
    {
        // 객체 생성
        GameObject newEggObject =
            Instantiate(circlePrefab, position, Quaternion.identity);
 
        // 컴포넌트들 추가
        EggManager newEggManager = newEggObject.AddComponent<EggManager>();


        // static 리스트에 추가
        eggManagers.Add(newEggManager);
    }

 

    static public void DestroyEgg(EggManager eggManager)
    {
        eggManagers.Remove(eggManager);
        Destroy(eggManager.gameObject);

    }

    // ===================== [ static private fields ] ===================
    [SerializeField]
    static private GameObject circlePrefab;

    // ====================== [ private fields ] ==========================

    [SerializeField]

    private Vector2 targetPosition;

    [SerializeField]
    private Vector2 force = new Vector2(0, 0);
    private float speed = 50;
    private Vector2 mousePos;
    Camera Camera;
    private bool holding = false;
    private float range;


    [SerializeField]
    private float hp = 100;
    private float damage = 10;



    private void Awake()
    {
        circlePrefab = Resources.Load(circlePrefabPath) as GameObject;
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        range = GetComponent<CircleCollider2D>().radius;
    }





    private void Update()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.ScreenToWorldPoint(mousePos);
        if (transform.position.x > 6 || transform.position.x < -6 || transform.position.y > 4 || transform.position.y < -4)
        {
            
            DestroyEgg(this.GetComponent<EggManager>());
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
                GetComponent<Rigidbody2D>().AddForce(force * speed);
                force = new Vector2(0, 0);
                holding = false;
            }
        }

    }

    // ================= [ Instance Methods ] =================== 


}
