using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteGoblinEgg : EnemyEggManager
{
    const string imagePath = "Images/whiteGoblin"; // 원하는 스프라이트의 위치를 받아온다.
    static private Sprite image;

    // protected override를 추가해줘서 상속.
    protected override void Start()
    {
        maxHp = 150;
        base.Start();
        image = Resources.Load<Sprite>(imagePath); // 스프라이트의 위치를 통해 받아온 스프라이트를 image에 저장해둔다.
        spriteRenderer.sprite = image; // 저장한 스프라이트를 실제 객체의 sprite로 전달.
        damage = 20; // 데미지도 변경.
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
        if (otherObject.CompareTag("Player") && BattleReady.completeReady)
        {
            if (CompareTag("Enemy") && GameManager.isUserTurn)
            {
                int IceDamage = damage * 2;
                if (otherEggManager.state_Freeze)
                {
                    otherEggManager.curHp -= IceDamage;
                }
                else
                {
                    otherEggManager.curHp -= damage;
                }
                otherObject.GetComponent<HpBarController>()
                    .SetHealth(otherEggManager.curHp, otherEggManager.maxHp);
            }
        }
    }

    public override void DestroyEgg()
    {
        base.DestroyEgg();
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject yeti in enemys)
        {
            if (yeti.GetComponent<YetiEgg>() != null)
            {
                yeti.GetComponent<YetiEgg>().whiteGoblinDie++;
                yeti.GetComponent<YetiEgg>().checkWhiteGoblinDie = !yeti.GetComponent<YetiEgg>().checkWhiteGoblinDie;
            }
        }
    }
}
