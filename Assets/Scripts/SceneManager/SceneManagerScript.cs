using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Reflection;
using System.Linq;
/*
 * 씬을 관리하는 메서드들
 */
public class SceneManagerScript : MonoBehaviour
{
    //public TutorialManager tutorialManager;
    bool checkChapter1;
    bool checkChapter2;
    bool checkChapter3;
    bool checkChapter4;
/*    private void Awake()
    {
        if (!PlayerPrefs.HasKey("StoryNumber"))
        {
            //DontDestroyUserData.storyNumber = 0;
            PlayerPrefs.SetInt("StoryNumber", 0);
            return;
        }
        else
            DontDestroyUserData.storyNumber = PlayerPrefs.GetInt("StoryNumber");
    }*/
    private void Start()
    {
        checkChapter1 = false;
        checkChapter2 = false;
        checkChapter3 = false;
        checkChapter4 = false;
    }

    // ============================ [ call-back method ] ============================
    public void MainScene()
    { 
        SceneManager.LoadScene(0);
        
    }
    public void ChapterSelectScene()
    {
        SceneManager.LoadScene(1);
    }
    public void Chapter1StageSelectScene()
    {
        ChapterClear.chapterClear = 1;
        EggManager.ClearAll();
        checkChapter1 = true;
        //ScrollingBarController.LoadScene("Chapter1StageSelectScene");
        //SceneManager.LoadScene(2);
    }
    public void Chapter2StageSelectScene()
    {
        ChapterClear.chapterClear = 2;
        EggManager.ClearAll();
        checkChapter2 = true;
        //SceneManager.LoadScene(3);
    }
    public void Chapter3StageSelectScene()
    {
        ChapterClear.chapterClear = 3;
        EggManager.ClearAll();
        checkChapter3 = true;
       // SceneManager.LoadScene(4);
    }

    public void Chapter4StageSelectScene()
    {
        ChapterClear.chapterClear = 4;
        EggManager.ClearAll();
        checkChapter4 = true;
        //SceneManager.LoadScene(5);
    }


    public void ChoiceUnitScene()
    {

        foreach (Type t in Assembly
            .GetAssembly(typeof(UserEggManager))
            .GetTypes()
            .Where(t => t.IsSubclassOf(typeof(UserEggManager)))
            )
        {
            SelectedUnitData.unitCounts[t] = 0;
        }
        SceneManager.LoadScene(6);
    }

    // restart 할때 쓰임.
    public void Chapter1StageScene()
    {
        EggManager.ClearAll();
        SceneManager.LoadScene(7);
    }
    public void Chapter2StageScene()
    {
        EggManager.ClearAll();
        SceneManager.LoadScene(8);
    }
    public void Chapter3StageScene()
    {
        EggManager.ClearAll();
        SceneManager.LoadScene(9);
    }
    public void Chapter4StageScene()
    {
        EggManager.ClearAll();
        SceneManager.LoadScene(10);
    }

    public void GoTutorial()
    {
        SceneManager.LoadScene(13);
    }
    public void StageDescription()
    {
        SceneManager.LoadScene(12);
    }

    private void Update()
    {
        if (checkChapter1)
        {
            ScrollingBarController.LoadScene("Chapter1StageSelectScene");
            checkChapter1 = !checkChapter1;
        }
        else if (checkChapter2)
        {
            ScrollingBarController.LoadScene("Chapter2StageSelectScene");
            checkChapter2 = !checkChapter2;
        }
        else if (checkChapter3)
        {
            ScrollingBarController.LoadScene("Chapter3StageSelectScene");
            checkChapter3 = !checkChapter3;
        }
        else if (checkChapter4)
        {
            ScrollingBarController.LoadScene("Chapter4StageSelectScene");
            checkChapter4 = !checkChapter4;
        }
    }
}
