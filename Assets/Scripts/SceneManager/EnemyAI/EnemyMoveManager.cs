using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;


public class EnemyMoveManager : MonoBehaviour
{
    public float Min;
    Transform enemyTransform;
    public GameObject[] players;
    public GameObject closestPlayer;
    public Vector2 force = new Vector2(0, 0);
    List<GoblinEgg> goblins = new List<GoblinEgg>(); 

    int enemyCount;
    int enemyUnitIndex;
    // Start is called before the first frame update
    private void Start()
    {
        Min = 99999;
    }

    private void Update()
    {
        goblins = EggManager.GetEggManagersByType<GoblinEgg>();
        CalculateForce();

        if (!GameManager.isUserTurn)
        {
            Invoke("MoveEgg", 0.7f);
            GameManager.isUserTurn = !GameManager.isUserTurn;
        }

    }

    public void CalculateForce()
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
        if (closestPlayer != null && goblins != null)
        {
            enemyCount = goblins.Count;
            enemyUnitIndex = UnityEngine.Random.Range(0, enemyCount);
            force = (Vector2)closestPlayer.transform.position - (Vector2)goblins[enemyUnitIndex].transform.position;
            float result = force.x * force.x + force.y * force.y;
            if (Math.Abs(result) < 3)
            {
                force = 2.3f * force.normalized;
            }

        }
    }

    public void MoveEgg()
    {
        if (force != null)
        {
            goblins[enemyUnitIndex].MoveEgg(force);
        }

    }

}
