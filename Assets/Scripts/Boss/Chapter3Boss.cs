using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter3Boss : EnemyEggManager
{

    public int pattern;
    public Vector3 force;
    // protected override를 추가해줘서 상속.
    protected override void Start()
    {
        maxHp = 1000;
        base.Start();
        damage = 25; // 데미지도 변경.
        rigidbody2D.drag = 5;
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
                otherEggManager.curHp -= damage;
                otherObject.GetComponent<HpBarController>()
                    .SetHealth(otherEggManager.curHp, otherEggManager.maxHp);
            }
        }
    }
}
