using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CavalryEgg : UserEggManager
{
    const string imagePath = "Images/cavalry"; // 원하는 스프라이트의 위치를 받아온다.
    static private Sprite image;

    // protected override를 추가해줘서 상속.
    protected override void Start()
    {
        base.Start();
        image = Resources.Load<Sprite>(imagePath); // 스프라이트의 위치를 통해 받아온 스프라이트를 image에 저장해둔다.
        spriteRenderer.sprite = image; // 저장한 스프라이트를 실제 객체의 sprite로 전달.
        damage = 15; // 데미지도 변경.
    }

    // protected override를 추가해줘서 상속.
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
        if (otherObject.CompareTag("Enemy"))
        {
            if (CompareTag("Player") && !GameManager.isUserTurn && otherEggManager != null)
            {
                otherEggManager.curHp -= damage;
                otherObject.GetComponent<HpBarController>()
                        .SetHealth(otherEggManager.curHp, otherEggManager.maxHp);
            }
        }
    }
}
