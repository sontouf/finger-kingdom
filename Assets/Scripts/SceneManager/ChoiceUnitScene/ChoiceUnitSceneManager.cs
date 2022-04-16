using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChoiceUnitSceneManager : MonoBehaviour
{
    const string shieldImagePath = "Images/shield";
    const string cavalryImagePath = "Images/cavalry";
    const string healerImagePath = "Images/healer";
    const string woodFenceImagePath = "Images/woodFence";
    const string bomberImagePath = "Images/bomber";
    const string siegeWeaponImagePath = "Images/siegeWeapon";
    const string cannonImagePath = "Images/cannon";
    const string paladinImagePath = "Images/paladin";

    GameObject bombObject;
    GameObject selectedBomberObject;
    GameObject woodFenceObject;
    GameObject selectedWoodFenceObject;
    GameObject shieldObject;
    GameObject selectedShieldObject;
    GameObject healerObject;
    GameObject selectedHealerObject;
    GameObject siegeWeaponObject;
    GameObject selectedSiegeWeaponObject;
    GameObject cavalryObject;
    GameObject selectedCavalryObject;
    GameObject cannonObject;
    GameObject selectedCannonObject;
    GameObject paladinObject;
    GameObject selectedPaladinObject;
 

    private void Start()
    {
        bombObject = GameObject.Find("Bomb");
        selectedBomberObject = GameObject.Find("SBomber");

        woodFenceObject = GameObject.Find("WoodFence");
        selectedWoodFenceObject = GameObject.Find("SWoodFence");

        shieldObject = GameObject.Find("Shield");
        selectedShieldObject = GameObject.Find("SShield");

        healerObject = GameObject.Find("Healer");
        selectedHealerObject = GameObject.Find("SHealer");

        siegeWeaponObject = GameObject.Find("SiegeWeapon");
        selectedSiegeWeaponObject = GameObject.Find("SSiegeWeapon");


        cavalryObject = GameObject.Find("Cavalry");
        selectedCavalryObject = GameObject.Find("SCavalry");

        cannonObject = GameObject.Find("Cannon");
        selectedCannonObject = GameObject.Find("SCannon");

        paladinObject = GameObject.Find("Paladin");
        selectedPaladinObject = GameObject.Find("SPaladin");

        if ( DontDestroyUserData.storyNumber >= 1)
        {
            woodFenceObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(woodFenceImagePath);
            selectedWoodFenceObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(woodFenceImagePath);
            if (DontDestroyUserData.storyNumber >= 2)
            {
                shieldObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(shieldImagePath);
                selectedShieldObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(shieldImagePath);
                if (DontDestroyUserData.storyNumber >= 3)
                {
                    selectedBomberObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(bomberImagePath);
                    bombObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(bomberImagePath);                  
                    if (DontDestroyUserData.storyNumber >= 4)
                    {
                        healerObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(healerImagePath);
                        selectedHealerObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(healerImagePath);
                        if (DontDestroyUserData.storyNumber >= 5)
                        {
                            //ironFenceObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(ironFenceImagePath);
                            //selectedironObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(ironFenceImagePath);
                            siegeWeaponObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(siegeWeaponImagePath);
                            selectedSiegeWeaponObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(siegeWeaponImagePath);
                            if (DontDestroyUserData.storyNumber >= 7)
                            {
                                cavalryObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(cavalryImagePath);
                                selectedCavalryObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(cavalryImagePath);
                                if (DontDestroyUserData.storyNumber >= 8)
                                {
                                    cannonObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(cannonImagePath);
                                    selectedCannonObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(cannonImagePath);
                                    if (DontDestroyUserData.storyNumber >= 9)
                                    {
                                        paladinObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(paladinImagePath);
                                        selectedPaladinObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(paladinImagePath);
                                    }
                                }
                            }
                        }
                    }
                }

            }

        }

    }
    
    public void GoBattle()
    {
        if (CurrentCostScript.curCost > 0)
        {
            if (GameManager.stageNumber >= 0 && GameManager.stageNumber <= 4)
            {
                SceneManager.LoadScene(7);
            }
            else if (GameManager.stageNumber >= 5 && GameManager.stageNumber <= 8)
            {
                SceneManager.LoadScene(8);
            }
            else if (GameManager.stageNumber >= 9 && GameManager.stageNumber <= 12)
            {
                SceneManager.LoadScene(9);
            }
            else if (GameManager.stageNumber >= 13)
            {
                SceneManager.LoadScene(10);
            }
        }
    }
    public void StageSelectScene()
    {
        if (GameManager.stageNumber >= 0 && GameManager.stageNumber <= 4)
        {
            SceneManager.LoadScene(2);
        }
        else if (GameManager.stageNumber >= 5 && GameManager.stageNumber <= 8)
        {
            SceneManager.LoadScene(3);
        }
        else if (GameManager.stageNumber >= 9 && GameManager.stageNumber <= 12)
        {
            SceneManager.LoadScene(4);
        }
        else if (GameManager.stageNumber >= 13)
        {
            SceneManager.LoadScene(5);
        }
    }

}
