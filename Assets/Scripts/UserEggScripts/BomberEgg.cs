using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberEgg : UserEggManager
{
    const string cannonBallEffectPath = "Prefabs/CannonBomb";
    const string imagePath = "Images/bomber"; // 원하는 스프라이트의 위치를 받아온다.

    static private Sprite image;
    float distancd;
    GameObject cannonBallEffect;
    // protected override를 추가해줘서 상속.
    protected override void Start()
    {
        maxHp = 1;
        base.Start();
        image = Resources.Load<Sprite>(imagePath); // 스프라이트의 위치를 통해 받아온 스프라이트를 image에 저장해둔다.
        spriteRenderer.sprite = image; // 저장한 스프라이트를 실제 객체의 sprite로 전달.
        damage = 150;
        speed = 100;
        heal = 0;
        cost = 3;
        rigidbody2D.mass = 2;
        gameObject.name = "Bomber";
        cannonBallEffect = Resources.Load<GameObject>(cannonBallEffectPath);
    }

    // protected rverride를 추가해줘서 상속.
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void DestroyEgg()
    {
        Instantiate(cannonBallEffect, transform.position, Quaternion.identity);
        base.DestroyEgg();

    }

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        base.OnCollisionEnter2D(other);
        GameObject otherObject = other.gameObject;
        EggManager otherEggManager = otherObject.GetComponent<EggManager>();
        if ((otherObject.CompareTag("Enemy") || otherObject.CompareTag("Boss") ) && BattleReady.completeReady)
        {
            if (CompareTag("Player") && otherEggManager != null)
            {
                otherEggManager.curHp -= damage;
                otherObject.GetComponent<HpBarController>()
                        .SetHealth(otherEggManager.curHp, otherEggManager.maxHp);
                foreach (EnemyEggManager otherEnemyEggManager in EnemyEggManager.enemyEggManagers)
                {
                    if (otherEnemyEggManager.gameObject != other.gameObject)
                    {
                        GameObject otherEnemy = otherEnemyEggManager.gameObject;
                        distancd = Vector2.Distance(otherEnemy.transform.position, transform.position);
                        if (distancd <= 1.5)
                        {
                            otherEnemy.GetComponent<EggManager>().curHp -= 50;
                            otherEnemy.GetComponent<HpBarController>()
                                    .SetHealth(otherEnemyEggManager.curHp, otherEnemyEggManager.maxHp);
                            Vector2 force = otherEnemy.transform.position - transform.position;
                            otherEnemy.GetComponent<Rigidbody2D>().AddForce(force * 30);
                        }
                    }
                }

                Instantiate(cannonBallEffect, transform.position, Quaternion.identity);
                DestroyEgg();
            }
        }
/*        if (otherObject.CompareTag("Hurdle"))
        {
            Destroy(other.gameObject);
        }*/
        
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
