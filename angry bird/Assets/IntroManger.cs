using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void GoGameScene()
   {
       SceneManager.LoadScene(1);

   }
   public void GoInGameScene1()
   {
       SceneManager.LoadScene(2);

   }


}
