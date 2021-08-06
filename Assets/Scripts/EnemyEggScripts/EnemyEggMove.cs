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
            checkOneMove = 0;
            Min = 99999;
            Invoke("CalculateClosestPlayer", 1.4f);

        }
    }

    public void CalculateClosestPlayer()
    {
        int num = EnemyEggManager.enemyEggManagers.Count;
        players = GameObject.FindGameObjectsWithTag("Player");
        if (players != null)
        {
            foreach (GameObject player in players)
            {
                enemyUnitIndex = UnityEngine.Random.Range(0, num);
                if (enemyUnitIndex <= num && num > 0)
                {
                    distance = Vector2.Distance(EnemyEggManager.enemyEggManagers[enemyUnitIndex].GetComponent<Rigidbody2D>().position, player.GetComponent<Rigidbody2D>().position);
                }
                if (distance < Min)
                {
                    Min = distance;
                    closestPlayer = player;
                }
            }
            if (closestPlayer != null)
            {
                if (enemyUnitIndex <= num && num > 0)
                {
                    force = (Vector2)closestPlayer.GetComponent<Rigidbody2D>().position - (Vector2)EnemyEggManager.enemyEggManagers[enemyUnitIndex].GetComponent<Rigidbody2D>().position;
                }
                float result = force.x * force.x + force.y * force.y;
                if (Math.Abs(result) < 3)
                {
                    force = 3f * force.normalized;
                }
                MoveEgg();
            }
        }
    }

    public void MoveEgg()
    {
        int num = EnemyEggManager.enemyEggManagers.Count;
        if (enemyUnitIndex <= num && num > 0)
        {
            EnemyEggManager.enemyEggManagers[enemyUnitIndex].MoveEgg(force);
            GameManager.isUserTurn = !GameManager.isUserTurn;
            checkOneMove = 1;
            force = new Vector2(0, 0);
        }
        else
        {
            if (num > 0)
            {
                enemyUnitIndex = UnityEngine.Random.Range(0, num);
                EnemyEggManager.enemyEggManagers[enemyUnitIndex].MoveEgg(force);
                GameManager.isUserTurn = !GameManager.isUserTurn;
                checkOneMove = 1;
                force = new Vector2(0, 0);
            }
        }
    }
}
