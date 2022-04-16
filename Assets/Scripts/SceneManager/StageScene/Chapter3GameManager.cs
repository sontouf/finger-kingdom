using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter3GameManager : GameManager
{
    const string bossEffectPath = "Prefabs/chapter3BossComming";
    //private const string hurdlePrefabPath = "Prefabs/HurdlePrefab";
    //private const string trapPrefabPath = "Prefabs/TrapPrefab";

    GameObject bossEffect;

    // Start is called before the first frame update
    public bool bossWarning;
    protected override void Start()
    {
        bossWarning = false;
        base.Start();
        //hurdlePrefeb = Resources.Load(hurdlePrefabPath) as GameObject;
        //trapPrefeb = Resources.Load(trapPrefabPath) as GameObject;
        bossEffect = Resources.Load<GameObject>(bossEffectPath);

        // 위치랑 tag 이름 받아와서 egg 객체 생성, 자세한 내용은 eggmanager 참고.
        int idx = 0;
        if (stageNumber == 12)
        {
/*            EnemyEggSpawnPositions.Remove(p9);
            EnemyEggSpawnPositions.Remove(p10);
            EnemyEggSpawnPositions.Remove(p13);
            EnemyEggSpawnPositions.Remove(p14);*/
        }
        for (int i = 0; i < chapter3EnemySpawnPosition.Count; i++)
        {
            checkVoid.Add(i);
        }
        if (stageNumber == 9)
        {
            idx = Random.Range(0, checkVoid.Count);
            for (int i = 6; i > 0; --i)
            {
                EggManager.CreateEgg<PirateEgg>(chapter3EnemySpawnPosition[idx], enemyEggTagName);
                checkVoid.Remove(checkVoid[idx]);
                chapter3EnemySpawnPosition.Remove(chapter3EnemySpawnPosition[idx]);
                idx = Random.Range(0, checkVoid.Count);
                enemyUnitCount += 1;
            }
        }
        else if (stageNumber == 10)
        {
            idx = Random.Range(0, checkVoid.Count);
            for (int i = 3; i > 0; --i)
            {
                EggManager.CreateEgg<PirateEgg>(chapter3EnemySpawnPosition[idx], enemyEggTagName);
                checkVoid.Remove(checkVoid[idx]);
                chapter3EnemySpawnPosition.Remove(chapter3EnemySpawnPosition[idx]);
                idx = Random.Range(0, checkVoid.Count);
                enemyUnitCount += 1;
            }

            idx = Random.Range(0, checkVoid.Count);
            for (int i = 3; i > 0; --i)
            {
                EggManager.CreateEgg<SkeletonEgg>(chapter3EnemySpawnPosition[idx], enemyEggTagName);
                checkVoid.Remove(checkVoid[idx]);
                chapter3EnemySpawnPosition.Remove(chapter3EnemySpawnPosition[idx]);
                idx = Random.Range(0, checkVoid.Count);
                enemyUnitCount += 1;
            }
            idx = Random.Range(0, checkVoid.Count);
            for (int i = 2; i > 0; --i)
            {
                EggManager.CreateEgg<RopeManEgg>(chapter3EnemySpawnPosition[idx], enemyEggTagName);
                chapter3EnemySpawnPosition.Remove(chapter3EnemySpawnPosition[idx]);
                checkVoid.Remove(checkVoid[idx]);
                idx = Random.Range(0, checkVoid.Count);
                enemyUnitCount += 1;
            }
        }
        else if (stageNumber == 11)
        {
            idx = Random.Range(0, checkVoid.Count);
            for (int i = 2; i > 0; --i)
            {
                EggManager.CreateEgg<PirateEgg>(chapter3EnemySpawnPosition[idx], enemyEggTagName);
                chapter3EnemySpawnPosition.Remove(chapter3EnemySpawnPosition[idx]);
                checkVoid.Remove(checkVoid[idx]);
                idx = Random.Range(0, checkVoid.Count);
                enemyUnitCount += 1;
            }

            idx = Random.Range(0, checkVoid.Count);
            for (int i = 3; i > 0; --i)
            {
                EggManager.CreateEgg<SkeletonEgg>(chapter3EnemySpawnPosition[idx], enemyEggTagName);
                chapter3EnemySpawnPosition.Remove(chapter3EnemySpawnPosition[idx]);
                checkVoid.Remove(checkVoid[idx]);
                idx = Random.Range(0, checkVoid.Count);
                enemyUnitCount += 1;
            }

            idx = Random.Range(0, checkVoid.Count);
            for (int i = 6; i > 0; --i)
            {
                EggManager.CreateEgg<RopeManEgg>(chapter3EnemySpawnPosition[idx], enemyEggTagName);
                chapter3EnemySpawnPosition.Remove(chapter3EnemySpawnPosition[idx]);
                checkVoid.Remove(checkVoid[idx]);
                idx = Random.Range(0, checkVoid.Count);
                enemyUnitCount += 1;
            }
        }
        else if (stageNumber == 12)
        {

            idx = Random.Range(0, checkVoid.Count);
            for (int i = 3; i > 0; --i)
            {
                EggManager.CreateEgg<PirateEgg>(chapter3EnemySpawnPosition[idx], enemyEggTagName);
                chapter3EnemySpawnPosition.Remove(chapter3EnemySpawnPosition[idx]);
                checkVoid.Remove(checkVoid[idx]);
                idx = Random.Range(0, checkVoid.Count);
                enemyUnitCount += 1;
            }

            idx = Random.Range(0, checkVoid.Count);
            for (int i = 2; i > 0; --i)
            {
                EggManager.CreateEgg<SkeletonEgg>(chapter3EnemySpawnPosition[idx], enemyEggTagName);
                chapter3EnemySpawnPosition.Remove(chapter3EnemySpawnPosition[idx]);
                checkVoid.Remove(checkVoid[idx]);
                idx = Random.Range(0, checkVoid.Count);
                enemyUnitCount += 1;
            }


            idx = Random.Range(0, checkVoid.Count);
            for (int i = 2; i > 0; --i)
            {
                EggManager.CreateEgg<RopeManEgg>(chapter3EnemySpawnPosition[idx], enemyEggTagName);
                chapter3EnemySpawnPosition.Remove(chapter3EnemySpawnPosition[idx]);
                checkVoid.Remove(checkVoid[idx]);
                idx = Random.Range(0, checkVoid.Count);
                enemyUnitCount += 1;
            }
        }

        int iidx = checkVoid.Count;
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
        iidx = chapter3EnemySpawnPosition.Count;
        for (int i = 0; i < iidx; i++)
        {
            chapter3EnemySpawnPosition.Remove(chapter3EnemySpawnPosition[0]);
        }
        iidx = HurdleSpawnPositions.Count;
        for (int i = 0; i < iidx; i++)
        {
            HurdleSpawnPositions.Remove(HurdleSpawnPositions[0]);
        }
    }
    public void CreateChapter3Boss()
    {
        GameObject boss= EggManager.CreateBossEgg<Chapter3Boss>(new Vector3(0, 0, 0), enemyBossTagName);
        boss.AddComponent<Chapter3BossMove>();

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (BattleReady.completeReady && EnemyEggManager.enemyEggManagers.Count == 0 && bossUnitCount == 0 && stageNumber == 12 && !bossWarning)
        {
            Instantiate(bossEffect, Vector3.zero, Quaternion.identity);
            Invoke("CreateChapter3Boss", 2f);
            bossUnitCount += 1;
            enemyUnitCount += 1;

            for (int i = 3; i > 0; --i)
            {
                EggManager.CreateEgg<PirateEgg>(new Vector3(5, 4, 0), enemyEggTagName);
                enemyUnitCount += 1;
            }
            for (int i = 2; i > 0; --i)
            {
                EggManager.CreateEgg<RopeManEgg>(new Vector3(-5, -4, 0), enemyEggTagName);
                enemyUnitCount += 1;
            }
            EggManager.enemyEggManagers = EggManager.GetEggManagersByType<EnemyEggManager>();
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            if (players != null)
            {
                foreach (GameObject player in players)
                {
                    Vector3 pos = player.transform.position - transform.position;
                    Vector3 targetPos = pos.normalized * 20;
                    if (pos.x / pos.normalized.x < 8)
                    {
                        player.GetComponent<Rigidbody2D>().AddForce((targetPos - pos) * 100);
                        EggManager playerEggManager = player.GetComponent<EggManager>();
                        playerEggManager.curHp -= 20;
                        player.GetComponent<HpBarController>()
                        .SetHealth(playerEggManager.curHp, playerEggManager.maxHp);
                    }
                }
            }
            bossWarning = !bossWarning;

        }
        else if (BattleReady.completeReady && bossWarning)
        {
            JudgeResult(12);
        }
        else if (BattleReady.completeReady && stageNumber != 12)
        {
            JudgeResult(12);
        }
    }
}
