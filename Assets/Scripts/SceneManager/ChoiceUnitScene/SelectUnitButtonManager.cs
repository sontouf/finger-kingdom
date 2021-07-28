using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectUnitButtonManager : MonoBehaviour
{
    const string selectUnitButtonPrefabPath = "Prefabs/SelectUnitButtonPrefab";
    const string warriorImagePath = "Images/warrior";
    const string archerImagePath = "Images/archer";
    const string shieldImagePath = "Images/shield";
    const string cavalryImagePath = "Images/cavalry";
    const string healerImagePath = "Images/healer";

    static private GameObject selectUnitButtonPrefab;
    static public GameObject selectUnitSpace;

    private Button mybutton;
    private void Start()
    {
       
        mybutton = this.transform.GetComponent<Button>();
        if (this.gameObject.tag == "Warrior")
            mybutton.onClick.AddListener(ClickWarriorButton);
        else if (this.gameObject.tag == "Archer")
            mybutton.onClick.AddListener(ClickArcherButton);
        else if (this.gameObject.tag == "Shield")
            mybutton.onClick.AddListener(ClickShieldButton);
        else if (this.gameObject.tag == "Cavalry")
            mybutton.onClick.AddListener(ClickCavalryButton);
        else if (this.gameObject.tag == "Healer")
            mybutton.onClick.AddListener(ClickHealerButton);
    }


    static public GameObject CreateSelectUnitButton(string imagePath, Vector3 pos, string tagName, GameObject parentObject)
    {
        selectUnitButtonPrefab = Resources.Load(selectUnitButtonPrefabPath) as GameObject;
        selectUnitSpace = parentObject.transform.GetChild(0).gameObject;

        GameObject selectUnitButton = Instantiate(selectUnitButtonPrefab, pos, Quaternion.identity);
        selectUnitButton.transform.SetParent(selectUnitSpace.transform);

        selectUnitButton.tag = tagName;

        selectUnitButton.AddComponent<SelectUnitButtonManager>();


        Sprite image = Resources.Load<Sprite>(imagePath); // 스프라이트의 위치를 통해 받아온 스프라이트를 image에 저장해둔다.
        selectUnitButton.GetComponent<Image>().sprite = image; // 저장한 스프라이트를 실제 객체의 sprite로 전달.

        return selectUnitButton;
    }


    public void ClickWarriorButton()
    {
        int warriorPlusNum = CurrentCostScript.curCost + 2;
        if (warriorPlusNum <= MaxCostScript.maxCostValue)
            SelectedUnitData.warriorNumber += 1;

    }
    public void ClickArcherButton()
    {
        if (this.gameObject.GetComponent<Image>().sprite == Resources.Load<Sprite>(archerImagePath))
        {
            int archerPlusNum = CurrentCostScript.curCost + 2;
            if (archerPlusNum <= MaxCostScript.maxCostValue)
                SelectedUnitData.archerNumber += 1;
        }
    }
    public void ClickShieldButton()
    {
        if (this.gameObject.GetComponent<Image>().sprite == Resources.Load<Sprite>(shieldImagePath))
        {
            int shieldPlusNum = CurrentCostScript.curCost + 4;
            if (shieldPlusNum <= MaxCostScript.maxCostValue)
                SelectedUnitData.shieldNumber += 1;
        }
    }

    public void ClickCavalryButton()
    {
        if (this.gameObject.GetComponent<Image>().sprite == Resources.Load<Sprite>(cavalryImagePath))
        {
            int cavalryPlusNum = CurrentCostScript.curCost + 6;
            if (cavalryPlusNum <= MaxCostScript.maxCostValue)
                SelectedUnitData.cavalryNumber += 1;
        }
    }

    public void ClickHealerButton()
    {
        if (this.gameObject.GetComponent<Image>().sprite == Resources.Load<Sprite>(healerImagePath))
        {
            int healerPlusNum = CurrentCostScript.curCost + 4;
            if (healerPlusNum <= MaxCostScript.maxCostValue)
                SelectedUnitData.healerNumber += 1;
        }
    }


}
