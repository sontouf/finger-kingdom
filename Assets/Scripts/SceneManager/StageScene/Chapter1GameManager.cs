using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter1GameManager : GameManager
{
    private const string greeneryPrefabPath = "Prefabs/Hurdles/GreeneryPrefab";
    private const string rock1PrefabPath = "Prefabs/Hurdles/Rock1Prefab";
    private const string rock2PrefabPath = "Prefabs/Hurdles/Rock2Prefab";
    private const string rock5PrefabPath = "Prefabs/Hurdles/Rock5Prefab";
    private const string signfabPath = "Prefabs/Hurdles/SignPrefab";




    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        GameObject greeneryPrefab = Resources.Load(greeneryPrefabPath) as GameObject;
        GameObject rock1Prefab = Resources.Load(rock1PrefabPath) as GameObject;
        GameObject rock2Prefab = Resources.Load(rock2PrefabPath) as GameObject;
        GameObject rock5Prefab = Resources.Load(rock5PrefabPath) as GameObject;
        GameObject signfab = Resources.Load(signfabPath) as GameObject;

        //=====================================================



        int idx = 0;
        for (int i = 0; i < HurdleSpawnPositions.Count; i++)
        {
            checkVoid.Add(i);
        }
        idx = Random.Range(0, checkVoid.Count);
        for(int i = 2; i > 0; i--)
        {
            Instantiate(greeneryPrefab, HurdleSpawnPositions[idx], Quaternion.identity);
            checkVoid.Remove(checkVoid[idx]);
            HurdleSpawnPositions.Remove(HurdleSpawnPositions[idx]);
            idx = Random.Range(0, checkVoid.Count);
        }
        for (int i = 2; i > 0; i--)
        {
            Instantiate(rock1Prefab, HurdleSpawnPositions[idx], Quaternion.identity);
            checkVoid.Remove(checkVoid[idx]);
            HurdleSpawnPositions.Remove(HurdleSpawnPositions[idx]);
            idx = Random.Range(0, checkVoid.Count);
        }
        for (int i = 1; i > 0; i--)
        {
            Instantiate(rock2Prefab, HurdleSpawnPositions[idx], Quaternion.identity);
            checkVoid.Remove(checkVoid[idx]);
            HurdleSpawnPositions.Remove(HurdleSpawnPositions[idx]);
            idx = Random.Range(0, checkVoid.Count);
        }
        for (int i = 1; i > 0; i--)
        {
            Instantiate(rock5Prefab, HurdleSpawnPositions[idx], Quaternion.identity);
            checkVoid.Remove(checkVoid[idx]);
            HurdleSpawnPositions.Remove(HurdleSpawnPositions[idx]);
            idx = Random.Range(0, checkVoid.Count);
        }
        for (int i = 1; i > 0; i--)
        {
            Instantiate(signfab, HurdleSpawnPositions[idx], Quaternion.identity);
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
        if (stageNumber == 4)
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
        if (stageNumber == 0)
        {
            idx = Random.Range(0, checkVoid.Count); // 여기서 랜덤성 부여
            for (int i = 2; i > 0; --i)
            {
                EggManager.CreateEgg<GoblinEgg>(EnemyEggSpawnPositions[idx], enemyEggTagName);
                checkVoid.Remove(checkVoid[idx]);
                EnemyEggSpawnPositions.Remove(EnemyEggSpawnPositions[idx]);
                idx = Random.Range(0, checkVoid.Count);
                enemyUnitCount += 1;
            }
        }


        else if (stageNumber == 1)
        {
            idx = Random.Range(0, checkVoid.Count); // 여기서 랜덤성 부여
            for (int i = 4; i > 0; --i)
            {
                EggManager.CreateEgg<GoblinEgg>(EnemyEggSpawnPositions[idx], enemyEggTagName);
                checkVoid.Remove(checkVoid[idx]);
                EnemyEggSpawnPositions.Remove(EnemyEggSpawnPositions[idx]);
                idx = Random.Range(0, checkVoid.Count);
                enemyUnitCount += 1;
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
            for (int i = 3; i > 0; --i)
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
            for (int i = 2; i > 0; --i)
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
            for (int i = 3; i > 0; --i)
            {
                EggManager.CreateEgg<WolfEgg>(EnemyEggSpawnPositions[idx], enemyEggTagName);
                EnemyEggSpawnPositions.Remove(EnemyEggSpawnPositions[idx]);
                checkVoid.Remove(checkVoid[idx]);
                idx = Random.Range(0, checkVoid.Count);
                enemyUnitCount += 1;
            }

            GameObject chapter1Boss = EggManager.CreateBossEgg<Chapter1Boss>(new Vector3(5.5f, 0, 0), enemyBossTagName);
            chapter1Boss.AddComponent<Chapter1BossMove>();
            bossUnitCount += 1;
            enemyUnitCount += 1;
        }

        iidx = checkVoid.Count;
        EggManager.enemyEggManagers = EggManager.GetEggManagersByType<EnemyEggManager>();
        for (int i = 0; i < iidx; i++)
        {
            checkVoid.Remove(checkVoid[0]);
        }
        //==================================================================================

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
            JudgeResult(4);
        }
    }
}
