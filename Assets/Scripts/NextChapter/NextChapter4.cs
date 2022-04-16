using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextChapter4 : MonoBehaviour
{
    public GameObject nextChapter;
    void Update()
    {
        if (DontDestroyUserData.storyNumber >= 12)
        {
            nextChapter.SetActive(true);
        }
    }
}
