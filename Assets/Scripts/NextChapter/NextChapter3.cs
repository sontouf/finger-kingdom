using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextChapter3 : MonoBehaviour
{
    public GameObject nextChapter;
    void Update()
    {
        if (DontDestroyUserData.storyNumber >= 8)
        {
            nextChapter.SetActive(true);
        }
    }
}
