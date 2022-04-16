using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChapterClear : MonoBehaviour
{
    const string chapter1ClearImagePath = "Images/stageImage/ChapterClear/Chapter1Clear";
    const string chapter2ClearImagePath = "Images/stageImage/ChapterClear/Chapter2Clear";
    const string chapter3ClearImagePath = "Images/stageImage/ChapterClear/Chapter3Clear";
    const string chapter4ClearImagePath = "Images/stageImage/ChapterClear/Chapter4Clear";

    public GameObject chapter1Clear;
    public GameObject chapter2Clear;
    public GameObject chapter3Clear;
    public GameObject chapter4Clear;
    static public int chapterClear = 0;

 

    private void Update()
    {
        if(DontDestroyUserData.storyNumber >= 4)
        {
            chapter1Clear.GetComponent<Image>().sprite = Resources.Load<Sprite>(chapter1ClearImagePath);
        }
        if (DontDestroyUserData.storyNumber >= 8)
        {
            chapter2Clear.GetComponent<Image>().sprite = Resources.Load<Sprite>(chapter2ClearImagePath);
        }
        if (DontDestroyUserData.storyNumber >= 12)
        {
            chapter3Clear.GetComponent<Image>().sprite = Resources.Load<Sprite>(chapter3ClearImagePath);
        }
        if (DontDestroyUserData.storyNumber >= 13)
        {
            chapter4Clear.GetComponent<Image>().sprite = Resources.Load<Sprite>(chapter4ClearImagePath);
        }
    }
    public void GoChapter1()
    {
        chapterClear = 1;
    }
    public void GoChapter2()
    {
        chapterClear = 2;
    }
    public void GoChapter3()
    {
        chapterClear = 3;
    }
    public void GoChapter4()
    {
        chapterClear = 4;
    }
}
