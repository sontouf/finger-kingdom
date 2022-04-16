using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter4GameManager : GameManager
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        GameObject chapter4Boss = EggManager.CreateBossEgg<Chapter4Boss>(new Vector3(4.5f, 0, 0), enemyBossTagName);
        chapter4Boss.AddComponent<Chapter4BossMove>();
        bossUnitCount += 1;
        enemyUnitCount += 1;
    
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
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (BattleReady.completeReady)
        {
            JudgeResult(13);
        }
    }
}
