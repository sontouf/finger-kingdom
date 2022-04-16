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


    // stage가 시작하면 각 unit의 갯수를 받아와서 객체를 생성해야한다.
    // 일단은 default로 warrior로 생성한다.



    // spawn 위치를 개발자가 stage 별로 정해자. 

    // stage 1 position



    // c# 에서는 c++에서의 STL같이 동적생성배열을 제공하고 있다. 배열크기 알아서 만들어짐
    // List를 통해 위치를 저장해두자.
    protected List<Vector3> EnemyEggSpawnPositions = new List<Vector3>();
    protected List<Vector3> HurdleSpawnPositions = new List<Vector3>();
    protected List<Vector3> chapter3EnemySpawnPosition = new List<Vector3>();
    protected List<int> checkVoid = new List<int>();

    // ================== static field ===============
    static public bool isUserTurn;
    static public int userUnitCount;
    static public int enemyUnitCount;
    static public int bossUnitCount;
    static public int stageNumber = 0;

    // ======================= private field ====================
    public GameObject menuSet; // esc 눌렀을때 나타날 메뉴
    public GameObject victoryMenuSet; // stage 클리어시 나타날 메뉴
    public GameObject defeatMenuSet; // stage 패배시 나타날 메뉴

    // =================== userUnit tagName ====================
    protected string userEggTagName = "Player";
    // =================== enemyUnit tagName ====================
    protected string enemyEggTagName = "Enemy";
    protected string enemyBossTagName = "Boss";


    // Start is called before the first frame update
    protected virtual void Start()
    {
        isUserTurn = true;
        userUnitCount = 0; // 전투화면 내 userUnit 수
        enemyUnitCount = 0; // 전투화면 내 enemyUnit 수
        bossUnitCount = 0;
        // 게임판 객체생성하기. 나중에 sprite로 그림 받아오자

        // user unit 위치 받아오기.
/*        UserEggSpawnPositions.Add(a1);
        UserEggSpawnPositions.Add(a2);
        UserEggSpawnPositions.Add(a3);
        UserEggSpawnPositions.Add(a4);
        UserEggSpawnPositions.Add(a5);
        UserEggSpawnPositions.Add(a6);
        UserEggSpawnPositions.Add(a7);
        UserEggSpawnPositions.Add(a8);
        UserEggSpawnPositions.Add(a9);
        UserEggSpawnPositions.Add(a10);
        UserEggSpawnPositions.Add(a11);*/

        // enemy unit 위치 받아오기
        EnemyEggSpawnPositions.Add(new Vector3(1, 0, 0));
        EnemyEggSpawnPositions.Add(new Vector3(1, 1, 0));
        EnemyEggSpawnPositions.Add(new Vector3(1, -1, 0));
        EnemyEggSpawnPositions.Add(new Vector3(3, 3, 0));
        EnemyEggSpawnPositions.Add(new Vector3(3, 1, 0));
        EnemyEggSpawnPositions.Add(new Vector3(3, -1, 0));
        EnemyEggSpawnPositions.Add(new Vector3(3, -3, 0));
        EnemyEggSpawnPositions.Add(new Vector3(4, 3, 0));
        EnemyEggSpawnPositions.Add(new Vector3(4, 1, 0));
        EnemyEggSpawnPositions.Add(new Vector3(4, -1, 0));
        EnemyEggSpawnPositions.Add(new Vector3(4, -3, 0));
        EnemyEggSpawnPositions.Add(new Vector3(5, 3, 0));
        EnemyEggSpawnPositions.Add(new Vector3(5, 1, 0));
        EnemyEggSpawnPositions.Add(new Vector3(5, -1, 0));
        EnemyEggSpawnPositions.Add(new Vector3(5, -3, 0));

        // hurdle position

        HurdleSpawnPositions.Add(new Vector3((float)-2.5,1,0));
        HurdleSpawnPositions.Add(new Vector3((float)-2.5,-1,0));
        HurdleSpawnPositions.Add(new Vector3((float)-7.7,(float)-3.6,0));
        HurdleSpawnPositions.Add(new Vector3((float)-7.6,(float)3.3,0));
        HurdleSpawnPositions.Add(new Vector3((float)7.6,(float)3.5,0));
        HurdleSpawnPositions.Add(new Vector3((float)4.2, (float)1.3,0));
        HurdleSpawnPositions.Add(new Vector3((float)2.8, (float)-1.1,0));
        HurdleSpawnPositions.Add(new Vector3(2,-2,0));
        HurdleSpawnPositions.Add(new Vector3((float)-4.8, (float)-2.9,0));
        HurdleSpawnPositions.Add(new Vector3((float)0.3, (float)2.7,0));
        HurdleSpawnPositions.Add(new Vector3((float)-5, (float)0.6,0));
        HurdleSpawnPositions.Add(new Vector3((float)-0.1, (float)1.3,0));
        HurdleSpawnPositions.Add(new Vector3((float)-2.3, (float)-0.6,0));


        chapter3EnemySpawnPosition.Add(new Vector3((float)-4.98,(float)1.15,0));
        chapter3EnemySpawnPosition.Add(new Vector3((float)-5.87, (float)0.29, 0));
        chapter3EnemySpawnPosition.Add(new Vector3((float)-6.06, (float)-0.9, 0));
        chapter3EnemySpawnPosition.Add(new Vector3((float)-4.72, (float)3.26, 0));
        chapter3EnemySpawnPosition.Add(new Vector3((float)-7.4, (float)-1.84, 0));
        chapter3EnemySpawnPosition.Add(new Vector3((float)-5.76, (float)-2.92, 0));
        chapter3EnemySpawnPosition.Add(new Vector3((float)-6.95, (float)2.74, 0));
        chapter3EnemySpawnPosition.Add(new Vector3((float)-3.08, (float)-3.29, 0));
        chapter3EnemySpawnPosition.Add(new Vector3((float)-0.25, (float)-2.62, 0));
        chapter3EnemySpawnPosition.Add(new Vector3((float)2.76, (float)-2.95, 0));
        chapter3EnemySpawnPosition.Add(new Vector3((float)4.84, (float)-3.14, 0));
        chapter3EnemySpawnPosition.Add(new Vector3((float)6.33, (float)-2.51, 0));
        chapter3EnemySpawnPosition.Add(new Vector3((float)5.59, (float)-1.69, 0));
        chapter3EnemySpawnPosition.Add(new Vector3((float)6.63, (float)-2.51, 0));
        chapter3EnemySpawnPosition.Add(new Vector3((float)6.18, (float)1.33, 0));
        chapter3EnemySpawnPosition.Add(new Vector3((float)5.29, (float)2.67, 0));
        chapter3EnemySpawnPosition.Add(new Vector3((float)3.58, (float)3.23, 0));
        chapter3EnemySpawnPosition.Add(new Vector3((float)7.67, (float)2.41, 0));
        chapter3EnemySpawnPosition.Add(new Vector3((float)1.42, (float)3.12, 0));
        chapter3EnemySpawnPosition.Add(new Vector3((float)-0.29, (float)2.56, 0));

    }


    // Update is called once per frame
    protected virtual void Update()
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

    }

    public void JudgeResult(int bossStageNumber)
    {
        if (stageNumber == bossStageNumber)
        {
            if (bossUnitCount == 0)
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
        if (userUnitCount > enemyUnitCount && enemyUnitCount == 0)
        {
            victoryMenuSet.SetActive(true);
            if (DontDestroyUserData.stageClearCheck == false)
            {
                DontDestroyUserData.stageClearCheck = !DontDestroyUserData.stageClearCheck;
                userUnitCount = 0;
                enemyUnitCount = 0;
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



}
