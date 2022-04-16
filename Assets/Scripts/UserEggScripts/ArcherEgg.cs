using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArcherEgg : UserEggManager, IEndDragHandler  // warrior는 eggmanager의 정보를 상속받는다.
{

    const string imagePath = "Images/archer"; // 원하는 스프라이트의 위치를 받아온다.


    private float arrowSpeed;
    static private Sprite image;
    // protected override를 추가해줘서 상속.
    protected override void Start()
    {
        maxHp = 70;
        base.Start();
        image = Resources.Load<Sprite>(imagePath); // 스프라이트의 위치를 통해 받아온 스프라이트를 image에 저장해둔다.
        spriteRenderer.sprite = image; // 저장한 스프라이트를 실제 객체의 sprite로 전달.
        rigidbody2D.mass = 1f;
        speed = 10;
        damage = 5; // 데미지도 변경.
        arrowSpeed = 300;
        heal = 0;
        cost = 2;
        gameObject.name = "Archer";
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
        if ((otherObject.CompareTag("Enemy")|| otherObject.CompareTag("Boss")) && BattleReady.completeReady)
        {
            if (CompareTag("Player") && !GameManager.isUserTurn && otherEggManager != null)
            {
                otherEggManager.curHp -= damage;
                otherObject.GetComponent<HpBarController>()
                        .SetHealth(otherEggManager.curHp, otherEggManager.maxHp);
            }
        }
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        GameObject arrow = Archer_arrow.CreateArrow(GetComponent<Rigidbody2D>().position, direction);
        arrow.GetComponent<Archer_arrow>().ShotArrow(arrowSpeed, force);
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

