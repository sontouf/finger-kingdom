using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SelectedUnitNumber : MonoBehaviour
{
    public Text warriorNum;
    public Text archerNum;
    public Text woodFenceNum;
    public Text shieldNum;
    public Text bomberNum;
    public Text healerNum;
    public Text siegeWeaponNum;
    public Text cavalryNum;
    public Text cannonNum;
    public Text paladinNum;
    private void Start()
    {
        warriorNum = GameObject.Find("WarriorNum").GetComponent<Text>();
        archerNum = GameObject.Find("ArcherNum").GetComponent<Text>();
        woodFenceNum = GameObject.Find("WoodFenceNum").GetComponent<Text>();
        shieldNum = GameObject.Find("ShieldNum").GetComponent<Text>();
        bomberNum = GameObject.Find("BomberNum").GetComponent<Text>();
        healerNum = GameObject.Find("HealerNum").GetComponent<Text>();
        siegeWeaponNum = GameObject.Find("SiegeWeaponNum").GetComponent<Text>();
        cavalryNum = GameObject.Find("CavalryNum").GetComponent<Text>();
        cannonNum = GameObject.Find("CannonNum").GetComponent<Text>();
        paladinNum = GameObject.Find("PaladinNum").GetComponent<Text>();
}

    // Update is called once per frame
    void Update()
    {
        warriorNum.text = "" + SelectedUnitData.GetUnitCount<WarriorEgg>();
        archerNum.text = "" + SelectedUnitData.GetUnitCount<ArcherEgg>();
        woodFenceNum.text = "" + SelectedUnitData.GetUnitCount<WoodFenceEgg>();
        shieldNum.text = "" + SelectedUnitData.GetUnitCount<ShieldEgg>();
        bomberNum.text = "" + SelectedUnitData.GetUnitCount<BomberEgg>();
        healerNum.text = "" + SelectedUnitData.GetUnitCount<HealerEgg>();
        siegeWeaponNum.text = "" + SelectedUnitData.GetUnitCount<SiegeWeaponEgg>();
        cavalryNum.text = "" + SelectedUnitData.GetUnitCount<CavalryEgg>();
        cannonNum.text = "" + SelectedUnitData.GetUnitCount<CannonEgg>();
        paladinNum.text = "" + SelectedUnitData.GetUnitCount<PaladinEgg>();

    }
}
