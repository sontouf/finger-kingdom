using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * 씬을 관리하는 메서드들
 */
public class SceneManagerScript : MonoBehaviour
{
    // ============================ [ call-back method ] ============================
    public void MainScene()
    {
        SceneManager.LoadScene(0);
    }
    public void HowToPlayScene()
    {
        SceneManager.LoadScene(1);
    }
    public void ChapterSelectScene()
    {
        SceneManager.LoadScene(2);
    }
    public void Chapter1StageSelectScene()
    {
        EggManager.ClearAll();
        SceneManager.LoadScene(3);
    }
    public void Chapter2StageSelectScene()
    {
        EggManager.ClearAll();
        SceneManager.LoadScene(4);
    }
    public void Chapter3StageSelectScene()
    {
        EggManager.ClearAll();
        SceneManager.LoadScene(5);
    }

    public void Chapter4StageSelectScene()
    {
        EggManager.ClearAll();
        SceneManager.LoadScene(6);
    }


    public void ChoiceUnitScene()
    {
        SceneManager.LoadScene(7);
    }
    public void Chapter1StageScene()
    {
        SceneManager.LoadScene(8);
    }
    public void Chapter2StageScene()
    {
        SceneManager.LoadScene(9);
    }
    public void Chapter3StageScene()
    {
        SceneManager.LoadScene(10);
    }
    public void Chapter4StageScene()
    {
        SceneManager.LoadScene(11);
    }
    public void SmithyScene()
    {
        SceneManager.LoadScene(12);
    }

}
