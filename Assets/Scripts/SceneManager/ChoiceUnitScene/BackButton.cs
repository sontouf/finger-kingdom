using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BackButton : MonoBehaviour
{
    public void GoStageSelectScene()
    {
        SceneManager.LoadScene(2); // ChoiceUnitScene
    }
}
