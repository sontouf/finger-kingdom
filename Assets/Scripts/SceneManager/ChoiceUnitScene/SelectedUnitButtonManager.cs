using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedUnitButtonManager : MonoBehaviour
{

    public void ClickSelectedWarriorButton()
    {
        if (SelectedUnitData.GetUnitCount<WarriorEgg>()>= 1)
            SelectedUnitData.unitCounts[typeof(WarriorEgg)] -= 1;
    }
    public void ClickSelectedArcherButton()
    {
        if (SelectedUnitData.GetUnitCount<ArcherEgg>() >= 1)
            SelectedUnitData.unitCounts[typeof(ArcherEgg)] -= 1;
    }
    public void ClickSelectedShieldButton()
    {
        if (SelectedUnitData.GetUnitCount<ShieldEgg>() >= 1)
            SelectedUnitData.unitCounts[typeof(ShieldEgg)] -= 1;
    }
    public void ClickSelectedCavalryButton()
    {
        if (SelectedUnitData.GetUnitCount<CavalryEgg>() >= 1)
            SelectedUnitData.unitCounts[typeof(CavalryEgg)] -= 1;
    }
    public void ClickSelectedHealerButton()
    {
        if (SelectedUnitData.GetUnitCount<HealerEgg>() >= 1)
            SelectedUnitData.unitCounts[typeof(HealerEgg)] -= 1;
    }
    public void ClickSelectedWoodFenceButton()
    {
        if (SelectedUnitData.GetUnitCount<WoodFenceEgg>() >= 1)
            SelectedUnitData.unitCounts[typeof(WoodFenceEgg)] -= 1;
    }
    public void ClickSelectedSiegeWeaponButton()
    {
        if (SelectedUnitData.GetUnitCount<SiegeWeaponEgg>() >= 1)
            SelectedUnitData.unitCounts[typeof(SiegeWeaponEgg)] -= 1;
    }
    public void ClickSelectedCannonButton()
    {
        if (SelectedUnitData.GetUnitCount<CannonEgg>() >= 1)
            SelectedUnitData.unitCounts[typeof(CannonEgg)] -= 1;
    }
    public void ClickSelectedPaladinButton()
    {
        if (SelectedUnitData.GetUnitCount<PaladinEgg>() >= 1)
            SelectedUnitData.unitCounts[typeof(PaladinEgg)] -= 1;
    }
    public void ClickSelectedBomberButton()
    {
        if (SelectedUnitData.GetUnitCount<BomberEgg>() >= 1)
            SelectedUnitData.unitCounts[typeof(BomberEgg)] -= 1;
    }

}
