using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Chapter3StageClear : MonoBehaviour
{
    const string stage1ClearImagePath = "Images/stageImage/Chapter3StageClear/stage1Clear";
    const string stage2ClearImagePath = "Images/stageImage/Chapter3StageClear/stage2Clear";
    const string stage3ClearImagePath = "Images/stageImage/Chapter3StageClear/stage3Clear";
    const string stage4ClearImagePath = "Images/stageImage/Chapter3StageClear/stage4Clear";

    public GameObject stage1Clear;
    public GameObject stage2Clear;
    public GameObject stage3Clear;
    public GameObject stage4Clear;

    private void Update()
    {
        if (DontDestroyUserData.storyNumber >= 9)
        {
            stage1Clear.GetComponent<Image>().sprite = Resources.Load<Sprite>(stage1ClearImagePath);

            if (DontDestroyUserData.storyNumber >= 10)
            {
                stage2Clear.GetComponent<Image>().sprite = Resources.Load<Sprite>(stage2ClearImagePath);

                if (DontDestroyUserData.storyNumber >= 11)
                {
                    stage3Clear.GetComponent<Image>().sprite = Resources.Load<Sprite>(stage3ClearImagePath);

                    if (DontDestroyUserData.storyNumber >= 12)
                    {
                        stage4Clear.GetComponent<Image>().sprite = Resources.Load<Sprite>(stage4ClearImagePath);
                    }
                }
            }
        }
    }
}
