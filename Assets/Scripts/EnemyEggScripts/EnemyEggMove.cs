using System;
using UnityEngine;
using System.Collections.Generic;
public class EnemyEggMove : MonoBehaviour
{
    public float Min;
    public GameObject[] players;
    public GameObject closestPlayer;
    public Vector2 force = new Vector2(0, 0);
    public int enemyUnitIndex;
    private int checkOneMove;
    private float distance;

    public float result;
    public int thirdTurn;
    private void Start()
    {
        thirdTurn = 0;
        distance = 99999;
        Min = 99999;
        checkOneMove = 1;
    }

    private void Update()
    {
        if (BattleReady.completeReady)
        {
            if (EnemyEggManager.enemyEggManagers.Count > 0 && !GameManager.isUserTurn && checkOneMove == 1 && GameManager.stageNumber != 13)
            {
                checkOneMove = 0;
                Min = 99999;
                Invoke("CalculateClosestPlayer", 1f);
            }
            else if (EnemyEggManager.enemyEggManagers.Count > 0 && !GameManager.isUserTurn && checkOneMove == 1 && GameManager.stageNumber == 13)
            {
                if (thirdTurn == 2)
                {
                    checkOneMove = 0;
                    Invoke("Boss13Turn", 0.7f);
                    thirdTurn = 0;
                }
                else
                {
                    checkOneMove = 0;
                    thirdTurn++;
                    Invoke("Boss132Turn", 0.7f);
                }
            }
        }
    }

    public void CalculateClosestPlayer()
    {
        int num = EnemyEggManager.enemyEggManagers.Count;
        players = GameObject.FindGameObjectsWithTag("Player");
        enemyUnitIndex = UnityEngine.Random.Range(0, num);
        if (num != 0 && BattleReady.completeReady)
        {
            if (players != null && EnemyEggManager.enemyEggManagers[enemyUnitIndex].name == "Ghost")
            {
                foreach (GameObject player in players)
                {
                    if (player.name == "Healer" || player.name == "Acher" || player.name == "Cannon")
                    {
                        if (enemyUnitIndex <= num && num > 0)
                        {
                            distance = Vector2.Distance(EnemyEggManager.enemyEggManagers[enemyUnitIndex].GetComponent<Rigidbody2D>().position,
                                player.GetComponent<Rigidbody2D>().position);
                        }
                        if (distance < Min)
                        {
                            Min = distance;
                            closestPlayer = player;
                        }
                    }
                }
                if (!GameObject.Find("Healer") && !GameObject.Find("Archer") && !GameObject.Find("Cannon"))
                {
                    foreach (GameObject player in players)
                    {
                        if (enemyUnitIndex <= num && num > 0)
                        {
                            distance = Vector2.Distance(EnemyEggManager.enemyEggManagers[enemyUnitIndex].GetComponent<Rigidbody2D>().position,
                                player.GetComponent<Rigidbody2D>().position);
                        }
                        if (distance < Min)
                        {
                            Min = distance;
                            closestPlayer = player;
                        }
                    }
                }
            }
            else if (players != null && EnemyEggManager.enemyEggManagers[enemyUnitIndex].name == "RopeMan")
            {
                foreach (GameObject player in players)
                {
                    if (player.name == "Healer" || player.name == "Archer" || player.name == "Cannon")
                    {

                        if (enemyUnitIndex <= num && num > 0)
                        {
                            distance = Vector2.Distance(EnemyEggManager.enemyEggManagers[enemyUnitIndex].GetComponent<Rigidbody2D>().position,
                                player.GetComponent<Rigidbody2D>().position);
                        }
                        if (distance < Min)
                        {
                            Min = distance;
                            closestPlayer = player;
                        }
                    }
                }
                if (!GameObject.Find("Healer") && !GameObject.Find("Archer") && !GameObject.Find("Cannon"))
                {
                    foreach (GameObject player in players)
                    {
                        if (enemyUnitIndex <= num && num > 0)
                        {
                            distance = Vector2.Distance(EnemyEggManager.enemyEggManagers[enemyUnitIndex].GetComponent<Rigidbody2D>().position,
                                player.GetComponent<Rigidbody2D>().position);
                        }
                        if (distance < Min)
                        {
                            Min = distance;
                            closestPlayer = player;
                        }
                    }
                }
            }
            else if (players != null)
            {
                foreach (GameObject player in players)
                {
                    if (enemyUnitIndex <= num && num > 0)
                    {
                        distance = Vector2.Distance(EnemyEggManager.enemyEggManagers[enemyUnitIndex].GetComponent<Rigidbody2D>().position,
                            player.GetComponent<Rigidbody2D>().position);
                    }
                    if (distance < Min)
                    {
                        Min = distance;
                        closestPlayer = player;
                    }
                }
            }

            if (closestPlayer != null)
            {
                if (enemyUnitIndex <= num && num > 0)
                {
                    force = (Vector2)closestPlayer.GetComponent<Rigidbody2D>().position -
                        (Vector2)EnemyEggManager.enemyEggManagers[enemyUnitIndex].GetComponent<Rigidbody2D>().position;
                }
                result = Vector2.Distance((Vector2)closestPlayer.GetComponent<Rigidbody2D>().position,
                        (Vector2)EnemyEggManager.enemyEggManagers[enemyUnitIndex].GetComponent<Rigidbody2D>().position);
                force = result *2 * force.normalized;
                if (result < 5)
                {
                    force = 10 * force.normalized;
                }
                MoveEgg();
            }
            else
            {
                num = EnemyEggManager.enemyEggManagers.Count;
                players = GameObject.FindGameObjectsWithTag("Player");
                enemyUnitIndex = UnityEngine.Random.Range(0, num);
                if (num != 0)
                {
                    foreach (GameObject player in players)
                    {
                        if (enemyUnitIndex <= num && num > 0)
                        {
                            distance = Vector2.Distance(EnemyEggManager.enemyEggManagers[enemyUnitIndex].GetComponent<Rigidbody2D>().position,
                                player.GetComponent<Rigidbody2D>().position);
                        }
                        if (distance < Min)
                        {
                            Min = distance;
                            closestPlayer = player;
                        }
                    }
                }
                if (closestPlayer != null)
                {
                    if (enemyUnitIndex <= num && num > 0)
                    {
                        force = (Vector2)closestPlayer.GetComponent<Rigidbody2D>().position -
                            (Vector2)EnemyEggManager.enemyEggManagers[enemyUnitIndex].GetComponent<Rigidbody2D>().position;
                    }
                    result = Vector2.Distance((Vector2)closestPlayer.GetComponent<Rigidbody2D>().position,
                            (Vector2)EnemyEggManager.enemyEggManagers[enemyUnitIndex].GetComponent<Rigidbody2D>().position);
                    force = result * 2 * force.normalized;
                    if (result < 5)
                    {
                        force = 10 * force.normalized;
                    }
                    MoveEgg();
                }
            }

        }
    }


    public void MoveEgg()
    {
        int num = EnemyEggManager.enemyEggManagers.Count;
        if (enemyUnitIndex <= num && num > 0)
        {
            if (EnemyEggManager.enemyEggManagers[enemyUnitIndex].GetType() == typeof(SkeletonEgg))
            {
                EnemyEggManager.enemyEggManagers[enemyUnitIndex].MoveEgg(force);
                float z = Mathf.Atan2(force.y, force.x) * Mathf.Rad2Deg;
                Quaternion direction = Quaternion.Euler(0, 0, z);
                GameObject arrow = Skeleton_Arrow.CreateArrow(EnemyEggManager.enemyEggManagers[enemyUnitIndex].GetComponent<Rigidbody2D>().position, direction);
                arrow.GetComponent<Skeleton_Arrow>().ShotArrow(SkeletonEgg.arrowSpeed, force);
            }
            else if (EnemyEggManager.enemyEggManagers[enemyUnitIndex].GetType() == typeof(RopeManEgg))
            {
                EnemyEggManager.enemyEggManagers[enemyUnitIndex].MoveEgg(force);
                float z = Mathf.Atan2(force.y, force.x) * Mathf.Rad2Deg;
                Quaternion direction = Quaternion.Euler(0, 0, 90 + z);
                GameObject rope = RopeMan_Rope.CreateRope(EnemyEggManager.enemyEggManagers[enemyUnitIndex].GetComponent<Rigidbody2D>().position, direction);
                rope.GetComponent<RopeMan_Rope>().ShotRope(RopeManEgg.ropeSpeed, force);
            }

            else if (EnemyEggManager.enemyEggManagers[enemyUnitIndex].tag != "Boss")
            {
                EnemyEggManager.enemyEggManagers[enemyUnitIndex].MoveEgg(force);
            }
            GameManager.isUserTurn = !GameManager.isUserTurn;
            checkOneMove = 1;
            force = new Vector2(0, 0);

        }
        else
        {
            if (num > 0)
            {
                enemyUnitIndex = UnityEngine.Random.Range(0, num);
                if (EnemyEggManager.enemyEggManagers[enemyUnitIndex].tag != "Boss")
                {
                    EnemyEggManager.enemyEggManagers[enemyUnitIndex].MoveEgg(force);
                }
                GameManager.isUserTurn = !GameManager.isUserTurn;
                checkOneMove = 1;
                force = new Vector2(0, 0);
            }
        }
    }
}
