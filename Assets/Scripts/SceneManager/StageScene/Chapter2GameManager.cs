using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter2GameManager : GameManager
{
    private const string smallIceWallPrefabPath = "Prefabs/Hurdles/SmallIceWallPrefab";
    private const string normalIceWallPrefabPath = "Prefabs/Hurdles/NormalIceWallPrefab";
    private const string bigIceWallPrefabPath = "Prefabs/Hurdles/BigIceWallPrefab";

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        GameObject smallIceWall1Prefab = Resources.Load(smallIceWallPrefabPath) as GameObject;
        GameObject normalIceWallPrefab = Resources.Load(normalIceWallPrefabPath) as GameObject;
        GameObject bigIceWallPrefab = Resources.Load(bigIceWallPrefabPath) as GameObject;

        //=====================================================



        int idx = 0;
        for (int i = 0; i < HurdleSpawnPositions.Count; i++)
        {
            checkVoid.Add(i);
        }
        idx = Random.Range(0, checkVoid.Count);
        for (int i = 4; i > 0; i--)
        {
            Instantiate(smallIceWall1Prefab, HurdleSpawnPositions[idx], Quaternion.identity);
            checkVoid.Remove(checkVoid[idx]);
            HurdleSpawnPositions.Remove(HurdleSpawnPositions[idx]);
            idx = Random.Range(0, checkVoid.Count);
        }
        for (int i = 2; i > 0; i--)
        {
            Instantiate(normalIceWallPrefab, HurdleSpawnPositions[idx], Quaternion.identity);
            checkVoid.Remove(checkVoid[idx]);
            HurdleSpawnPositions.Remove(HurdleSpawnPositions[idx]);
            idx = Random.Range(0, checkVoid.Count);
        }
        for (int i = 1; i > 0; i--)
        {
            Instantiate(bigIceWallPrefab, HurdleSpawnPositions[idx], Quaternion.identity);
            checkVoid.Remove(checkVoid[idx]);
            HurdleSpawnPositions.Remove(HurdleSpawnPositions[idx]);
            idx = Random.Range(0, checkVoid.Count);
        }
        int iidx = checkVoid.Count;
        for (int i = 0; i < iidx; i++)
        {
            checkVoid.Remove(checkVoid[0]);
        }


        //=======================================================
        // 위치랑 tag 이름 받아와서 egg 객체 생성, 자세한 내용은 eggmanager 참고.
        idx = 0;
        if (stageNumber == 8)
        {
            EnemyEggSpawnPositions.Remove(new Vector3(4, 1, 0));
            EnemyEggSpawnPositions.Remove(new Vector3(4, -1, 0));
            EnemyEggSpawnPositions.Remove(new Vector3(5, 1, 0));
            EnemyEggSpawnPositions.Remove(new Vector3(5, -1, 0));
        }
        for (int i = 0; i < EnemyEggSpawnPositions.Count; i++)
        {
            checkVoid.Add(i);
        }
        if (stageNumber == 5)
        {
            idx = Random.Range(0, checkVoid.Count);
            for (int i = 5; i > 0; --i)
            {
                EggManager.CreateEgg<GhostEgg>(EnemyEggSpawnPositions[idx], enemyEggTagName);
                checkVoid.Remove(checkVoid[idx]);
                EnemyEggSpawnPositions.Remove(EnemyEggSpawnPositions[idx]);
                idx = Random.Range(0, checkVoid.Count);
                enemyUnitCount += 1;
            }
        }
        else if (stageNumber == 6)
        {
            idx = Random.Range(0, checkVoid.Count);
            for (int i = 3; i > 0; --i)
            {
                EggManager.CreateEgg<WhiteGoblinEgg>(EnemyEggSpawnPositions[idx], enemyEggTagName);
                checkVoid.Remove(checkVoid[idx]);
                EnemyEggSpawnPositions.Remove(EnemyEggSpawnPositions[idx]);
                idx = Random.Range(0, checkVoid.Count);
                enemyUnitCount += 1;
            }

            idx = Random.Range(0, checkVoid.Count);
            for (int i = 1; i > 0; --i)
            {
                EggManager.CreateEgg<YetiEgg>(EnemyEggSpawnPositions[idx], enemyEggTagName);
                checkVoid.Remove(checkVoid[idx]);
                EnemyEggSpawnPositions.Remove(EnemyEggSpawnPositions[idx]);
                idx = Random.Range(0, checkVoid.Count);
                enemyUnitCount += 1;
            }
            for (int i = 3; i > 0; --i)
            {
                EggManager.CreateEgg<GhostEgg>(EnemyEggSpawnPositions[idx], enemyEggTagName);
                EnemyEggSpawnPositions.Remove(EnemyEggSpawnPositions[idx]);
                checkVoid.Remove(checkVoid[idx]);
                idx = Random.Range(0, checkVoid.Count);
                enemyUnitCount += 1;
            }
        }
        else if (stageNumber == 7)
        {
            idx = Random.Range(0, checkVoid.Count);
            for (int i = 4; i > 0; --i)
            {
                EggManager.CreateEgg<WhiteGoblinEgg>(EnemyEggSpawnPositions[idx], enemyEggTagName);
                EnemyEggSpawnPositions.Remove(EnemyEggSpawnPositions[idx]);
                checkVoid.Remove(checkVoid[idx]);
                idx = Random.Range(0, checkVoid.Count);
                enemyUnitCount += 1;
            }

            idx = Random.Range(0, checkVoid.Count);
            for (int i = 4; i > 0; --i)
            {
                EggManager.CreateEgg<YetiEgg>(EnemyEggSpawnPositions[idx], enemyEggTagName);
                EnemyEggSpawnPositions.Remove(EnemyEggSpawnPositions[idx]);
                checkVoid.Remove(checkVoid[idx]);
                idx = Random.Range(0, checkVoid.Count);
                enemyUnitCount += 1;
            }

            idx = Random.Range(0, checkVoid.Count);
            for (int i = 2; i > 0; --i)
            {
                EggManager.CreateEgg<GhostEgg>(EnemyEggSpawnPositions[idx], enemyEggTagName);
                EnemyEggSpawnPositions.Remove(EnemyEggSpawnPositions[idx]);
                checkVoid.Remove(checkVoid[idx]);
                idx = Random.Range(0, checkVoid.Count);
                enemyUnitCount += 1;
            }
        }
        else if (stageNumber == 8)
        {

            idx = Random.Range(0, checkVoid.Count);
            for (int i = 3; i > 0; --i)
            {
                EggManager.CreateEgg<WhiteGoblinEgg>(EnemyEggSpawnPositions[idx], enemyEggTagName);
                EnemyEggSpawnPositions.Remove(EnemyEggSpawnPositions[idx]);
                checkVoid.Remove(checkVoid[idx]);
                idx = Random.Range(0, checkVoid.Count);
                enemyUnitCount += 1;
            }

            idx = Random.Range(0, checkVoid.Count);
            for (int i = 2; i > 0; --i)
            {
                EggManager.CreateEgg<YetiEgg>(EnemyEggSpawnPositions[idx], enemyEggTagName);
                EnemyEggSpawnPositions.Remove(EnemyEggSpawnPositions[idx]);
                checkVoid.Remove(checkVoid[idx]);
                idx = Random.Range(0, checkVoid.Count);
                enemyUnitCount += 1;
            }


            idx = Random.Range(0, checkVoid.Count);
            for (int i = 3; i > 0; --i)
            {
                EggManager.CreateEgg<GhostEgg>(EnemyEggSpawnPositions[idx], enemyEggTagName);
                EnemyEggSpawnPositions.Remove(EnemyEggSpawnPositions[idx]);
                checkVoid.Remove(checkVoid[idx]);
                idx = Random.Range(0, checkVoid.Count);
                enemyUnitCount += 1;
            }

            GameObject chapter2Boss = EggManager.CreateBossEgg<Chapter2Boss>(new Vector3(4.5f, 0, 0), enemyBossTagName);
            chapter2Boss.AddComponent<Chapter2BossMove>();
            bossUnitCount += 1;
            enemyUnitCount += 1;
            
        }

        iidx = checkVoid.Count;
        EggManager.enemyEggManagers = EggManager.GetEggManagersByType<EnemyEggManager>();
        for (int i = 0; i < iidx; i++)
        {
            checkVoid.Remove(checkVoid[0]);
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
        iidx = HurdleSpawnPositions.Count;
        for (int i = 0; i < iidx; i++)
        {
            HurdleSpawnPositions.Remove(HurdleSpawnPositions[0]);
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (BattleReady.completeReady)
        {
            JudgeResult(8);
        }

        if (GameManager.isUserTurn && FindAllUserUnitFreeze() == UserEggManager.userEggManagers.Count && BattleReady.completeReady)
        {
            UnFreezeUserUnit();
            GameManager.isUserTurn = !GameManager.isUserTurn;
        }

    }
    public int FindAllUserUnitFreeze()
    {
        int count = 0;
        GameObject[] userUnits = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject userUnit in userUnits)
        {
            if (userUnit.GetComponent<UserEggManager>().state_Freeze && BattleReady.completeReady)
            {
                count++;
            }
        }
        return count;
    }

    public void UnFreezeUserUnit()
    {
        GameObject[] userUnits = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject userUnit in userUnits)
        {
            UserEggManager userEggManager = userUnit.GetComponent<UserEggManager>();
            if (userEggManager.state_Freeze && BattleReady.completeReady)
            {
                userEggManager.state_Freeze = !userEggManager.state_Freeze;
                Destroy(userEggManager.state_freeze);
                userEggManager.checkfreeze = !userEggManager.checkfreeze;
            }
        }
    }
}
