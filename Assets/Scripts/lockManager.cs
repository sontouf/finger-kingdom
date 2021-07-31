using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lockManager : MonoBehaviour
{

    private void Update()
    {
        if (DontDestroyUserData.storyNumber >= 1)
        {
            Destroy(GameObject.Find("stage2lock"));
            GameObject.Find("Stage2Button").GetComponent<Button>().interactable = true;
        }
        if (DontDestroyUserData.storyNumber >= 2)
        {
            Destroy(GameObject.Find("stage3lock"));
            GameObject.Find("Stage3Button").GetComponent<Button>().interactable = true;
        }
        if (DontDestroyUserData.storyNumber >= 3)
        {
            Destroy(GameObject.Find("stage4lock"));
            GameObject.Find("Stage4Button").GetComponent<Button>().interactable = true;
        }
    }

}
