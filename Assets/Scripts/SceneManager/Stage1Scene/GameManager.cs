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


    // ================== static field ===============
    static public bool isUserTurn;
    static public int userUnitCount;
    static public int enemyUnitCount;


    // ======================= private field ====================
    private GameObject planePrefeb;
    private GameObject hurdlePrefeb;
    private GameObject trapPrefeb;
    public GameObject menuSet; // esc 눌렀을때 나타날 메뉴
    public GameObject victoryMenuSet; // stage 클리어시 나타날 메뉴
    public GameObject defeatMenuSet; // stage 패배시 나타날 메뉴
    private int selectedUserUnitCount = 0;
    private int selectedEnemyUnitCount = 0;

    // =================== userUnit tagName ====================
    private string userEggTagName = "Player";



    // =================== enemyUnit tagName ====================
    private string enemyEggTagName = "Enemy";


    // Start is called before the first frame update
    void Start()
    {
        isUserTurn = true;
        userUnitCount = 0; // 전투화면 내 userUnit 수
        enemyUnitCount = 0; // 전투화면 내 enemyUnit 수

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
        if ( DontDestroyUserData.storyNumber >= 0) 
        {
            if (DontDestroyUserData.storyNumber >= 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    EggManager.CreateEgg<GoblinEgg>(EnemyEggSpawnPositions[selectedEnemyUnitCount], enemyEggTagName);
                    selectedEnemyUnitCount += 1;
                    enemyUnitCount += 1;
                }
            }
        }
        if (DontDestroyUserData.storyNumber >= 0)
        {
            for (int i = 0; i < SelectedUnitData.warriorNumber; i++)
            {
                EggManager.CreateEgg<WarriorEgg>(UserEggSpawnPositions[selectedUserUnitCount], userEggTagName);
                selectedUserUnitCount += 1;
                userUnitCount += 1;
            }
            for (int i = 0; i < SelectedUnitData.archerNumber; i++)
            {
                EggManager.CreateEgg<ArcherEgg>(UserEggSpawnPositions[selectedUserUnitCount], userEggTagName);
                selectedUserUnitCount += 1;
                userUnitCount += 1;
            }
            for (int i = 0; i < SelectedUnitData.shieldNumber; i++)
            {
                EggManager.CreateEgg<ShieldEgg>(UserEggSpawnPositions[selectedUserUnitCount], userEggTagName);
                selectedUserUnitCount += 1;
                userUnitCount += 1;
            }
            for (int i = 0; i < SelectedUnitData.cavalryNumber; i++)
            {
                EggManager.CreateEgg<CavalryEgg>(UserEggSpawnPositions[selectedUserUnitCount], userEggTagName);
                selectedUserUnitCount += 1;
                userUnitCount += 1;
            }
            for (int i = 0; i < SelectedUnitData.healerNumber; i++)
            {
                EggManager.CreateEgg<HealerEgg>(UserEggSpawnPositions[selectedUserUnitCount], userEggTagName);
                selectedUserUnitCount += 1;
                userUnitCount += 1;
            }
            EggManager.GetEggManagersByType<EnemyEggManager>();
        }
    }


    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (menuSet.activeSelf)
            {
                menuSet.SetActive(false);
            }
            else
            {
                menuSet.SetActive(true);
            }
        }

        if (isUserTurn)
        {
            Debug.Log("player turn");
        }
        else
        {
            Debug.Log("enemy turn");
        }

        JudgeResult();

    }

    public void JudgeResult()
    {
        if (userUnitCount > enemyUnitCount && enemyUnitCount == 0)
        {
            victoryMenuSet.SetActive(true);
            if (DontDestroyUserData.stageClearCheck == false)
            {
                DontDestroyUserData.stageClearCheck = !DontDestroyUserData.stageClearCheck;
            }
        }
        else if (userUnitCount < enemyUnitCount && userUnitCount == 0)
        {
            defeatMenuSet.SetActive(true);
        }
    }

    // ==================== Method =======================
    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        EggManager.ClearAll();
        SceneManager.LoadScene(4);

    }

    public void VictoryStage()
    {
        SceneManager.LoadScene(2);
    }
    

}
