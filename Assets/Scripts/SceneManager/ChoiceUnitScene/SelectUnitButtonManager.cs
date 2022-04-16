using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectUnitButtonManager : MonoBehaviour
{
    //const string selectUnitButtonPrefabPath = "Prefabs/SelectUnitButtonPrefab";
    //const string warriorImagePath = "Images/warrior";
    //const string archerImagePath = "Images/archer";
    const string shieldImagePath = "Images/shield";
    const string cavalryImagePath = "Images/cavalry";
    const string healerImagePath = "Images/healer";
    const string bomberImagePath = "Images/bomber";
    const string siegeWeaponImagePath = "Images/siegeWeapon";
    const string woodFenceImagePath = "Images/woodFence";
    const string cannonImagePath = "Images/cannon";
    const string paladinImagePath = "Images/paladin";

    public UnitStatsData unitStatsData;
    public GameObject warriorInfo;
    public GameObject warriorDescription;
    public GameObject archerInfo;
    public GameObject archerDescription;
    public GameObject shieldObject;
    public GameObject shieldInfo;
    public GameObject shieldDescription;
    public GameObject healerObject;
    public GameObject healerInfo;
    public GameObject healerDescription;
    public GameObject cavalryObject;
    public GameObject cavalryInfo;
    public GameObject cavalryDescription;
    public GameObject bomberObject;
    public GameObject bomberInfo;
    public GameObject bomberDescription;
    public GameObject siegeWeaponObject;
    public GameObject siegeWeaponInfo;
    public GameObject siegeWeaponDescription;
    public GameObject woodFenceObject;
    public GameObject woodFenceInfo;
    public GameObject woodFenceDescription;
    public GameObject cannonObject;
    public GameObject cannonInfo;
    public GameObject cannonDescription;
    public GameObject paladinObject;
    public GameObject paladinInfo;
    public GameObject paladinDescription;

    string UnitName;
    static public int tutorialCount;
    private void Start()
    {
        tutorialCount = 0;
        UnitInfoSetActive(false, false, false, false, false, false, false, false, false, false);
        UnitDescriptionSetActive(false, false, false, false, false, false, false, false, false, false);
    }

    public void ClickWarriorButton()
    {
        int warriorPlusNum = CurrentCostScript.curCost + 2;
        if (warriorPlusNum <= MaxCostScript.maxCostValue)
            SelectedUnitData.AddUnitCount<WarriorEgg>();
        UnitDescriptionSetActive(true, false, false, false, false, false, false, false, false, false);
        unitStatsData.WarriorStats();
        UnitName = "warrior";
    }
    public void ClickArcherButton()
    {
        int archerPlusNum = CurrentCostScript.curCost + 2;
        if (archerPlusNum <= MaxCostScript.maxCostValue)
            SelectedUnitData.AddUnitCount<ArcherEgg>();
        UnitDescriptionSetActive(false, true, false, false, false, false, false, false, false, false);
        unitStatsData.ArcherStats();
        UnitName = "archer";
    }
    public void ClickShieldButton()
    {
        if (shieldObject.GetComponent<Image>().sprite == Resources.Load<Sprite>(shieldImagePath)) // 쉴드가 해금되면.
        {
            int shieldPlusNum = CurrentCostScript.curCost + 4;
            if (shieldPlusNum <= MaxCostScript.maxCostValue)
                SelectedUnitData.AddUnitCount<ShieldEgg>();
            UnitDescriptionSetActive(false, false, true, false, false, false, false, false, false, false);
            unitStatsData.ShieldStats();
            UnitName = "shield";
        }

    }

    public void ClickCavalryButton()
    {
        if (cavalryObject.GetComponent<Image>().sprite == Resources.Load<Sprite>(cavalryImagePath))
        {
            int cavalryPlusNum = CurrentCostScript.curCost + 5;
            if (cavalryPlusNum <= MaxCostScript.maxCostValue)
                SelectedUnitData.AddUnitCount<CavalryEgg>();
            UnitDescriptionSetActive(false, false, false, false, true, false, false, false, false, false);
            unitStatsData.CavalryStats();
            UnitName = "cavalry";
        }


    }

    public void ClickHealerButton()
    {
        if (healerObject.GetComponent<Image>().sprite == Resources.Load<Sprite>(healerImagePath))
        {
            int healerPlusNum = CurrentCostScript.curCost + 4;
            if (healerPlusNum <= MaxCostScript.maxCostValue)
                SelectedUnitData.AddUnitCount<HealerEgg>();
            UnitDescriptionSetActive(false, false, false, true, false, false, false, false, false, false);
            unitStatsData.HealerStats();
            UnitName = "healer";
        }


    }
    public void ClickBomberButton()
    {
        if (bomberObject.GetComponent<Image>().sprite == Resources.Load<Sprite>(bomberImagePath))
        {
            int bomberPlusNum = CurrentCostScript.curCost + 3;
            if (bomberPlusNum <= MaxCostScript.maxCostValue && SelectedUnitData.unitCounts[typeof(BomberEgg)] <= 2)
                SelectedUnitData.AddUnitCount<BomberEgg>();
            UnitDescriptionSetActive(false, false, false, false, false, true, false, false, false, false);
            unitStatsData.BomberStats();
            UnitName = "bomber";
        }


    }
    public void ClickSiegeWeaponButton()
    {
        if (siegeWeaponObject.GetComponent<Image>().sprite == Resources.Load<Sprite>(siegeWeaponImagePath))
        {
            int siegeWeaponPlusNum = CurrentCostScript.curCost + 3;
            if (siegeWeaponPlusNum <= MaxCostScript.maxCostValue)
                SelectedUnitData.AddUnitCount<SiegeWeaponEgg>();
            UnitDescriptionSetActive(false, false, false, false, false, false, true, false, false, false);
            unitStatsData.SiegeWeaponStats();
            UnitName = "siegeWeapon";

        }

    }
    public void ClickCannonButton()
    {
        if (cannonObject.GetComponent<Image>().sprite == Resources.Load<Sprite>(cannonImagePath))
        {
            int cannonPlusNum = CurrentCostScript.curCost + 3;
            if (cannonPlusNum <= MaxCostScript.maxCostValue)
                SelectedUnitData.AddUnitCount<CannonEgg>();
            UnitDescriptionSetActive(false, false, false, false, false, false, false, true, false, false);
            unitStatsData.CannonStats();
            UnitName = "cannon";
        }

    }
    public void ClickPaladinButton()
    {
        if (paladinObject.GetComponent<Image>().sprite == Resources.Load<Sprite>(paladinImagePath))
        {
            int paladinPlusNum = CurrentCostScript.curCost + 6;
            if (paladinPlusNum <= MaxCostScript.maxCostValue && SelectedUnitData.unitCounts[typeof(PaladinEgg)] <= 2)
                SelectedUnitData.AddUnitCount<PaladinEgg>();
            UnitDescriptionSetActive(false, false, false, false, false, false, false, false, true, false);
            unitStatsData.PaladinStats();
            UnitName = "paladin";
        }

    }
    public void ClickWoodFenceButton()
    {
        if (woodFenceObject.GetComponent<Image>().sprite == Resources.Load<Sprite>(woodFenceImagePath))
        {
            int woodFencePlusNum = CurrentCostScript.curCost + 1;
            if (woodFencePlusNum <= MaxCostScript.maxCostValue)
                SelectedUnitData.AddUnitCount<WoodFenceEgg>();
            UnitDescriptionSetActive(false, false, false, false, false, false, false, false, false, true);
            unitStatsData.WoodFenceStats();
            UnitName = "woodFence";
        }

    }

    public void UnitInfoSetActive(bool warrior, bool archer, bool shield, bool healer, bool cavalry, bool bomber, bool siegeWeapon,
        bool cannon, bool paladin, bool woodFence)
    {
        warriorInfo.SetActive(warrior);
        archerInfo.SetActive(archer);
        shieldInfo.SetActive(shield);
        healerInfo.SetActive(healer);
        cavalryInfo.SetActive(cavalry);
        bomberInfo.SetActive(bomber);
        siegeWeaponInfo.SetActive(siegeWeapon);
        cannonInfo.SetActive(cannon);
        paladinInfo.SetActive(paladin);
        woodFenceInfo.SetActive(woodFence);
    }
    public void UnitDescriptionSetActive(bool warrior, bool archer, bool shield, bool healer, bool cavalry, bool bomber, bool siegeWeapon,
    bool cannon, bool paladin, bool woodFence)
    {
        warriorDescription.SetActive(warrior);
        archerDescription.SetActive(archer);
        shieldDescription.SetActive(shield);
        healerDescription.SetActive(healer);
        cavalryDescription.SetActive(cavalry);
        bomberDescription.SetActive(bomber);
        siegeWeaponDescription.SetActive(siegeWeapon);
        cannonDescription.SetActive(cannon);
        paladinDescription.SetActive(paladin);
        woodFenceDescription.SetActive(woodFence);
    }

    public void OnUnitStory()
    {
        if (UnitName == "warrior")
        {
            UnitDescriptionSetActive(false, false, false, false, false, false, false, false, false, false);
            UnitInfoSetActive(true, false, false, false, false, false, false, false, false, false);
        }
        if (UnitName == "archer")
        {
            UnitDescriptionSetActive(false, false, false, false, false, false, false, false, false, false);
            UnitInfoSetActive(false, true, false, false, false, false, false, false, false, false);
        }
        if (UnitName == "shield")
        {
            UnitDescriptionSetActive(false, false, false, false, false, false, false, false, false, false);
            UnitInfoSetActive(false, false, true, false, false, false, false, false, false, false);
        }
        if (UnitName == "healer")
        {
            UnitDescriptionSetActive(false, false, false, false, false, false, false, false, false, false);
            UnitInfoSetActive(false, false, false, true, false, false, false, false, false, false);
        }
        if (UnitName == "cavalry")
        {
            UnitDescriptionSetActive(false, false, false, false, false, false, false, false, false, false);
            UnitInfoSetActive(false, false, false, false, true, false, false, false, false, false);
        }
        if (UnitName == "bomber")
        {
            UnitDescriptionSetActive(false, false, false, false, false, false, false, false, false, false);
            UnitInfoSetActive(false, false, false, false, false, true, false, false, false, false);
        }
        if (UnitName == "siegeWeapon")
        {
            UnitDescriptionSetActive(false, false, false, false, false, false, false, false, false, false);
            UnitInfoSetActive(false, false, false, false, false, false, true, false, false, false);
        }
        if (UnitName == "cannon")
        {
            UnitDescriptionSetActive(false, false, false, false, false, false, false, false, false, false);
            UnitInfoSetActive(false, false, false, false, false, false, false, true, false, false);
        }
        if (UnitName == "paladin")
        {
            UnitDescriptionSetActive(false, false, false, false, false, false, false, false, false, false);
            UnitInfoSetActive(false, false, false, false, false, false, false, false, true, false);
        }
        if (UnitName == "woodFence")
        {
            UnitDescriptionSetActive(false, false, false, false, false, false, false, false, false, false);
            UnitInfoSetActive(false, false, false, false, false, false, false, false, false, true);
        }
    }
    public void OffUnitStory()
    {
        if (UnitName == "warrior")
        {
            UnitDescriptionSetActive(true, false, false, false, false, false, false, false, false, false);
            UnitInfoSetActive(false, false, false, false, false, false, false, false, false, false);
        }
        if (UnitName == "archer")
        {
            UnitDescriptionSetActive(false, true, false, false, false, false, false, false, false, false);
            UnitInfoSetActive(false, false, false, false, false, false, false, false, false, false);
        }
        if (UnitName == "shield")
        {
            UnitDescriptionSetActive(false, false, true, false, false, false, false, false, false, false);
            UnitInfoSetActive(false, false, false, false, false, false, false, false, false, false);
        }
        if (UnitName == "healer")
        {
            UnitDescriptionSetActive(false, false, false, true, false, false, false, false, false, false);
            UnitInfoSetActive(false, false, false, false, false, false, false, false, false, false);
        }
        if (UnitName == "cavalry")
        {
            UnitDescriptionSetActive(false, false, false, false, true, false, false, false, false, false);
            UnitInfoSetActive(false, false, false, false, false, false, false, false, false, false);
        }
        if (UnitName == "bomber")
        {
            UnitDescriptionSetActive(false, false, false, false, false, true, false, false, false, false);
            UnitInfoSetActive(false, false, false, false, false, false, false, false, false, false);
        }
        if (UnitName == "siegeWeapon")
        {
            UnitDescriptionSetActive(false, false, false, false, false, false, true, false, false, false);
            UnitInfoSetActive(false, false, false, false, false, false, false, false, false, false);
        }
        if (UnitName == "cannon")
        {
            UnitDescriptionSetActive(false, false, false, false, false, false, false, true, false, false);
            UnitInfoSetActive(false, false, false, false, false, false, false, false, false, false);
        }
        if (UnitName == "paladin")
        {
            UnitDescriptionSetActive(false, false, false, false, false, false, false, false, true, false);
            UnitInfoSetActive(false, false, false, false, false, false, false, false, false, false);
        }
        if (UnitName == "woodFence")
        {
            UnitDescriptionSetActive(false, false, false, false, false, false, false, false, false, true);
            UnitInfoSetActive(false, false, false, false, false, false, false, false, false, false);
        }
    }
}
