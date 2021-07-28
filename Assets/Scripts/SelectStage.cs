using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectStage : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (DontDestroyUserData.stageClearCheck == true)
        {
            DontDestroyUserData.storyNumber += 1;
            DontDestroyUserData.stageClearCheck = !DontDestroyUserData.stageClearCheck;
            SelectedUnitData.warriorNumber = 0;
            SelectedUnitData.archerNumber = 0;
            SelectedUnitData.shieldNumber = 0;
            SelectedUnitData.cavalryNumber = 0;
            SelectedUnitData.healerNumber = 0;
        }
    }
}
