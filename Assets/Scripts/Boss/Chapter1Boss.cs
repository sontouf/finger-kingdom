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

    GameObject closestPlayer;
    public int pattern;

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
        GameManager.bossUnitCount = 0;
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
            Debug.Log("hi");
            Invoke("treePattern",4f);
            checkOneMove = !checkOneMove;
        }
        if (GameManager.enemyUnitCount == 1 && GameManager.isUserTurn == false)
        {
            GameManager.isUserTurn = !GameManager.isUserTurn;
        }
        if (transform.position.x > 6.15 || transform.position.x < -6.15 || transform.position.y > 3.7 || transform.position.y < -3.7)
        {
            // DestroyEgg();
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
        Debug.Log("CcheckOneMove" + checkOneMove);
    }


    public void appleShot1()
    {
        Debug.Log("Boss 1  : ");
        for (int i = -2; i < 3; i++)
        {
            chapter1BossApplePrefab = Resources.Load(chapter1BossApplePrefabPath) as GameObject;
            GameObject apple = Instantiate(chapter1BossApplePrefab);
            apple.AddComponent<Chapter1BossAppleManager>();
            apple.transform.position = transform.position;
            apple.GetComponent<Rigidbody2D>().AddForce(appleSpeed * (Vector2.left + new Vector2(0, i * 0.3f)));
            Debug.Log("vector : " + appleSpeed * (Vector2.right + new Vector2(0, i * 0.3f)));
        }
    }


    public void appleShot2()
    {
        for (float i = -1.5f; i < 2; i++)
        {
            chapter1BossApplePrefab = Resources.Load(chapter1BossApplePrefabPath) as GameObject;
            GameObject apple = Instantiate(chapter1BossApplePrefab);
            apple.AddComponent<Chapter1BossAppleManager>();
            apple.transform.position = transform.position;
            apple.GetComponent<Rigidbody2D>().AddForce((Vector2.left + new Vector2(0, i * 0.2f))* appleSpeed );
            Debug.Log("vector : " + appleSpeed * (Vector2.left + new Vector2(0, i * 0.2f)));
        }
    }
    public void appleShot3()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

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
            chapter1BossApplePrefab = Resources.Load(chapter1BossApplePrefabPath) as GameObject;
            GameObject apple = Instantiate(chapter1BossApplePrefab);
            apple.AddComponent<Chapter1BossAppleManager>();
            apple.transform.position = transform.position;
            apple.GetComponent<Rigidbody2D>().AddForce((closestPlayer.transform.position - transform.position).normalized * appleSpeed);
        }
    }


}
