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
        if (DontDestroyUserData.storyNumber == 0)
        {
            maxCostValue = 6;
        }
        else if (DontDestroyUserData.storyNumber == 1)
        {
            maxCostValue = 10;
        }
        else if (DontDestroyUserData.storyNumber == 2)
        {
            maxCostValue = 12;
        }
        else if (DontDestroyUserData.storyNumber == 3)
        {
            maxCostValue = 18;
        }
        else if (DontDestroyUserData.storyNumber == 4)
        {
            maxCostValue = 24;
        }
        text.text = "" + maxCostValue;
    }

}
