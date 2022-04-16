using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeManEgg : EnemyEggManager
{
    const string imagePath = "Images/ropeMan"; // 원하는 스프라이트의 위치를 받아온다.
    static private Sprite image;
    private Vector3 scaleChage;
    static public int ropeSpeed;
    // protected override를 추가해줘서 상속.
    protected override void Start()
    {
        ropeSpeed = 500;
        maxHp = 200;
        base.Start();
        image = Resources.Load<Sprite>(imagePath); // 스프라이트의 위치를 통해 받아온 스프라이트를 image에 저장해둔다.
        spriteRenderer.sprite = image; // 저장한 스프라이트를 실제 객체의 sprite로 전달.
        damage = 30; // 데미지도 변경.
        speed = 100;
        rigidbody2D.mass = 5;
        rigidbody2D.drag = 10;
        gameObject.name = "RopeMan";
    }

    // protected override를 추가해줘서 상속.
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        GameObject otherObject = other.gameObject;
        UserEggManager otherEggManager = otherObject.GetComponent<UserEggManager>();
        /*        if (otherObject.CompareTag("Trap"))
                {
                    DestroyEgg(this);
                }*/
        if (otherObject.CompareTag("Player") && BattleReady.completeReady)
        {
            if (CompareTag("Enemy") && GameManager.isUserTurn)
            {
                otherEggManager.curHp -= damage;
                otherObject.GetComponent<HpBarController>()
                    .SetHealth(otherEggManager.curHp, otherEggManager.maxHp);
            }
        }
    }
}
