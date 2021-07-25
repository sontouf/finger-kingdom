﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorEgg : EggManager  // warrior는 eggmanager의 정보를 상속받는다.
{

    const string imagePath = "Images/warrior"; // 원하는 스프라이트의 위치를 받아온다.
    static private Sprite image;

    // protected override를 추가해줘서 상속.
    protected override void Start()
    {
        base.Start();
        image = Resources.Load<Sprite>(imagePath); // 스프라이트의 위치를 통해 받아온 스프라이트를 image에 저장해둔다.
        spriteRenderer.sprite = image; // 저장한 스프라이트를 실제 객체의 sprite로 전달.
        damage = 15; // 데미지도 변경.
    }

    // protected rverride를 추가해줘서 상속.
    protected override void Update()
    {
        base.Update();
    }
}

