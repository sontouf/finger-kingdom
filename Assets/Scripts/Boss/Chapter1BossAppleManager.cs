using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter1BossAppleManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", 3.0f);

    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    public void DestroySelf()
    {
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }


}
