using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextChapter2 : MonoBehaviour
{
    public GameObject nextChapter;
    // Update is called once per frame
    void Update()
    {
        if (DontDestroyUserData.storyNumber >= 4)
        {
            nextChapter.SetActive(true);
        }
    }
}
