using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CannonEgg : UserEggManager, IEndDragHandler
{
    const string imagePath = "Images/cannon"; // 원하는 스프라이트의 위치를 받아온다.
    static private Sprite image;
    private int cannonBallSpeed;

    // protected override를 추가해줘서 상속.
    protected override void Start()
    {
        maxHp = 150;
        base.Start();
        image = Resources.Load<Sprite>(imagePath); // 스프라이트의 위치를 통해 받아온 스프라이트를 image에 저장해둔다.
        spriteRenderer.sprite = image; // 저장한 스프라이트를 실제 객체의 sprite로 전달.
        damage = 0;
        speed = 0;
        heal = 0;
        cost = 3;
        rigidbody2D.mass = 3;
        cannonBallSpeed = 100;
        gameObject.name = "Cannon";
    }

    // protected rverride를 추가해줘서 상속.
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }


    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        GameObject cannonBall = Cannon_ball.CreateCannonBall(GetComponent<Rigidbody2D>().position, direction);
        cannonBall.GetComponent<Cannon_ball>().ShotCannonBall(cannonBallSpeed, force);
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
