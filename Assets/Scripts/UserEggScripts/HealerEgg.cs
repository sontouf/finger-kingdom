using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerEgg : UserEggManager
{
    const string imagePath = "Images/healer"; // 원하는 스프라이트의 위치를 받아온다.
    static private Sprite image;
    public int heal;
    // protected override를 추가해줘서 상속.
    protected override void Start()
    {
        base.Start();
        image = Resources.Load<Sprite>(imagePath); // 스프라이트의 위치를 통해 받아온 스프라이트를 image에 저장해둔다.
        spriteRenderer.sprite = image; // 저장한 스프라이트를 실제 객체의 sprite로 전달.
        damage = 3; // 데미지도 변경.
        heal = 30;
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

        if (otherObject.tag == "Player")
        {
            if (this.gameObject.tag == "Player")
            otherEggManager.curHp += heal;
            otherObject.GetComponent<HpBarController>()
                .SetHealth(otherEggManager.curHp, otherEggManager.maxHp);
        }
        else if (otherObject.CompareTag("Enemy"))
        {
            if (this.gameObject.tag == "Player")
            {
                otherEggManager.curHp -= damage;
            }
            otherObject.GetComponent<HpBarController>()
                        .SetHealth(otherEggManager.curHp, otherEggManager.maxHp);
        }

    }
}
