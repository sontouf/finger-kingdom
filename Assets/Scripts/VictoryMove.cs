using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryMove : MonoBehaviour
{
    bool victoryBool;
    public void vicctoryMove()
    {
        victoryBool = !victoryBool;
    }

    private void Update()
    {
        if (victoryBool)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-613, 390, 0), Time.deltaTime * 20);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-534, 329, 0), Time.deltaTime * 20);
        }
    }
}
