using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedUnitButtonManager : MonoBehaviour
{
    const string selectedUnitButtonPrefabPath = "Prefabs/SelectedUnitButtonPrefab";

    static private GameObject selectedUnitButtonPrefab;
    static public GameObject selectedUnitSpace;


    private Button myButton;

    private void Start()
    {
        myButton = this.transform.GetComponent<Button>();
        if (this.gameObject.tag == "Warrior")
        {
            myButton.onClick.AddListener(ClickSelectedWarriorButton);
        }
        else if (this.gameObject.tag == "Archer")
        {
            myButton.onClick.AddListener(ClickSelectedArcherButton);
        }
        else if (this.gameObject.tag == "Shield")
        {
            myButton.onClick.AddListener(ClickSelectedShieldButton);
        }
        else if (this.gameObject.tag == "Cavalry")
        {
            myButton.onClick.AddListener(ClickSelectedCavalryButton);
        }
        else if (this.gameObject.tag == "Healer")
        {
            myButton.onClick.AddListener(ClickSelectedHealerButton);
        }
    }

    static public GameObject CreateSelectedUnitButton(string imagePath, Vector3 pos, string tagName, GameObject canvasObject)
    {
        selectedUnitButtonPrefab = Resources.Load(selectedUnitButtonPrefabPath) as GameObject;
        selectedUnitSpace = canvasObject.transform.GetChild(1).gameObject;



        GameObject selectedUnitButton = Instantiate(selectedUnitButtonPrefab, pos, Quaternion.identity);
        selectedUnitButton.transform.SetParent(selectedUnitSpace.transform);

        selectedUnitButton.tag = tagName;

        selectedUnitButton.AddComponent<SelectedUnitButtonManager>();


        Sprite image = Resources.Load<Sprite>(imagePath);
        selectedUnitButton.GetComponent<Image>().sprite = image;

        return selectedUnitButton;
    }



    public void ClickSelectedWarriorButton()
    {
        if (SelectedUnitData.warriorNumber >= 1)
            SelectedUnitData.warriorNumber -= 1;
    }
    public void ClickSelectedArcherButton()
    {
        if (SelectedUnitData.archerNumber >= 1)
            SelectedUnitData.archerNumber -= 1;
    }
    public void ClickSelectedShieldButton()
    {
        if (SelectedUnitData.shieldNumber >= 1)
            SelectedUnitData.shieldNumber -= 1;
    }
    public void ClickSelectedCavalryButton()
    {
        if (SelectedUnitData.cavalryNumber >= 1)
            SelectedUnitData.cavalryNumber -= 1;
    }
    public void ClickSelectedHealerButton()
    {
        if (SelectedUnitData.healerNumber >= 1)
            SelectedUnitData.healerNumber -= 1;
    }

}
