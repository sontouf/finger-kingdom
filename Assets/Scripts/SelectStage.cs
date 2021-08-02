using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectStage : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    { // 초기화창. 
        if (DontDestroyUserData.stageClearCheck == true)
        {
            DontDestroyUserData.storyNumber += 1;
            DontDestroyUserData.stageClearCheck = !DontDestroyUserData.stageClearCheck;
            SelectedUnitData.warriorNumber = 0;
            SelectedUnitData.archerNumber = 0;
            SelectedUnitData.shieldNumber = 0;
            SelectedUnitData.cavalryNumber = 0;
            SelectedUnitData.healerNumber = 0;
        }
    }

    public void ClickStage1()
    {
        GameManager.stageNumber = 1;
    }
    public void ClickStage2()
    {
        if (DontDestroyUserData.storyNumber >= 1)
        {
            GameManager.stageNumber = 2;
        }
    }
    public void ClickStage3()
    {
        if (DontDestroyUserData.storyNumber >= 2)
        {
            GameManager.stageNumber = 3;
        }

    }
    public void ClickStage4()
    {
        if (DontDestroyUserData.storyNumber >= 3)
        {
            GameManager.stageNumber = 4;
        }
    }
    public void ClickStage5()
    {
        if (DontDestroyUserData.storyNumber >= 4)
        {
            GameManager.stageNumber = 5;
        }
    }
}
