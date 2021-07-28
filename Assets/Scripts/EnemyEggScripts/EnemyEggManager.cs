using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class EnemyEggManager : EggManager
{
    // Start is called before the first frame update

    // Update is called once per frame


    public float Min;
    Transform enemyTransform;
    public GameObject[] players;
    public GameObject[] enemys;
    public GameObject closestPlayer;
    public Vector2 force = new Vector2(0, 0);
    static public List<EnemyEggManager> enemyEggManagers = new List<EnemyEggManager>();


    int enemyCount;
    int enemyUnitIndex;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Min = 99999;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        enemyUnitIndex = UnityEngine.Random.Range(0,enemyEggManagers.Count);
        CalculateForce(enemyUnitIndex);

        if (!GameManager.isUserTurn)
        {
            Invoke("MoveEgg", 0.7f);
            GameManager.isUserTurn = !GameManager.isUserTurn;
        }

    }

    protected override void DestroyEgg()
    {
        enemyEggManagers.Remove(this);
        base.DestroyEgg();
    }
    public void CalculateForce(int index)
    {
        Min = 99999;
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance < Min)
            {
                Min = distance;
                closestPlayer = player;
            }
            /*    Debug.Log("check position : " + player.transform.position);*/
        }
        force = (Vector2)closestPlayer.transform.position - (Vector2)enemyEggManagers[index].transform.position;
        float result = force.x * force.x + force.y * force.y;
        if (Math.Abs(result) < 3)
        {
            force = 2.3f * force.normalized;
        }
    }

    public void MoveEgg()
    {
         enemyEggManagers[enemyUnitIndex].MoveEgg(force);
    }
}
