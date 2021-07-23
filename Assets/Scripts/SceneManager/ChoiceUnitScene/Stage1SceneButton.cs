using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Stage1SceneButton : MonoBehaviour
{
    public void GoStage1Scene()
    {
        SceneManager.LoadScene(4); // Stage1Scene
    }
}
