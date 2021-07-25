using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // GameManager 스크립트 : stage가 시작하면 생성되는 객체를 관리한다.
    // // stage가 시작하면 각 unit의 갯수를 받아와서 객체를 생성해야한다.
    // 게임판, UserUnit, EnemyUnit을 생성시킨다.




    const string planePrefabPath = "Prefabs/PlanePrefab";
    const string hurdlePrefabPath = "Prefabs/HurdlePrefab";
    const string trapPrefabPath = "Prefabs/TrapPrefab";

    // stage가 시작하면 각 unit의 갯수를 받아와서 객체를 생성해야한다.
    // 일단은 default로 warrior로 생성한다.



    // spawn 위치를 개발자가 stage 별로 정해자. 

    // ==================== user unit spawn position =======================
    Vector3 p1 = new Vector3(-5, 2, 0);
    Vector3 p2 = new Vector3(-5, 0, 0);
    Vector3 p3 = new Vector3(-5, -2, 0);

    // =================== user unit spawn position =======================
    Vector3 p4 = new Vector3(5, 2, 0);
    Vector3 p5 = new Vector3(5, 0, 0);
    Vector3 p6 = new Vector3(5, -2, 0);


    // c# 에서는 c++에서의 STL같이 동적생성배열을 제공하고 있다. 배열크기 알아서 만들어짐
    // List를 통해 위치를 저장해두자.
    private List<Vector3> UserEggSpawnPositions = new List<Vector3>();
    private List<Vector3> EnemyEggSpawnPositions = new List<Vector3>();



    // ======================= private field ====================
    private GameObject planePrefeb;
    private GameObject hurdlePrefeb;
    private GameObject trapPrefeb;
    public GameObject menuSet;

    // =================== userUnit tagName ====================
    private string userEggTagName = "Player";
    private string worriorTagName = "Warrior";
    private string archerTagName = "Archer";
    private string cavalryTagName = "Cavalry";
    private string healerTagName = "Healer";



    // =================== enemyUnit tagName ====================
    private string enemyEggTagName = "Enemy";
    private string goblinTagName = "Goblin";
    private string ogreTagName = "Ogre";
    private string skeletonTagName = "Skeleton";


    // Start is called before the first frame update
    void Start()
    {
        planePrefeb = Resources.Load(planePrefabPath) as GameObject;
        hurdlePrefeb = Resources.Load(hurdlePrefabPath) as GameObject;
        trapPrefeb = Resources.Load(trapPrefabPath) as GameObject;

        // 게임판 객체생성하기. 나중에 sprite로 그림 받아오자
        Instantiate(planePrefeb, Vector3.zero, Quaternion.identity);
        Instantiate(hurdlePrefeb, new Vector3((float)-2.5, 1, 0), Quaternion.identity);
        Instantiate(trapPrefeb, new Vector3(2, -2, 0), Quaternion.identity);


        // user unit 위치 받아오기.
        UserEggSpawnPositions.Add(p1);
        UserEggSpawnPositions.Add(p2);
        UserEggSpawnPositions.Add(p3);

        // enemy unit 위치 받아오기
        EnemyEggSpawnPositions.Add(p4);
        EnemyEggSpawnPositions.Add(p5);
        EnemyEggSpawnPositions.Add(p6);

        
        // 위치랑 tag 이름 받아와서 egg 객체 생성, 자세한 내용은 eggmanager 참고.
        foreach (Vector3 pos in EnemyEggSpawnPositions)
        {
            EggManager.CreateEgg<WarriorEgg>(pos, enemyEggTagName);
        }
        foreach (Vector3 pos in UserEggSpawnPositions)
        {
            EggManager.CreateEgg<WarriorEgg>(pos, userEggTagName);
        }



    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (menuSet.activeSelf)
                menuSet.SetActive(false);
            else
                menuSet.SetActive(true);
        }

    }
    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ReStartGame()
    {
        SceneManager.LoadScene(4);
    }



}
