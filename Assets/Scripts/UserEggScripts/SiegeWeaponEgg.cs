using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiegeWeaponEgg : UserEggManager
{
    const string imagePath = "Images/siegeWeapon"; // 원하는 스프라이트의 위치를 받아온다.
    static private Sprite image;

    // protected override를 추가해줘서 상속.
    protected override void Start()
    {
        maxHp = 250;
        base.Start();
        image = Resources.Load<Sprite>(imagePath); // 스프라이트의 위치를 통해 받아온 스프라이트를 image에 저장해둔다.
        spriteRenderer.sprite = image; // 저장한 스프라이트를 실제 객체의 sprite로 전달.
        damage = 20; // 데미지도 변경.
        speed = 70;
        heal = 0;
        cost = 3;

        rigidbody2D.mass = 5;
    }

    // protected rverride를 추가해줘서 상속.
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        base.OnCollisionEnter2D(other);
        GameObject otherObject = other.gameObject;
        EggManager otherEggManager = otherObject.GetComponent<EggManager>();
        /*        if (otherObject.CompareTag("Trap"))
                {
                    DestroyEgg(this);
                }*/
        if ((otherObject.CompareTag("Enemy") || otherObject.CompareTag("Boss")) && BattleReady.completeReady)
        {
            if (CompareTag("Player") && !GameManager.isUserTurn && otherEggManager != null)
            {
                otherEggManager.curHp -= damage;
                otherObject.GetComponent<HpBarController>()
                        .SetHealth(otherEggManager.curHp, otherEggManager.maxHp);
            }
        }
        if (otherObject.CompareTag("Hurdle") && BattleReady.completeReady)
        {
            Destroy(otherObject);
        }

    }

    public int GetHp()
    {
        return maxHp;
    }
    public int GetDamage()
    {
        return damage;
    }

    public int GetSpeed()
    {
        return speed;
    }
    public float GetMass()
    {
        return rigidbody2D.mass;
    }
    public int GetHeal()
    {
        return heal;
    }
    public int GetCost()
    {
        return cost;
    }
}
