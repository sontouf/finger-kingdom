using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter1BossMove : MonoBehaviour
{
    const string chapter1BossApplePrefabPath = "Prefabs/Boss/Chapter1BossApplePrefab";
    public float appleSpeed;
    private int checkOneMove;
    public int pattern;
    public GameObject chapter1BossApplePrefab;
    float Min;
    public Vector3 force;
    public GameObject[] players;
    public GameObject closestPlayer;
    public Vector3 pos;
    private void Start()
    {
        checkOneMove = 1;
        appleSpeed = 100;
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
        treePattern(pos, force);
    }

    public void treePattern(Vector3 pos, Vector3 force)
    {
        pattern = Random.Range(1, 4);
        Debug.Log("pattern" + pattern);

        if (pattern == 1)
        {
            appleShot1(pos, force);
        }
        else if (pattern == 2)
        {
            appleShot2(pos, force);
        }
        else if (pattern == 3)
        {
            appleShot3(pos, force);
        }
        pattern = 0;
        checkOneMove = 1;
        force = new Vector3(0, 0, 0);
    }


    public void appleShot1(Vector3 pos, Vector3 force)
    {
        for (int i = -1; i < 2; i++)
        {
            chapter1BossApplePrefab = Resources.Load(chapter1BossApplePrefabPath) as GameObject;
            GameObject apple = Instantiate(chapter1BossApplePrefab, pos, Quaternion.identity);
            apple.AddComponent<Chapter1BossAppleManager>();
            apple.GetComponent<Rigidbody2D>().AddForce(appleSpeed * (force.normalized + new Vector3(0, i * 0.3f, 0)));
        }
    }


    public void appleShot2(Vector3 pos, Vector3 force)
    {
        for (float i = -0.5f; i < 1; i++)
        {
            chapter1BossApplePrefab = Resources.Load(chapter1BossApplePrefabPath) as GameObject;
            GameObject apple = Instantiate(chapter1BossApplePrefab, pos, Quaternion.identity);
            apple.AddComponent<Chapter1BossAppleManager>();
            apple.GetComponent<Rigidbody2D>().AddForce(appleSpeed * (force.normalized + new Vector3(0, i * 0.2f, 0)));
        }
    }
    public void appleShot3(Vector3 pos, Vector3 force)
    {
        chapter1BossApplePrefab = Resources.Load(chapter1BossApplePrefabPath) as GameObject;
        GameObject apple = Instantiate(chapter1BossApplePrefab, pos, Quaternion.identity);
        apple.AddComponent<Chapter1BossAppleManager>();
        apple.GetComponent<Rigidbody2D>().AddForce(force.normalized * appleSpeed);
    }
}
