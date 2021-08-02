using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject bullet;
    public float bulletSpeed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            treepattern();
        }

    }
    public void treepattern()
    {
        int pattern = Random.Range(0, 4);
        switch (pattern)
        {
            case 0:

                break;
            case 1:
                appleShot1();
                break;
            case 2:
                appleShot2();
                break;
            case 3:
               // appleShot3();
                break;
        }
    }

    void appleShot1()
    {
        for (int i = -2; i < 3; i++)
        {
            GameObject apple = Instantiate(bullet);
            apple.transform.position = transform.position;
            apple.GetComponent<Rigidbody2D>().AddForce(bulletSpeed * (Vector2.left + new Vector2(0, i * 0.3f)));
            Debug.Log("vector : " + bulletSpeed * (Vector2.left + new Vector2(0, i * 0.3f)));

        }
    }
    void appleShot2()
    {
        for (float i = -1.5f; i < 2; i++)
        {
            GameObject apple = Instantiate(bullet);
            apple.transform.position = transform.position;
            apple.GetComponent<Rigidbody2D>().AddForce(bulletSpeed * (Vector2.left + new Vector2(0, i * 0.2f)));
        }
    }
    void appleShot3()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject closestPlayer = GameObject.FindGameObjectWithTag("Player");
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


        GameObject apple = Instantiate(bullet);
        apple.transform.position = transform.position;
        apple.GetComponent<Rigidbody2D>().AddForce(bulletSpeed * (closestPlayer.transform.position - transform.position).normalized);

    }
}
