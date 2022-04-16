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
        text = GameObject.Find("CurCost").GetComponent<Text>();
        curCost = SelectedUnitData.unitCounts[typeof(WarriorEgg)] * 2 + SelectedUnitData.unitCounts[typeof(ArcherEgg)] * 2
            + SelectedUnitData.unitCounts[typeof(ShieldEgg)] * 4 + SelectedUnitData.unitCounts[typeof(CavalryEgg)] * 5
            + SelectedUnitData.unitCounts[typeof(HealerEgg)] * 4 + SelectedUnitData.unitCounts[typeof(BomberEgg)] * 3
            + SelectedUnitData.unitCounts[typeof(SiegeWeaponEgg)] * 4 + SelectedUnitData.unitCounts[typeof(PaladinEgg)] * 6
            + SelectedUnitData.unitCounts[typeof(CannonEgg)] * 3 + SelectedUnitData.unitCounts[typeof(WoodFenceEgg)] * 1;
        if (curCost > MaxCostScript.maxCostValue)
        {
            curCost = MaxCostScript.maxCostValue;
        }
        text.text = "" + curCost;
    }
}
