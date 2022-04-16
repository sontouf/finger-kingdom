using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PaladinEgg : UserEggManager
{
    const string imagePath = "Images/paladin"; // 원하는 스프라이트의 위치를 받아온다.
    const string healEffectPath = "Prefabs/HealEffect";
    static private Sprite image;
    public GameObject[] players;
    public GameObject targetPlayer;
    public int userUnitIndex;
    public int MinHp = 1000;
    private int hp;
    GameObject healEffect;
    // protected override를 추가해줘서 상속.
    protected override void Start()
    {
        maxHp = 500;
        base.Start();
        image = Resources.Load<Sprite>(imagePath); // 스프라이트의 위치를 통해 받아온 스프라이트를 image에 저장해둔다.
        spriteRenderer.sprite = image; // 저장한 스프라이트를 실제 객체의 sprite로 전달.
        damage = 50;
        speed = 100;
        heal = 25;
        cost = 6;
        healEffect = Resources.Load<GameObject>(healEffectPath);
        rigidbody2D.mass = 3;
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
        int damageOrigin = damage;
        if ((otherObject.CompareTag("Enemy") || otherObject.CompareTag("Boss")) && BattleReady.completeReady)
        {
            if (!GameManager.isUserTurn && otherEggManager != null)
            {
                otherEggManager.curHp -= damage;
                heal += 5;
                damage = damageOrigin;
                otherObject.GetComponent<HpBarController>()
                        .SetHealth(otherEggManager.curHp, otherEggManager.maxHp);
                if (otherEggManager.curHp <= 0 || otherObject == null)
                {
                    MinHp = 1000;
                    HealPlayer();
                }
            }
        }
    }

    public void HealPlayer()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        if (players != null)
        {
            foreach (GameObject player in players)
            {
                hp = player.GetComponent<UserEggManager>().curHp;
                if (hp < MinHp)
                {
                    MinHp = hp;
                    targetPlayer = player;
                }
            }
        }
        Instantiate(healEffect, targetPlayer.transform.position, Quaternion.identity);
        EggManager targetEggManager = targetPlayer.GetComponent<EggManager>();
        targetPlayer.GetComponent<EggManager>().curHp += heal;
        targetPlayer.GetComponent<HpBarController>()
            .SetHealth(targetEggManager.curHp, targetEggManager.maxHp);
    }

}
