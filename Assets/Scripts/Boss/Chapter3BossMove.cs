using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter3BossMove : MonoBehaviour
{
    private int checkOneMove;
    public int pattern;
    float Min;
    public Vector3 force;
    public GameObject[] players;
    public GameObject closestPlayer;
    public GameObject closestEnemy;
    public Vector3 pos;
    public int speed = 100;
    public int ropeSpeed = 150;
    public int bulletSpeed = 200;
    static public bool phase2 = false;
    int absorbCount;

    private void Start()
    {
        checkOneMove = 1;
        absorbCount = 2;
    }

    private void Update()
    {
        if (EnemyEggManager.enemyEggManagers.Count > 0 && !GameManager.isUserTurn && checkOneMove == 1)
        {
            checkOneMove = 0;
            Min = 999999;
            if (GameObject.FindGameObjectWithTag("Boss") != null)
            {
                Invoke("FindClosestPlayer", 1.5f);
            }
        }
    }

    public void FindClosestPlayer()
    {
        pos = transform.position;
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            float distance = Vector2.Distance(pos, player.transform.position);
            if (distance < Min)
            {
                Min = distance;
                closestPlayer = player;
            }
        }
        if (closestPlayer != null)
        {
            force = closestPlayer.transform.position - pos;
        }
        Chapter3BossPattern();
    }

    public void Chapter3BossPattern()
    {
        pattern = Random.Range(1, 101);
        float num = (float)GetComponent<Chapter3Boss>().curHp / (float)GetComponent<Chapter3Boss>().maxHp;
        if (num < 0.3)
        {
            Absorb();
        }

        if (pattern >= 1 && pattern < 21)
        {
            HookPull();
        }
        else if (pattern >= 21 && pattern < 71)
        {
           BossMove();
        }
        else if (pattern >= 71 && pattern < 91)
        {
            ShotGun();
        }
        else if (pattern >= 91 && pattern < 101)
        {
            AllPlayerEggPull();
        }
        pattern = 0;
        checkOneMove = 1;
    }


    public void Absorb()
    {
        int percentage = Random.Range(0, 50);
        if (absorbCount > 0 && BattleReady.completeReady && percentage > 25 )
        {
            GameObject[] absorbTargets = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject absorbTarget in absorbTargets)
            {
                float distance = Vector2.Distance(pos, absorbTarget.transform.position);
                if (distance < Min)
                {
                    Min = distance;
                    closestEnemy = absorbTarget;
                }
            }
            if (closestEnemy != null)
            {
                float distance = Vector2.Distance(pos, closestEnemy.transform.position);
                if (distance < 15)
                {
                    closestEnemy.GetComponent<Rigidbody2D>().position = transform.position;
                    closestEnemy.GetComponent<EggManager>().DestroyEgg();
                    GetComponent<Chapter3Boss>().curHp += 60;
                    if (GetComponent<Chapter3Boss>().curHp > GetComponent<Chapter3Boss>().maxHp)
                    {
                        GetComponent<Chapter3Boss>().curHp = GetComponent<Chapter3Boss>().maxHp;
                    }
                    GetComponent<HpBarController>()
                        .SetHealth(GetComponent<Chapter3Boss>().curHp, GetComponent<Chapter3Boss>().maxHp);
                    absorbCount--;
                }
                else
                {
                    Vector2 force = closestPlayer.transform.position - pos;
                    GetComponent<Rigidbody2D>().AddForce(speed * force);
                }
            }
        }
    }
    public void BossMove()
    {
        gameObject.GetComponent<Chapter3Boss>().MoveEgg(force.normalized * speed );
    }
    public void ShotGun()
    {
        for (int i = -1; i < 2; i++)
        {
            GameObject bullet = Chapter3BossShot.CreateBullet(GetComponent<Rigidbody2D>().position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().AddForce(bulletSpeed * (force.normalized + new Vector3(0, i * 0.3f, 0)));
        }
    }
    public void AllPlayerEggPull()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if (players != null)
        {
            foreach (GameObject player in players)
            {
                Vector2 foorce = player.transform.position - transform.position;
                float z = Mathf.Atan2(foorce.y, foorce.x) * Mathf.Rad2Deg;
                Quaternion direction = Quaternion.Euler(0, 0, 90 + z);
                GameObject rope = Chapter3BossRope.CreateRope(GetComponent<Rigidbody2D>().position, direction);
                rope.GetComponent<Chapter3BossRope>().ShotRope(ropeSpeed, foorce);
            }
        }
    }
    public void HookPull()
    {
        float z = Mathf.Atan2(force.y, force.x) * Mathf.Rad2Deg;
        Quaternion direction = Quaternion.Euler(0, 0, 90 + z);
        GameObject rope = Chapter3BossRope.CreateRope(GetComponent<Rigidbody2D>().position, direction);
        rope.GetComponent<Chapter3BossRope>().ShotRope(ropeSpeed, force);
    }



}
