using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        newEggObject.AddComponent<EggClicker>();
        newEggObject.AddComponent<ArrowScript>();
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
    private float maxSpeed;

    [SerializeField]
    private float aclrt;
    
    
    private float curr_speed;
    private Vector2 dir;
    public void EggMove()
    {
        if(this.gameObject.GetComponent<ArrowScript>().CheckEndDrop == true)
        {
            Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, 180 + z);
            curr_speed = Mathf.Clamp(curr_speed += aclrt*Time.deltaTime, 0f, maxSpeed);
        }
    }


    private bool isSelected = false;
    public bool IsSelected { get; set; }

    private void Awake()
    {
        circlePrefab = Resources.Load(circlePrefabPath) as GameObject;
    }

    private void Update()
    {
        EggMove();
        transform.Translate(dir * curr_speed * Time.deltaTime, Space.World);
    }


}
