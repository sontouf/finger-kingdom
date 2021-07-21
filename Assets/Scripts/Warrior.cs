using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : EggManager
{

    const string imagePath = "Images/Sun";
    static private Sprite image;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        image = Resources.Load<Sprite>(imagePath);
        spriteRenderer.sprite = image;
        damage = 15;
    }

    protected override void Update()
    {
        base.Update();
    }
}

