using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Chapter1Boss : MonoBehaviour
{

    const string chapter1BossPrefabPath = "Prefabs/Boss/Chapter1BossPrefab";
    const string chapter1BossApplePrefabPath = "Prefabs/Boss/Chapter1BossApplePrefab";

    static public GameObject chapter1BossApplePrefab;
    static public GameObject chapter1BossPrefab;
    public float appleSpeed;
    private bool checkOneMove = true;
    public GameObject[] players;
    public GameObject closestPlayer;
    public int pattern;
    public Vector3 force;

     static public void CreateBoss(Vector3 position, string tagName)
    {

        chapter1BossPrefab = Resources.Load(chapter1BossPrefabPath) as GameObject;
        // 객체 생성
        GameObject newBossObject =
            Instantiate(chapter1BossPrefab, position, Quaternion.identity);
        newBossObject.tag = tagName;
        newBossObject.AddComponent<Chapter1Boss>();
    }


    // eggManager의 eggManagers에 접근하여 객체를 하나 소멸시킨다. 
    // 소멸될때 이펙트 추가해도 좋다.
    protected virtual void DestroyEgg()
    {
        Destroy(gameObject); // 게임세상 내 객체를 소멸시킨다.
    }


    private void Start()
    {
        appleSpeed = 100;
    }


    // Update is called once per frame
    private void Update()
    {
/*        if (checkOneMove)
        {
            Invoke("treePattern", 2.5f);
            checkOneMove = !checkOneMove;
        }*/
        if (checkOneMove == true)
        {
            Invoke("treePattern",4f);
            checkOneMove = !checkOneMove;
        }
        if (GameManager.enemyUnitCount == 1 && GameManager.isUserTurn == false)
        {
            GameManager.isUserTurn = !GameManager.isUserTurn;
        }
        if (transform.position.x > 7.3 || transform.position.x < -7.3 || transform.position.y > 4.0 || transform.position.y < -4.0)
        {
            DestroyEgg();
            GameManager.bossUnitCount -= 1;
        }
        FindClosestPlayer();
    }

    public void FindClosestPlayer()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        float Min = 999999;
        foreach (GameObject player in players)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance < Min)
            {
                Min = distance;
                closestPlayer = player;
            }
        }
        if (closestPlayer != null)
        {
            force = closestPlayer.transform.position - transform.position;
        }
    }

    public void treePattern()
    {
        pattern = UnityEngine.Random.Range(1, 3);
        Debug.Log("pattern" + pattern);
        if (pattern == 0)
        {
            
        }
        else if (pattern == 1)
        {
            appleShot1();
        }
        else if (pattern == 2)
        {
            appleShot2();
        }
        else if (pattern == 3)
        {
            //appleShot3();
        }
        pattern = 0;
        checkOneMove = !checkOneMove;
    }


    public void appleShot1()
    {
        for (int i = -1; i < 2; i++)
        {
            chapter1BossApplePrefab = Resources.Load(chapter1BossApplePrefabPath) as GameObject;
            GameObject apple = Instantiate(chapter1BossApplePrefab);
            apple.AddComponent<Chapter1BossAppleManager>();
            apple.transform.position = transform.position;
            apple.GetComponent<Rigidbody2D>().AddForce(appleSpeed * (force.normalized + new Vector3(0, i * 0.3f,0)));
        }
    }


    public void appleShot2()
    {
        for (float i = -0.5f; i < 1; i++)
        {
            chapter1BossApplePrefab = Resources.Load(chapter1BossApplePrefabPath) as GameObject;
            GameObject apple = Instantiate(chapter1BossApplePrefab);
            apple.AddComponent<Chapter1BossAppleManager>();
            apple.transform.position = transform.position;
            apple.GetComponent<Rigidbody2D>().AddForce(appleSpeed * (force.normalized + new Vector3(0, i * 0.2f,0)));
        }
    }
    public void appleShot3()
    {
        chapter1BossApplePrefab = Resources.Load(chapter1BossApplePrefabPath) as GameObject;
        GameObject apple = Instantiate(chapter1BossApplePrefab);
        apple.AddComponent<Chapter1BossAppleManager>();
        apple.transform.position = transform.position;
        apple.GetComponent<Rigidbody2D>().AddForce(force.normalized * appleSpeed);
    }



}
