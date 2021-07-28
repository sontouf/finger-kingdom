using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagerScript : MonoBehaviour
{


    public void MainScene()
    {
        SceneManager.LoadScene(0);
    }
    public void HowToPlayScene()
    {
        SceneManager.LoadScene(1);
    }
    public void StageSelectScene()
    {
        SceneManager.LoadScene(2);
    }
    public void ChoiceUnitScene()
    {
        SceneManager.LoadScene(3);
    }
    public void Stage1Scene()
    {
        SceneManager.LoadScene(4);
    }


}
