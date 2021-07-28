using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CurrentCostScript : MonoBehaviour
{
    static public int curCost;
    public Text text;
    private void Update()
    {
 
        curCost = SelectedUnitData.warriorNumber * 2 + SelectedUnitData.archerNumber * 2
            + SelectedUnitData.shieldNumber * 4 + SelectedUnitData.cavalryNumber * 6
            + SelectedUnitData.healerNumber * 4;
        if (curCost > MaxCostScript.maxCostValue)
        {
            curCost = MaxCostScript.maxCostValue;
        }
        text.text = "" + curCost;
    }
}
