using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter2Boss : EnemyEggManager
{

    public int pattern;
    public Vector3 force;
    public int phase2Damage;
    public int phase2Hp;
    // protected override를 추가해줘서 상속.
    protected override void Start()
    {
        phase2Hp = 700;
        maxHp = 400;
        base.Start();
        damage = 20; // 데미지도 변경.
        phase2Damage = 40;
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
        if (otherObject.CompareTag("Player"))
        {
            if (CompareTag("Boss") && GameManager.isUserTurn)
            {
                int iceDamage = damage * 2;
                if (otherEggManager.state_Freeze)
                {
                    otherEggManager.curHp -= iceDamage;
                }
                else
                {
                    otherEggManager.curHp -= damage;
                }
                otherObject.GetComponent<HpBarController>()
                    .SetHealth(otherEggManager.curHp, otherEggManager.maxHp);
                otherEggManager.state_Freeze = true;
            }
        }
    }
}
