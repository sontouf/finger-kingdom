using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodScript : MonoBehaviour
{
    public int count = 4;


    private void Start()
    {
        if(this.gameObject.name == "greeneryPrefab(Clone)")
        {
            count = 2;
        }
        if (this.gameObject.name == "Rock1Prefab(Clone)")
        {
            count = 3;
        }
        else if (this.gameObject.name == "Rock2Prefab(Clone)")
        {
            count = 4;
        }
        else if (this.gameObject.name == "Rock5Prefab(Clone)")
        {
            count = 6;
        }
    }
    private void Update()
    {
        if (count == 0)
        {
            Destroy(gameObject);
        }
    }
    public void OnCollisionEnter2D(Collision2D coll)
    {
        if ((coll.gameObject.CompareTag("Player") || coll.gameObject.CompareTag("Enemy") 
            || coll.gameObject.CompareTag("Boss")) && BattleReady.completeReady)
        {
            count--;
        }
    }
}
