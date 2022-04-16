using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter1BossAppleManager : MonoBehaviour
{
    int damage;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", 3.0f);
        damage = 15;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        GameObject otherObject = other.gameObject;
        EggManager otherEggManager = otherObject.GetComponent<EggManager>();
        if (otherObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            otherEggManager.curHp -= damage;
            otherObject.GetComponent<HpBarController>()
                    .SetHealth(otherEggManager.curHp, otherEggManager.maxHp);
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
