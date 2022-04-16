using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Chapter4StageClear : MonoBehaviour
{
    const string stage4ClearImagePath = "Images/stageImage/Chapter4StageClear/Stage1Clear";

    public GameObject stage1Clear;

    private void Update()
    {
        if (DontDestroyUserData.storyNumber >= 13)
        {
            stage1Clear.GetComponent<Image>().sprite = Resources.Load<Sprite>(stage4ClearImagePath);
        }

    }
}
