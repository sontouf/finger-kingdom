using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Chapter1Boss : EnemyEggManager
{
    static public GameObject chapter1BossApplePrefab;
    public int pattern;
    public Vector3 force;


    // protected override를 추가해줘서 상속.
    protected override void Start()
    {
        maxHp = 700;
        base.Start();
    }

    // protected override를 추가해줘서 상속.
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }


}
