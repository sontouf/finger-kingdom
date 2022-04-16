using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VicdefMove : MonoBehaviour
{

    bool defeatBool;
    public void DefeatMove()
    {
        defeatBool = !defeatBool;
    }


    private void Update()
    {
        if (defeatBool)
        {
            transform.Translate(new Vector3(-613, 390, 0));
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-534, 329, 0), Time.deltaTime * 20);
        }
    }
}
