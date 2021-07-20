using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 10;
    public int atk = 3;
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
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Trap"))
        {
            Destroy(gameObject);
        }
        if (coll.gameObject.CompareTag("Player"))
        {
            hp -= 3;
            Debug.Log("HP : " + hp);
        }

    }
}
