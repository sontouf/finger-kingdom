using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 10;
    public int atk = 3;
    float speed = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if(hp<=0)
        {
            Destroy(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Move();
        }
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Trap"))
        {
            Destroy(gameObject);
        }
        if (coll.gameObject.CompareTag("Player"))
        {
            
        }

    }
    public void Move()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject closestPlayer = GameObject.FindGameObjectWithTag("Player");
        float Min = 999999;

        foreach (GameObject player in players)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if(distance < Min)
            {
                Min = distance;
                closestPlayer = player;
            }
        }
        
        GetComponent<Rigidbody2D>().AddForce(10*speed*(closestPlayer.transform.position - transform.position).normalized);
    }

    
}
