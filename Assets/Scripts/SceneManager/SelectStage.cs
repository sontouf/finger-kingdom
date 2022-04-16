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
            PlayerPrefs.SetInt("StoryNumber", DontDestroyUserData.storyNumber);
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
    public void ClickStage6()
    {
        if (DontDestroyUserData.storyNumber >= 5)
        {
            GameManager.stageNumber = 6;
        }
    }
    public void ClickStage7()
    {
        if (DontDestroyUserData.storyNumber >= 6)
        {
            GameManager.stageNumber = 7;
        }
    }
    public void ClickStage8()
    {
        if (DontDestroyUserData.storyNumber >= 7)
        {
            GameManager.stageNumber = 8;
        }
    }
    public void ClickStage9()
    {
        if (DontDestroyUserData.storyNumber >= 8)
        {
            GameManager.stageNumber = 9;
        }
    }
    public void ClickStage10()
    {
        if (DontDestroyUserData.storyNumber >= 9)
        {
            GameManager.stageNumber = 10;
        }
    }
    public void ClickStage11()
    {
        if (DontDestroyUserData.storyNumber >= 10)
        {
            GameManager.stageNumber = 11;
        }
    }
    public void ClickStage12()
    {
        if (DontDestroyUserData.storyNumber >= 11)
        {
            GameManager.stageNumber = 12;
        }
    }
    public void ClickStage13()
    {
        if (DontDestroyUserData.storyNumber >= 12)
        {
            GameManager.stageNumber = 13;
        }
    }
}
