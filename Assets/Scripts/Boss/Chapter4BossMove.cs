using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter4BossMove : MonoBehaviour
{
    const string chapter4HurdlePrefabPath = "Prefabs/Hurdles/chapter4BossHurdlePrefab";

    const string audioAttackImpactPath = "Audio/roaring";
    public AudioClip audioSourceClip;
    public AudioSource audioSource;
    public GameObject shakeManager;

    private int checkOneMove;
    public int pattern;
    float Min;
    public Vector3 force;
    public GameObject[] players;
    public GameObject closestPlayer;
    public GameObject closestEnemy;
    public Vector3 pos;
    public int speed = 150;
    public int ropeSpeed = 150;
    public int bulletSpeed = 700;
    static public bool phase2 = false;
    int absorbCount;

    GameObject chapter4BossHurdle;

    private void Start()
    {
        shakeManager = GameObject.Find("Master");
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = 0.3f;
        audioSourceClip = Resources.Load(audioAttackImpactPath) as AudioClip;
        audioSource.clip = audioSourceClip;
        checkOneMove = 1;
        absorbCount = 2;
        chapter4BossHurdle = Resources.Load<GameObject>(chapter4HurdlePrefabPath);
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
        Chapter4BossPattern();
    }

    public void Chapter4BossPattern()
    {
        pattern = Random.Range(1, 101);

        if (pattern >= 1 && pattern < 18)
        {
            Shout();
        }
        else if (pattern >= 18 && pattern < 70)
        {
            BossMove();
            Invoke("BossMove", 1f);
        }
        else if (pattern >= 70 && pattern < 81)
        {
            ShotGun();
        }
        else if (pattern >= 81 && pattern < 101)
        {
            AllPlayerEggPull();
        }
        pattern = 0;
        checkOneMove = 1;
        GameManager.isUserTurn = !GameManager.isUserTurn;
    }



    public void BossMove()
    {
        Instantiate(chapter4BossHurdle, transform.position, Quaternion.identity);
        gameObject.GetComponent<Chapter4Boss>().MoveEgg(force.normalized * speed);


    }
    public void ShotGun()
    {
        for (int i = -1; i < 10; i++)
        {
            GameObject bullet = Chapter4BossShot.CreateBullet(GetComponent<Rigidbody2D>().position, Quaternion.identity);
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
                GameObject rope = Chapter4BossRope.CreateRope(GetComponent<Rigidbody2D>().position, direction);
                rope.GetComponent<Chapter4BossRope>().ShotRope(ropeSpeed, foorce);
            }
        }
    }

    public void Shout()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if (players != null)
        {
            foreach (GameObject player in players)
            {
                Vector3 pos = player.transform.position - transform.position;
                Vector3 targetPos = pos.normalized * 20;
                if (pos.x / pos.normalized.x < 8)
                {
                    Vector3 poppo = targetPos - pos;
                    player.GetComponent<Rigidbody2D>().AddForce((targetPos - pos) * 100);
                    shakeManager.GetComponent<ShakeManager>().Shake();
                    audioSource.Play();
                    EggManager playerEggManager = player.GetComponent<EggManager>();
                    playerEggManager.curHp -= 20;
                    player.GetComponent<HpBarController>()
                    .SetHealth(playerEggManager.curHp, playerEggManager.maxHp);
                }
            }
        }
    }
    public void Summon()
    {

    }

}
