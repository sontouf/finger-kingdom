using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lockManager : MonoBehaviour
{
    private bool check;
    //GameObject chapter4Clear;


    private void Update()
    {
        //==========================chapter===============
        if(DontDestroyUserData.storyNumber >= 4)
        {
            check = GameObject.Find("Chapter2lock");
            if (check != false)
            {
                Destroy(GameObject.Find("Chapter2lock"));
                GameObject.Find("Chapter2").GetComponent<Button>().interactable = true;
    
            }
        }
        if (DontDestroyUserData.storyNumber >= 8)
        {
            check = GameObject.Find("Chapter3lock");
            if (check != false)
            {
                Destroy(GameObject.Find("Chapter3lock"));
                GameObject.Find("Chapter3").GetComponent<Button>().interactable = true;
 
            }
        }
        if (DontDestroyUserData.storyNumber >= 12)
        {
            check = GameObject.Find("Chapter4lock");
            if (check != false)
            {
                Destroy(GameObject.Find("Chapter4lock"));
                GameObject.Find("Chapter4").GetComponent<Button>().interactable = true;
    
            }
        }



        // ===================stage=======================

        if (DontDestroyUserData.storyNumber >= 1)
        {
            check = GameObject.Find("Chapter1Stage2lock");
            if (check != false)
            {
                Destroy(GameObject.Find("Chapter1Stage2lock"));
                GameObject.Find("Chapter1Stage2Button").GetComponent<Button>().interactable = true;

            }
        }
        if (DontDestroyUserData.storyNumber >= 2)
        {
            check = GameObject.Find("Chapter1Stage3lock");
            if (check != false)
            {
                Destroy(GameObject.Find("Chapter1Stage3lock"));
                GameObject.Find("Chapter1Stage3Button").GetComponent<Button>().interactable = true;
     
            }
        }
        if (DontDestroyUserData.storyNumber >= 3)
        {
            check = GameObject.Find("Chapter1Stage4lock");
            if (check != false)
            {
                Destroy(GameObject.Find("Chapter1Stage4lock"));
                GameObject.Find("Chapter1Stage4Button").GetComponent<Button>().interactable = true;
       
            }
        }
        if (DontDestroyUserData.storyNumber >= 4)
        {

            check = GameObject.Find("Chapter2Stage1lock");
            if (check != false)
            {
                Destroy(GameObject.Find("Chapter2Stage1lock"));
                GameObject.Find("Chapter2Stage1Button").GetComponent<Button>().interactable = true;
            }
        }
        if (DontDestroyUserData.storyNumber >= 5)
        {
            check = GameObject.Find("Chapter2Stage2lock");
            if (check != false)
            {
                Destroy(GameObject.Find("Chapter2Stage2lock"));
                GameObject.Find("Chapter2Stage2Button").GetComponent<Button>().interactable = true;
               
            }
        }
        if (DontDestroyUserData.storyNumber >= 6)
        {
            check = GameObject.Find("Chapter2Stage3lock");
            if (check != false)
            {
                Destroy(GameObject.Find("Chapter2Stage3lock"));
                GameObject.Find("Chapter2Stage3Button").GetComponent<Button>().interactable = true;
               
            }
        }
        if (DontDestroyUserData.storyNumber >= 7)
        {
            check = GameObject.Find("Chapter2Stage4lock");
            if (check != false)
            {
                Destroy(GameObject.Find("Chapter2Stage4lock"));
                GameObject.Find("Chapter2Stage4Button").GetComponent<Button>().interactable = true;
               
            }
        }
        if (DontDestroyUserData.storyNumber >= 8)
        {
            check = GameObject.Find("Chapter3Stage1lock");
            if (check != false)
            {
                Destroy(GameObject.Find("Chapter3Stage1lock"));
                GameObject.Find("Chapter3Stage1Button").GetComponent<Button>().interactable = true;
            }
        }
        if (DontDestroyUserData.storyNumber >= 9)
        {
            check = GameObject.Find("Chapter3Stage2lock");
            if (check != false)
            {
                Destroy(GameObject.Find("Chapter3Stage2lock"));
                GameObject.Find("Chapter3Stage2Button").GetComponent<Button>().interactable = true;
               
            }
        }
        if (DontDestroyUserData.storyNumber >= 10)
        {
            check = GameObject.Find("Chapter3Stage3lock");
            if (check != false)
            {
                Destroy(GameObject.Find("Chapter3Stage3lock"));
                GameObject.Find("Chapter3Stage3Button").GetComponent<Button>().interactable = true;
                
            }
        }
        if (DontDestroyUserData.storyNumber >= 11)
        {
            check = GameObject.Find("Chapter3Stage4lock");
            if (check != false)
            {
                Destroy(GameObject.Find("Chapter3Stage4lock"));
                GameObject.Find("Chapter3Stage4Button").GetComponent<Button>().interactable = true;
            }
        }
        if (DontDestroyUserData.storyNumber >= 12)
        {

            check = GameObject.Find("Chapter4Stage1lock");
            if (check != false)
            {
                Destroy(GameObject.Find("Chapter4Stage1lock"));
                GameObject.Find("Chapter4Stage1Button").GetComponent<Button>().interactable = true;
            }
        }
    }


}
