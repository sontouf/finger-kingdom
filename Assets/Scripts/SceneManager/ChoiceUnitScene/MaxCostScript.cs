using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxCostScript : MonoBehaviour
{
    

    public Text text;
    static public int maxCostValue = 0;


    private void Start()
    {
        text = GameObject.Find("MaxCost").GetComponent<Text>();

        if (GameManager.stageNumber == 0)
        {
            maxCostValue = 4;
        }
        else if (GameManager.stageNumber == 1)
        {
            maxCostValue = 6;
        }
        else if (GameManager.stageNumber == 2)
        {
            maxCostValue = 10;
        }
        else if (GameManager.stageNumber == 3)
        {
            maxCostValue = 14;
        }
        else if (GameManager.stageNumber == 4)
        {
            maxCostValue = 22;
        }
        else if (GameManager.stageNumber == 5)
        {
            maxCostValue = 21;
        }
        else if (GameManager.stageNumber == 6)
        {
            maxCostValue = 23;
        }
        else if (GameManager.stageNumber == 7)
        {
            maxCostValue = 26;
        }
        else if (GameManager.stageNumber == 8)
        {
            maxCostValue = 34;
        }
        else if (GameManager.stageNumber == 9)
        {
            maxCostValue = 26;
        }
        else if (GameManager.stageNumber == 10)
        {
            maxCostValue = 28;
        }
        else if (GameManager.stageNumber == 11)
        {
            maxCostValue = 30;
        }
        else if (GameManager.stageNumber == 12)
        {
            maxCostValue = 34;
        }
        else if (GameManager.stageNumber == 13)
        {
            maxCostValue = 70;
        }
        text.text = "" + maxCostValue;
    }

}
