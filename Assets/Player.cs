using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int hp = 10;
    public int atk = 3;
    public float speed = 1.0f;

    private float range;
    private Vector2 mousePos;
    private Vector2 Force = new Vector2(0, 0);
    private bool Holding = false;

    Camera Camera;
    // Start is called before the first frame update
    void Awake()
    {
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        range = GetComponent<CircleCollider2D>().radius;
        //컬라이더 반지름 얻어옴
    }


    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.ScreenToWorldPoint(mousePos);
        if (Input.GetMouseButtonDown(0) && Vector2.Distance(mousePos, transform.position) <= range)
        {
            Holding = true;
        }
        if(Input.GetMouseButton(0) && Holding)
        {
            Force = (Vector2)transform.position - mousePos;
        }
        if(Input.GetMouseButtonUp(0))
        {
            GetComponent<Rigidbody2D>().AddForce(Force * speed);
            Force = new Vector2(0, 0);
            Holding = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.CompareTag("Trap"))
        {
            Destroy(gameObject);
        }
        if (coll.gameObject.CompareTag("Enemy"))
        {
            
        }

    }



}