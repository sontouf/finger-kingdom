using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storyUp : MonoBehaviour
{
    public void UpStoryNumber()
    {
        DontDestroyUserData.storyNumber += 1;
    }
    public void DownStoryNumber()
    {
        if(DontDestroyUserData.storyNumber >= 1)
            DontDestroyUserData.storyNumber -= 1;

    }
}
