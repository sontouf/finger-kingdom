using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter4BossHurdle : MonoBehaviour
{

    int hurdleDamage;
    bool one;
    // Start is called before the first frame update
    void Start()
    {
        one = false;
        hurdleDamage = 10;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (GameManager.isUserTurn && !one)
            {
                collision.GetComponent<UserEggManager>().curHp -= 10;
                one = !one;
            }
            if (!GameManager.isUserTurn)
            {
                one = !one;
            }
        }
    }
}
