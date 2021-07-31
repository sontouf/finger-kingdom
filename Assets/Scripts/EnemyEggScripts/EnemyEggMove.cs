using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnemyEggMove : MonoBehaviour
{
    public float Min;
    public GameObject[] players;
    public GameObject closestPlayer;
    public Vector2 force = new Vector2(0, 0);
    public int enemyUnitIndex;
    private int checkOneMove;
    private float distance;

    private void Start()
    {
        Min = 99999;
        checkOneMove = 1;
    }

    private void Update()
    {
        if (EnemyEggManager.enemyEggManagers.Count > 0 && !GameManager.isUserTurn && checkOneMove == 1)
        {
            Debug.Log("GameManager.isUserTurn : " + GameManager.isUserTurn);
            Debug.Log("checkOneMove : " + checkOneMove);
            checkOneMove = 0;
            Min = 99999;
            Invoke("CalculateClosestPlayer", 1.4f);

        }
    }

    public void CalculateClosestPlayer()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        if (players != null)
        {
            foreach (GameObject player in players)
            {
                enemyUnitIndex = UnityEngine.Random.Range(0, EnemyEggManager.enemyEggManagers.Count);
                if (enemyUnitIndex <= EnemyEggManager.enemyEggManagers.Count && EnemyEggManager.enemyEggManagers.Count > 0)
                {
                    distance = Vector2.Distance(EnemyEggManager.enemyEggManagers[enemyUnitIndex].transform.position, player.transform.position);
                }
                if (distance < Min)
                {
                    Min = distance;
                    closestPlayer = player;
                }
            }
            if (closestPlayer != null)
            {
                
                if (enemyUnitIndex <= EnemyEggManager.enemyEggManagers.Count && EnemyEggManager.enemyEggManagers.Count > 0)
                {
                    force = (Vector2)closestPlayer.transform.position - (Vector2)EnemyEggManager.enemyEggManagers[enemyUnitIndex].transform.position;
                }
                float result = force.x * force.x + force.y * force.y;
                if (Math.Abs(result) < 3)
                {
                    force = 2.3f * force.normalized;
                }
                MoveEgg();
            }
        }
    }

    public void MoveEgg()
    {
        if (enemyUnitIndex <= EnemyEggManager.enemyEggManagers.Count && EnemyEggManager.enemyEggManagers.Count > 0)
        {
            EnemyEggManager.enemyEggManagers[enemyUnitIndex].MoveEgg(force);
            GameManager.isUserTurn = !GameManager.isUserTurn;
            checkOneMove = 1;
            force = new Vector2(0, 0);
        }
        else
        {
            if (EnemyEggManager.enemyEggManagers.Count > 0)
            {
                enemyUnitIndex = UnityEngine.Random.Range(0, EnemyEggManager.enemyEggManagers.Count);
                EnemyEggManager.enemyEggManagers[enemyUnitIndex].MoveEgg(force);
                GameManager.isUserTurn = !GameManager.isUserTurn;
                checkOneMove = 1;
                force = new Vector2(0, 0);
            }
        }
    }
}
