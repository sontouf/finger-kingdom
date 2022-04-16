using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealerEgg : UserEggManager
{
    const string imagePath = "Images/healer"; // 원하는 스프라이트의 위치를 받아온다.
    const string woodFenceImagePath = "Images/woodFence";
    const string siegeWeaponImagePath = "Images/siegeWeapon";
    const string healEffectPath = "Prefabs/HealEffect";

    static private Sprite image;
    private Sprite woodFenceImage;
    private Sprite siegeWeaponImage;
    GameObject healEffect;
    // protected override를 추가해줘서 상속.
    protected override void Start()
    {
        base.Start();
        image = Resources.Load<Sprite>(imagePath); // 스프라이트의 위치를 통해 받아온 스프라이트를 image에 저장해둔다.
        woodFenceImage = Resources.Load<Sprite>(woodFenceImagePath);
        siegeWeaponImage = Resources.Load<Sprite>(siegeWeaponImagePath);
        healEffect = Resources.Load<GameObject>(healEffectPath);

        spriteRenderer.sprite = image; // 저장한 스프라이트를 실제 객체의 sprite로 전달.
        damage = 5;
        speed = 60;
        heal = 40;
        cost = 4;
        rigidbody2D.mass = 2;
        gameObject.name = "Healer";
    }

    // protected override를 추가해줘서 상속.
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    private new void OnCollisionEnter2D(Collision2D other)
    {
        GameObject otherObject = other.gameObject;
        EggManager otherEggManager = otherObject.GetComponent<EggManager>();

        if (otherObject.tag == "Player" && BattleReady.completeReady)
        {
            Instantiate(healEffect, other.transform.position, Quaternion.identity);
            otherEggManager.curHp += heal;
            if (otherEggManager.curHp > otherEggManager.maxHp)
            {
                otherEggManager.curHp = otherEggManager.maxHp;
            }
            otherObject.GetComponent<HpBarController>()
                .SetHealth(otherEggManager.curHp, otherEggManager.maxHp);
        }
        else if ((otherObject.CompareTag("Enemy") || otherObject.CompareTag("Boss")) && BattleReady.completeReady)
        {
            otherEggManager.curHp -= damage;
            otherObject.GetComponent<HpBarController>()
                        .SetHealth(otherEggManager.curHp, otherEggManager.maxHp);
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
