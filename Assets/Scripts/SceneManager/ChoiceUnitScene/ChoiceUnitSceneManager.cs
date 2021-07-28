using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChoiceUnitSceneManager : MonoBehaviour
{

    const string warriorImagePath = "Images/warrior";
    const string archerImagePath = "Images/archer";
    const string shieldImagePath = "Images/shield";
    const string cavalryImagePath = "Images/cavalry";
    const string healerImagePath = "Images/healer";

    // ====== yetImage =====
    const string privateWarriorImagePath = "Images/warrior";
    const string privateArcherImagePath = "Images/private/privateArcher";
    const string privateShieldImagePath = "Images/private/privateShield";
    const string privateCavalryImagePath = "Images/private/privateCavalry";
    const string privateHealerImagePath = "Images/private/privateHealer";



    // =================== selectUnitButtonPosition ================
    Vector3 p1 = new Vector3(120, -120, 0);
    Vector3 p2 = new Vector3(300, -120, 0);
    Vector3 p3 = new Vector3(480, -120, 0);
    Vector3 p4 = new Vector3(120, -250, 0);
    Vector3 p5 = new Vector3(300, -250, 0);
    Vector3 p6 = new Vector3(480, -250, 0);

    // =================== selectedUnitButtonPosition ================

    Vector3 p11 = new Vector3(80, -80, 0);
    Vector3 p12 = new Vector3(190, -80, 0);
    Vector3 p13 = new Vector3(300, -80, 0);
    Vector3 p14 = new Vector3(410, -80, 0);
    Vector3 p15 = new Vector3(520, -80, 0);

    // ============ Unit tagName ===========

    private string warriorTagName = "Warrior";
    private string archerTagName = "Archer";
    private string shieldTagName = "Shield";
    private string cavalryTagName = "Cavalry";
    private string healerTagName = "Healer";
    // ======================


    static public GameObject canvasObject;

    private void Awake()
    {
        canvasObject = GameObject.Find("Canvas");
    }

    private void Start()
    {
        GameObject warriorObject = SelectUnitButtonManager.CreateSelectUnitButton(privateWarriorImagePath, p1, warriorTagName, canvasObject);
        GameObject selectedWarriorObject = SelectedUnitButtonManager.CreateSelectedUnitButton(privateWarriorImagePath, p11, warriorTagName, canvasObject);

        GameObject archerObject = SelectUnitButtonManager.CreateSelectUnitButton(privateArcherImagePath, p2, archerTagName, canvasObject);
        GameObject selectedArcherObject = SelectedUnitButtonManager.CreateSelectedUnitButton(privateArcherImagePath, p12, archerTagName, canvasObject);

        GameObject shieldObject = SelectUnitButtonManager.CreateSelectUnitButton(privateShieldImagePath, p2, shieldTagName, canvasObject);
        GameObject selectedShieldObject = SelectedUnitButtonManager.CreateSelectedUnitButton(privateShieldImagePath, p12, shieldTagName, canvasObject);

        GameObject cavalryObject = SelectUnitButtonManager.CreateSelectUnitButton(privateCavalryImagePath, p2, cavalryTagName, canvasObject);
        GameObject selectedCavalryObject = SelectedUnitButtonManager.CreateSelectedUnitButton(privateCavalryImagePath, p12, cavalryTagName, canvasObject);

        GameObject healerObject = SelectUnitButtonManager.CreateSelectUnitButton(privateHealerImagePath, p2, healerTagName, canvasObject);
        GameObject selectedHealerObject = SelectedUnitButtonManager.CreateSelectedUnitButton(privateHealerImagePath, p12, healerTagName, canvasObject);

        if ( DontDestroyUserData.storyNumber >= 1)
        {
            archerObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(archerImagePath);
            selectedArcherObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(archerImagePath);
            if (DontDestroyUserData.storyNumber >= 2)
            {
                shieldObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(shieldImagePath);
                selectedShieldObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(shieldImagePath);
                if (DontDestroyUserData.storyNumber >= 3)
                {
                    cavalryObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(cavalryImagePath);
                    selectedCavalryObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(cavalryImagePath);
                    if (DontDestroyUserData.storyNumber >= 4)
                    {
                        healerObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(healerImagePath);
                        selectedHealerObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(healerImagePath);
                    }
                }

            }

        }

    }


}
