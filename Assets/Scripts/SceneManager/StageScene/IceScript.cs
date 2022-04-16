using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceScript : MonoBehaviour
{
    public int count = 4;

    private void Start()
    {

        if (this.gameObject.name == "SmallIceWallPrefab(Clone)")
        {
            count = 3;
        }
        else if (this.gameObject.name == "NormalIceWallPrefab(Clone)")
        {
            count = 4;
        }
        else if (this.gameObject.name == "BigIceWallPrefab(Clone)")
        {
            count = 5;
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
        if (BattleReady.completeReady)
        {
            if ((coll.gameObject.CompareTag("Player") || coll.gameObject.CompareTag("Enemy") 
                || coll.gameObject.CompareTag("Boss")) && BattleReady.completeReady)
            {
                count--;
            }
        }
    }
}
