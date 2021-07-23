using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoMainScene : MonoBehaviour
{
    public void GoBackMainScene()
    {
        SceneManager.LoadScene(0); // ChoiceUnitScene
    }

}
