using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WinningCondition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.stageNumber == 4 || GameManager.stageNumber == 8 || GameManager.stageNumber == 12 || GameManager.stageNumber == 13)
        {
            GetComponent<Text>().text = "승리조건\n\n보스를 처치하라";
        }
    }
}
