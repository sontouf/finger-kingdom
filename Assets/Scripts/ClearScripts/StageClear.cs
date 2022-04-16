using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClear : MonoBehaviour
{
    public GameObject stage1Clear;
    public GameObject stage2Clear;
    public GameObject stage3Clear;
    public GameObject stage4Clear;

    private void Update()
    {
        if (ChapterClear.chapterClear == 1)
        {
            if (DontDestroyUserData.storyNumber >= 1)
            {
                stage1Clear.SetActive(true);
            }
            if (DontDestroyUserData.storyNumber >= 2)
            {
                stage2Clear.SetActive(true);
            }
            if (DontDestroyUserData.storyNumber >= 3)
            {
                stage3Clear.SetActive(true);
            }
            if (DontDestroyUserData.storyNumber >= 4)
            {
                stage4Clear.SetActive(true);
            }
        }
        else if (ChapterClear.chapterClear == 2)
        {
            if (DontDestroyUserData.storyNumber >= 5)
            {
                stage1Clear.SetActive(true);
            }
            if (DontDestroyUserData.storyNumber >= 6)
            {
                stage2Clear.SetActive(true);
            }
            if (DontDestroyUserData.storyNumber >= 7)
            {
                stage3Clear.SetActive(true);
            }
            if (DontDestroyUserData.storyNumber >= 8)
            {
                stage4Clear.SetActive(true);
            }
        }
        else if (ChapterClear.chapterClear == 3)
        {
            if (DontDestroyUserData.storyNumber >= 9)
            {
                stage1Clear.SetActive(true);
            }
            if (DontDestroyUserData.storyNumber >= 10)
            {
                stage2Clear.SetActive(true);
            }
            if (DontDestroyUserData.storyNumber >= 11)
            {
                stage3Clear.SetActive(true);
            }
            if (DontDestroyUserData.storyNumber >= 12)
            {
                stage4Clear.SetActive(true);
            }
        }
        else if (ChapterClear.chapterClear == 4)
        {
            if (DontDestroyUserData.storyNumber >= 13)
            {
                stage1Clear.SetActive(true);
            }

        }

    }
}
