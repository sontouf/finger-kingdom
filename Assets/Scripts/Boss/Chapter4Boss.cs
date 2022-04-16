using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter4Boss : EnemyEggManager
{
    const string bossEffectPath = "Prefabs/chapter4BossMoveEffect";

    GameObject bossEffect;

    public int pattern;
    public Vector3 force;
    // protected override를 추가해줘서 상속.
    protected override void Start()
    {
        maxHp = 2500;
        base.Start();
        damage = 50; // 데미지도 변경.
        rigidbody2D.drag = 5;
        bossEffect = Resources.Load<GameObject>(bossEffectPath);
    }

    // protected override를 추가해줘서 상속.
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject otherObject = other.gameObject;
        UserEggManager otherEggManager = otherObject.GetComponent<UserEggManager>();
        if (otherObject.CompareTag("Player") && GameManager.isUserTurn)
        {
            if (GameManager.isUserTurn)
            {
                Instantiate(bossEffect, other.transform.position, Quaternion.identity);
                otherEggManager.curHp -= damage;
                otherObject.GetComponent<HpBarController>()
                    .SetHealth(otherEggManager.curHp, otherEggManager.maxHp);
                otherEggManager.state_Curse = true;
                if (otherEggManager.curHp <= 0 || otherObject == null)
                {
                    curHp += 35;
                    if (curHp > maxHp){
                        curHp = maxHp;
                    }
                    otherObject.GetComponent<HpBarController>()
    .SetHealth(otherEggManager.curHp, otherEggManager.maxHp);
                }
            }
        }
    }
}
