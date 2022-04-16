using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodFenceEgg : UserEggManager
{
    const string imagePath = "Images/woodFence"; // 원하는 스프라이트의 위치를 받아온다.
    static private Sprite image;

    // protected override를 추가해줘서 상속.
    protected override void Start()
    {
        maxHp = 150;
        base.Start();
        image = Resources.Load<Sprite>(imagePath); // 스프라이트의 위치를 통해 받아온 스프라이트를 image에 저장해둔다.
        spriteRenderer.sprite = image; // 저장한 스프라이트를 실제 객체의 sprite로 전달.
        damage = 0;
        speed = 100;
        heal = 0;
        cost = 1;
        rigidbody2D.mass = 3;
        gameObject.layer = 12;
        rigidbody2D.drag = 10;
    }

    // protected rverride를 추가해줘서 상속.
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
