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

    // stage 1 position
    // ==================== user unit spawn position =======================
    Vector3 a1 = new Vector3(-5, 1, 0);
    Vector3 a2 = new Vector3(-5, 0, 0);
    Vector3 a3 = new Vector3(-5, -1, 0);
    Vector3 a4 = new Vector3(-3, 3, 0);
    Vector3 a5 = new Vector3(-4, 3, 0);
    Vector3 a6 = new Vector3(-4, 2, 0);
    Vector3 a7 = new Vector3(-5, 2, 0);
    Vector3 a8 = new Vector3(-5, -2, 0);
    Vector3 a9 = new Vector3(-4, -2, 0); 
    Vector3 a10 = new Vector3(-4,-3, 0);
    Vector3 a11= new Vector3(-3, -3, 0);



    // =================== enemy unit spawn position =======================
    Vector3 p1 = new Vector3(0, 0, 0);
    Vector3 p2 = new Vector3(1, 1, 0);
    Vector3 p3 = new Vector3(1, -1, 0);
    Vector3 p4 = new Vector3(3, 3, 0);
    Vector3 p5 = new Vector3(3, 1, 0);
    Vector3 p6 = new Vector3(3, -1, 0);
    Vector3 p7 = new Vector3(3, -3, 0);
    Vector3 p8 = new Vector3(4, 3, 0);
    Vector3 p9 = new Vector3(4, 1, 0);
    Vector3 p10 = new Vector3(4, -1, 0);
    Vector3 p11 = new Vector3(4, -3, 0);
    Vector3 p12 = new Vector3(5, 3, 0);
    Vector3 p13 = new Vector3(5, 1, 0);
    Vector3 p14 = new Vector3(5, -1, 0);
    Vector3 p15= new Vector3(5, -3, 0);





    // c# 에서는 c++에서의 STL같이 동적생성배열을 제공하고 있다. 배열크기 알아서 만들어짐
    // List를 통해 위치를 저장해두자.
    private List<Vector3> UserEggSpawnPositions = new List<Vector3>();
    private List<Vector3> EnemyEggSpawnPositions = new List<Vector3>();
    private List<int> checkVoid = new List<int>();

    // ================== static field ===============
    static public bool isUserTurn;
    static public int userUnitCount;
    static public int enemyUnitCount;
    static public int bossUnitCount;
    static public int stageNumber = 0;

    // ======================= private field ====================
    private GameObject planePrefeb;
    private GameObject hurdlePrefeb;
    private GameObject trapPrefeb;
    public GameObject menuSet; // esc 눌렀을때 나타날 메뉴
    public GameObject victoryMenuSet; // stage 클리어시 나타날 메뉴
    public GameObject defeatMenuSet; // stage 패배시 나타날 메뉴

    // =================== userUnit tagName ====================
    private string userEggTagName = "Player";
    // =================== enemyUnit tagName ====================
    private string enemyEggTagName = "Enemy";
    private string enemyBossTagName = "Enemy";


    // Start is called before the first frame update
    void Start()
    {
        isUserTurn = true;
        userUnitCount = 0; // 전투화면 내 userUnit 수
        enemyUnitCount = 0; // 전투화면 내 enemyUnit 수
        bossUnitCount = 0;
        planePrefeb = Resources.Load(planePrefabPath) as GameObject;
        hurdlePrefeb = Resources.Load(hurdlePrefabPath) as GameObject;
        trapPrefeb = Resources.Load(trapPrefabPath) as GameObject;

        // 게임판 객체생성하기. 나중에 sprite로 그림 받아오자
        Instantiate(planePrefeb, Vector3.zero, Quaternion.identity);
        Instantiate(hurdlePrefeb, new Vector3((float)-2.5, 1, 0), Quaternion.identity);
        Instantiate(trapPrefeb, new Vector3(2, -2, 0), Quaternion.identity);

        // user unit 위치 받아오기.
        UserEggSpawnPositions.Add(a1);
        UserEggSpawnPositions.Add(a2);
        UserEggSpawnPositions.Add(a3);
        UserEggSpawnPositions.Add(a4);
        UserEggSpawnPositions.Add(a5);
        UserEggSpawnPositions.Add(a6);
        UserEggSpawnPositions.Add(a7);
        UserEggSpawnPositions.Add(a8);
        UserEggSpawnPositions.Add(a9);
        UserEggSpawnPositions.Add(a10);
        UserEggSpawnPositions.Add(a11);

        // enemy unit 위치 받아오기
        EnemyEggSpawnPositions.Add(p1);
        EnemyEggSpawnPositions.Add(p2);
        EnemyEggSpawnPositions.Add(p3);
        EnemyEggSpawnPositions.Add(p4);
        EnemyEggSpawnPositions.Add(p5);
        EnemyEggSpawnPositions.Add(p6);
        EnemyEggSpawnPositions.Add(p7);
        EnemyEggSpawnPositions.Add(p8);
        EnemyEggSpawnPositions.Add(p9);
        EnemyEggSpawnPositions.Add(p10);
        EnemyEggSpawnPositions.Add(p11);
        EnemyEggSpawnPositions.Add(p12);
        EnemyEggSpawnPositions.Add(p13);
        EnemyEggSpawnPositions.Add(p14);
        EnemyEggSpawnPositions.Add(p15);


        // 위치랑 tag 이름 받아와서 egg 객체 생성, 자세한 내용은 eggmanager 참고.
        int idx = 0;
        if (stageNumber == 4)
        {
            EnemyEggSpawnPositions.Remove(p9);
            EnemyEggSpawnPositions.Remove(p10);
            EnemyEggSpawnPositions.Remove(p13);
            EnemyEggSpawnPositions.Remove(p14);
        }
        for (int i = 0; i < EnemyEggSpawnPositions.Count; i++)
        {
            checkVoid.Add(i);
        }
        if (stageNumber == 1)
        {
            idx = Random.Range(0, checkVoid.Count);
            for (int i = 3; i > 0; --i)
            {
                EggManager.CreateEgg<GoblinEgg>(EnemyEggSpawnPositions[idx], enemyEggTagName);
                checkVoid.Remove(checkVoid[idx]);
                EnemyEggSpawnPositions.Remove(EnemyEggSpawnPositions[idx]);
                idx = Random.Range(0, checkVoid.Count);
                enemyUnitCount += 1;
                Debug.Log("checkdd : " + stageNumber);
            }
        }
        else if (stageNumber == 2)
        {
            idx = Random.Range(0, checkVoid.Count);
            for (int i = 4; i > 0; --i)
            {
                EggManager.CreateEgg<GoblinEgg>(EnemyEggSpawnPositions[idx], enemyEggTagName);
                checkVoid.Remove(checkVoid[idx]);
                EnemyEggSpawnPositions.Remove(EnemyEggSpawnPositions[idx]);
                idx = Random.Range(0, checkVoid.Count);
                enemyUnitCount += 1;
            }

            idx = Random.Range(0, checkVoid.Count);
            for (int i = 1; i > 0; --i)
            {
                EggManager.CreateEgg<OakEgg>(EnemyEggSpawnPositions[idx], enemyEggTagName);
                checkVoid.Remove(checkVoid[idx]);
                EnemyEggSpawnPositions.Remove(EnemyEggSpawnPositions[idx]);
                idx = Random.Range(0, checkVoid.Count);
                enemyUnitCount += 1;
            }
        }
        else if (stageNumber == 3)
        {
            idx = Random.Range(0, checkVoid.Count);
            for (int i = 3; i > 0; --i)
            {
                EggManager.CreateEgg<GoblinEgg>(EnemyEggSpawnPositions[idx], enemyEggTagName);
                EnemyEggSpawnPositions.Remove(EnemyEggSpawnPositions[idx]);
                checkVoid.Remove(checkVoid[idx]);
                idx = Random.Range(0, checkVoid.Count);
                enemyUnitCount += 1;
            }

            idx = Random.Range(0, checkVoid.Count);
            for (int i = 1; i > 0; --i)
            {
                EggManager.CreateEgg<OakEgg>(EnemyEggSpawnPositions[idx], enemyEggTagName);
                EnemyEggSpawnPositions.Remove(EnemyEggSpawnPositions[idx]);
                checkVoid.Remove(checkVoid[idx]);
                idx = Random.Range(0, checkVoid.Count);
                enemyUnitCount += 1;
            }

            idx = Random.Range(0, checkVoid.Count);
            for (int i = 2; i > 0; --i)
            {
                EggManager.CreateEgg<WolfEgg>(EnemyEggSpawnPositions[idx], enemyEggTagName);
                EnemyEggSpawnPositions.Remove(EnemyEggSpawnPositions[idx]);
                checkVoid.Remove(checkVoid[idx]);
                idx = Random.Range(0, checkVoid.Count);
                enemyUnitCount += 1;
            }
        }
        else if (stageNumber == 4)
        {

            idx = Random.Range(0, checkVoid.Count);
            for (int i = 3; i > 0; --i)
            {
                EggManager.CreateEgg<GoblinEgg>(EnemyEggSpawnPositions[idx], enemyEggTagName);
                EnemyEggSpawnPositions.Remove(EnemyEggSpawnPositions[idx]);
                checkVoid.Remove(checkVoid[idx]);
                idx = Random.Range(0, checkVoid.Count);
                enemyUnitCount += 1;
            }

            idx = Random.Range(0, checkVoid.Count);
            for (int i = 2; i > 0; --i)
            {
                EggManager.CreateEgg<OakEgg>(EnemyEggSpawnPositions[idx], enemyEggTagName);
                EnemyEggSpawnPositions.Remove(EnemyEggSpawnPositions[idx]);
                checkVoid.Remove(checkVoid[idx]);
                idx = Random.Range(0, checkVoid.Count);
                enemyUnitCount += 1;
            }


            idx = Random.Range(0, checkVoid.Count);
            for (int i = 2; i > 0; --i)
            {
                EggManager.CreateEgg<WolfEgg>(EnemyEggSpawnPositions[idx], enemyEggTagName);
                EnemyEggSpawnPositions.Remove(EnemyEggSpawnPositions[idx]);
                checkVoid.Remove(checkVoid[idx]);
                idx = Random.Range(0, checkVoid.Count);
                enemyUnitCount += 1;
            }

            Chapter1Boss.CreateBoss(new Vector3(4.5f,0,0),enemyBossTagName );
            bossUnitCount -= 1;
            enemyUnitCount += 1;
        }

        int iidx = checkVoid.Count;
        EggManager.enemyEggManagers = EggManager.GetEggManagersByType<EnemyEggManager>();
        for (int i = 0; i < iidx; i++)
        {
            checkVoid.Remove(checkVoid[0]);
        }
        // ======================UserPosition===================
        for (int i = 0; i < UserEggSpawnPositions.Count; i++)
        {
            checkVoid.Add(i);
        }

        idx = Random.Range(0, checkVoid.Count);
        for (int i = SelectedUnitData.warriorNumber; i > 0; --i)
        {
            EggManager.CreateEgg<WarriorEgg>(UserEggSpawnPositions[idx], userEggTagName);
            UserEggSpawnPositions.Remove(UserEggSpawnPositions[idx]);
            checkVoid.Remove(checkVoid[idx]);
            idx = Random.Range(0, checkVoid.Count);
            userUnitCount += 1;
        }
        idx = Random.Range(0, checkVoid.Count);
        for (int i = SelectedUnitData.archerNumber; i > 0; --i)
        {
            EggManager.CreateEgg<ArcherEgg>(UserEggSpawnPositions[idx], userEggTagName);
            UserEggSpawnPositions.Remove(UserEggSpawnPositions[idx]);
            checkVoid.Remove(checkVoid[idx]);
            idx = Random.Range(0, checkVoid.Count);
            userUnitCount += 1;
        }
        idx = Random.Range(0, checkVoid.Count);
        for (int i = 0; i < SelectedUnitData.shieldNumber; i++)
        {
            EggManager.CreateEgg<ShieldEgg>(UserEggSpawnPositions[idx], userEggTagName);
            UserEggSpawnPositions.Remove(UserEggSpawnPositions[idx]);
            checkVoid.Remove(checkVoid[idx]);
            idx = Random.Range(0, checkVoid.Count);
            userUnitCount += 1;
        }
        idx = Random.Range(0, checkVoid.Count);
        for (int i = 0; i < SelectedUnitData.cavalryNumber; i++)
        {
            EggManager.CreateEgg<CavalryEgg>(UserEggSpawnPositions[idx], userEggTagName);
            UserEggSpawnPositions.Remove(UserEggSpawnPositions[idx]);
            checkVoid.Remove(checkVoid[idx]);
            idx = Random.Range(0, checkVoid.Count);
            userUnitCount += 1;
        }
        idx = Random.Range(0, checkVoid.Count);
        for (int i = 0; i < SelectedUnitData.healerNumber; i++)
        {
            EggManager.CreateEgg<HealerEgg>(UserEggSpawnPositions[idx], userEggTagName);
            UserEggSpawnPositions.Remove(UserEggSpawnPositions[idx]);
            checkVoid.Remove(checkVoid[idx]);
            idx = Random.Range(0, checkVoid.Count);
            userUnitCount += 1;
        }

        iidx = checkVoid.Count;
        for (int i = 0; i < iidx; i++)
        {
            checkVoid.Remove(checkVoid[0]);
        }
        iidx = EnemyEggSpawnPositions.Count;
        for (int i = 0; i < iidx; i++)
        {
            EnemyEggSpawnPositions.Remove(EnemyEggSpawnPositions[0]);
        }
        iidx = UserEggSpawnPositions.Count;
        for (int i = 0; i < iidx; i++)
        {
            UserEggSpawnPositions.Remove(UserEggSpawnPositions[0]);
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
            if (stageNumber == 4)
            {
                if(bossUnitCount == 0)
                {
                    victoryMenuSet.SetActive(true);
                    if (DontDestroyUserData.stageClearCheck == false)
                    {
                        DontDestroyUserData.stageClearCheck = !DontDestroyUserData.stageClearCheck;
                        userUnitCount = 0;
                        enemyUnitCount = 0;
                    }
                }
            }
            else
            {
                victoryMenuSet.SetActive(true);
                if (DontDestroyUserData.stageClearCheck == false)
                {
                    DontDestroyUserData.stageClearCheck = !DontDestroyUserData.stageClearCheck;
                    userUnitCount = 0;
                    enemyUnitCount = 0;
                }
            }
        }
        else if (userUnitCount < enemyUnitCount && userUnitCount == 0)
        {
            defeatMenuSet.SetActive(true);
            userUnitCount = 0;
            enemyUnitCount = 0;
        }
    }

    // ==================== Method =======================
    public void ExitGame()
    {
        EggManager.ClearAll();
        SceneManager.LoadScene(0);
        SelectedUnitData.warriorNumber = 0;
        SelectedUnitData.archerNumber = 0;
        SelectedUnitData.shieldNumber = 0;
        SelectedUnitData.cavalryNumber = 0;
        SelectedUnitData.healerNumber = 0;
    }

    public void RestartGame()
    {
        EggManager.ClearAll();
        SceneManager.LoadScene(4);

    }

    public void VictoryStage()
    {
        EggManager.ClearAll();
        SceneManager.LoadScene(2);
    }
    


}
