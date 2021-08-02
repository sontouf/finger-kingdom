using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class EnemyEggManager : EggManager
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        this.gameObject.layer = 9;

    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

    }

    protected override void DestroyEgg()
    {
        enemyEggManagers.Remove(this);
        base.DestroyEgg();
    }
}
