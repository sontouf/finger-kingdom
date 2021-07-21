using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    Vector3 p1 = new Vector3(-5, 2, 0);
    Vector3 p2 = new Vector3(-5, 0, 0);
    Vector3 p3 = new Vector3(-5, -2, 0);


    Vector3 p4 = new Vector3(5, 2, 0);
    Vector3 p5 = new Vector3(5, 0, 0);
    Vector3 p6 = new Vector3(5, -2, 0);
    private List<Vector3> UserEggPositions = new List<Vector3>();
    private List<Vector3> EnemyEggPositions = new List<Vector3>();


    [SerializeField]
    private GameObject planePrefeb;


    private string enemyEggTagName = "Enemy";
    private string userEggTagName = "Player";

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(planePrefeb, Vector3.zero, Quaternion.identity);


        UserEggPositions.Add(p1);
        UserEggPositions.Add(p2);
        UserEggPositions.Add(p3);

        EnemyEggPositions.Add(p4);
        EnemyEggPositions.Add(p5);
        EnemyEggPositions.Add(p6);

        

        foreach (Vector3 pos in EnemyEggPositions)
        {
            EggManager.CreateEgg(pos, enemyEggTagName);
        }


        foreach (Vector3 pos in UserEggPositions)
        {
            EggManager.CreateEgg(pos, userEggTagName);
        }



    }




}
