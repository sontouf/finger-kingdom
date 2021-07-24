using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static int MoveChance = 0;
    public static bool isYourTurn = true;
    // Start is called before the first frame update
    void Start()
    {
        playerTurn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void playerTurn()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject i in players)
        {
            i.GetComponent<Player>().myTurn();
        }
        isYourTurn = true;
        Debug.Log("Player Turn!");
        
    }
    public void enemyTurn()
    {
        isYourTurn = false;
        Debug.Log("Enemy's Turn");
        Debug.Log("Enemies attack!");

        playerTurn();

        
        


    }
}
