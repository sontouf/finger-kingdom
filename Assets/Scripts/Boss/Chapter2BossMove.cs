using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Chapter2BossMove : MonoBehaviour
{
    const string audioAttackImpactPath = "Audio/Roaring";
    const string imagePath = "Images/Boss/Chapter2Boss_Phase2";
    const string bossEffectPath = "Prefabs/chapter2BossPhase2";

    GameObject bossEffect;
    private int checkOneMove;
    public int pattern;
    float Min;
    public Vector3 force;
    public GameObject[] players;
    public GameObject closestPlayer;
    public Vector3 pos;
    static public bool phase2 = false;
    public AudioClip audioSourceClip;
    public AudioSource audioSource;
    public GameObject shakeManager;

    bool checkPhase2;

    private void Start()
    {
        phase2 = false;
        checkOneMove = 1;
        shakeManager = GameObject.Find("Master");
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = 0.3f;
        audioSourceClip = Resources.Load(audioAttackImpactPath) as AudioClip;
        audioSource.clip = audioSourceClip;
        bossEffect = Resources.Load<GameObject>(bossEffectPath);
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
        if (phase2 && !checkPhase2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(imagePath);
            Instantiate(bossEffect,transform.position, Quaternion.identity);
            checkPhase2 = !checkPhase2;
        }
    }

    public void FindClosestPlayer()
    {
        pos = GameObject.FindGameObjectWithTag("Boss").transform.position;
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
        Chapter2BossPattern();
    }

    public void Chapter2BossPattern()
    {
        pattern = Random.Range(1, 31);
        Debug.Log("pattern" + pattern);

        if (pattern >= 1 && pattern < 20)
        {
            if (phase2)
            {
                Phase2();
                Invoke("Phase2", 0.5f);
            }
            else
            {
                Phase1();
            }
        }
        else if (pattern >=20 && pattern < 31)
        {
            Shout();
        }
        pattern = 0;
        checkOneMove = 1;
    }

    public void Phase1()
    {
        gameObject.GetComponent<Chapter2Boss>().MoveEgg(force * 10);
    }

    public void Phase2()
    {
        gameObject.GetComponent<Chapter2Boss>().damage = gameObject.GetComponent<Chapter2Boss>().phase2Damage;
        gameObject.GetComponent<Chapter2Boss>().MoveEgg(force * 10);
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
                    player.GetComponent<Rigidbody2D>().AddForce((targetPos - pos)* 100);
                    shakeManager.GetComponent<ShakeManager>().Shake();
                    audioSource.Play();
                    EggManager playerEggManager = player.GetComponent<EggManager>();
                    playerEggManager.curHp -= 15;
                    player.GetComponent<HpBarController>()
                    .SetHealth(playerEggManager.curHp, playerEggManager.maxHp);
                }
            }
        }
    }

}
