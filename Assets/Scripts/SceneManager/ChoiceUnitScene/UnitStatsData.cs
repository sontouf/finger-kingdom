using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitStatsData : MonoBehaviour
{
    int hp;
    int damage;
    int speed;
    float defence;
    int heal;
    int cost;
    Text hpText;
    Text damageText;
    Text speedText;
    Text defenceText;
    Text healText;
    Text costText;

    public WarriorEgg warrior;
    public ArcherEgg archer;
    public Archer_arrow arrow;
    public ShieldEgg shield;
    public BomberEgg bomber;
    public HealerEgg healer;
    public SiegeWeaponEgg siegeWeapon;
    public CavalryEgg cavalry;
    public CannonEgg cannon;
    public Cannon_ball cannon_Ball;
    public PaladinEgg paladin;
    private void Start()
    {
        hpText = GameObject.Find("Hp").GetComponent<Text>();
        damageText = GameObject.Find("Damage").GetComponent<Text>();
        speedText = GameObject.Find("Speed").GetComponent<Text>();
        defenceText = GameObject.Find("Defence").GetComponent<Text>();
        healText = GameObject.Find("Heal").GetComponent<Text>();
        costText = GameObject.Find("Cost").GetComponent<Text>();

    }

    public void WarriorStats()
    {
        hpText.text = "" + 150;
        damageText.text = "" + 20;
        speedText.text = "" + 50;
        defenceText.text = "" + 1;
        healText.text = "0";
        costText.text = "" + 2;
    }
    public void ArcherStats()
    {
        hpText.text = "" + 70;
        damageText.text = "" + 25;
        speedText.text = "" + 10;
        defenceText.text = "" + 1;
        healText.text = "0";
        costText.text = "" + 2;
    }
    public void WoodFenceStats()
    {
        hpText.text = "" + 150;
        damageText.text = "" + 0;
        speedText.text = "" + 100;
        defenceText.text = "" + 3;
        healText.text = "0";
        costText.text = "" + 1;
    }
    public void ShieldStats()
    {
        hpText.text = "" + 250;
        damageText.text = "" + 25;
        speedText.text = "" + 100;
        defenceText.text = "" + 5;
        healText.text = "0";
        costText.text = "" + 4;
    }
    public void BomberStats()
    {
        hpText.text = "" + 1;
        damageText.text = "" + 150;
        speedText.text = "" + 100;
        defenceText.text = "" + 2;
        healText.text = "0";
        costText.text = "" + 3;
    }
    public void HealerStats()
    {
        hpText.text = "" + 100;
        damageText.text = "" + 5;
        speedText.text = "" + 60;
        defenceText.text = "" + 2;
        healText.text = "" + 40;
        costText.text = "" + 4;
    }
    public void SiegeWeaponStats()
    {
        hpText.text = "" + 250;
        damageText.text = "" + 20;
        speedText.text = "" + 70;
        defenceText.text = "" + 5;
        healText.text = "0";
        costText.text = "" + 3;
    }
    public void CavalryStats()
    {
        hpText.text = "" + 350;
        damageText.text = "" + 35;
        speedText.text = "" + 200;
        defenceText.text = "" + 5;
        healText.text = "0";
        costText.text = "" + 5;
    }
    public void CannonStats()
    {
        hpText.text = "" + 150;
        damageText.text = "" + 55;
        speedText.text = "" + 0;
        defenceText.text = "" + 3;
        healText.text = "0";
        costText.text = "" + 3;
    }
    public void PaladinStats()
    {
        hpText.text = "" + 500;
        damageText.text = "" + 50;
        speedText.text = "" + 200;
        defenceText.text = "" + 3;
        healText.text = "" + 25;
        costText.text = "" + 6;
    }
}
