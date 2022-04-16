using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class BattleReady : MonoBehaviour
{
    public Camera mainCamera;
    public Vector3 mousePos;

    const string buttonPrefabPath = "Prefabs/ButtonPrefab";
    const string textPrefabPath = "Prefabs/TextPrefab";

    int num;
    public GameObject dontBattle; 
    Button selectedUnit;
    Text selectedUnitNumber;


    public GameObject parentObject;
    public GameObject parentTextObject;
    public GameObject unitPlane;
    public GameObject battleButton;
    
    GameObject selectedButton;
    bool isBeingSelected = false;
    static public bool completeReady = false;
    public string userEggTagName = "Player";

    static public int oneSelected;

    public Dictionary<Type, int> copy = new Dictionary<Type, int>(SelectedUnitData.unitCounts);
    public Dictionary<Type, bool> copyBool = new Dictionary<Type, bool>(SelectedUnitData.unitBools);
    private string GetClassName<EggType>() where EggType : UserEggManager
    {
        return typeof(EggType).Name;
    }

    private string ParseClassName(string className)
    {
        string[] parsed = className.Split(new string[] { "Egg" }, StringSplitOptions.None);
        return parsed[0][0].ToString().ToLower() + parsed[0].Substring(1);
    }


    private void CreateUnitButton<EggType>() where EggType : UserEggManager
    {
        selectedUnitNumber.text = "" + SelectedUnitData.GetUnitCount<EggType>();
        Text childText = Instantiate(selectedUnitNumber);
        childText.transform.SetParent(parentTextObject.transform);
        childText.rectTransform.localScale = new Vector3(1, 1, 0);
        childText.fontSize = 24;
        childText.gameObject.name = GetClassName<EggType>() + "Text";
        selectedUnit.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/" + ParseClassName(GetClassName<EggType>()));
        Button child = Instantiate(selectedUnit);
        child.transform.SetParent(parentObject.transform);
        child.GetComponent<Image>().rectTransform.localScale = new Vector3(1, 1, 0);
        Destroy(child.gameObject.transform.GetChild(0).gameObject);
        child.onClick.AddListener(OnUnitClick<EggType>);
    }

    private void Start()
    {
        completeReady = false;
        oneSelected = 0;
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        Vector3 vector3 = new Vector3(0, -2.2f, -10);
        mainCamera.transform.position = vector3;
        selectedUnit = Resources.Load<Button>(buttonPrefabPath);
        selectedUnitNumber = Resources.Load<Text>(textPrefabPath);

        if (SelectedUnitData.GetUnitCount<WarriorEgg>() >= 1)
        {
            CreateUnitButton<WarriorEgg>();
        }
        if (SelectedUnitData.GetUnitCount<ArcherEgg>() >= 1)
        {
            CreateUnitButton<ArcherEgg>();
        }
        if (SelectedUnitData.GetUnitCount<WoodFenceEgg>() >= 1)
        {
            CreateUnitButton<WoodFenceEgg>();
        }
        if (SelectedUnitData.GetUnitCount<ShieldEgg>() >= 1)
        {
            CreateUnitButton<ShieldEgg>();
        }
        if (SelectedUnitData.GetUnitCount<BomberEgg>() >= 1)
        {
            CreateUnitButton<BomberEgg>();
        }
        if (SelectedUnitData.GetUnitCount<HealerEgg>() >= 1)
        {
            CreateUnitButton<HealerEgg>();
        }
        if (SelectedUnitData.GetUnitCount<SiegeWeaponEgg>() >= 1)
        {
            CreateUnitButton<SiegeWeaponEgg>();
        }
        if (SelectedUnitData.GetUnitCount<CavalryEgg>() >= 1)
        {
            CreateUnitButton<CavalryEgg>();
        }
        if (SelectedUnitData.GetUnitCount<CannonEgg>() >= 1)
        {
            CreateUnitButton<CannonEgg>();
        }
        if (SelectedUnitData.GetUnitCount<PaladinEgg>() >= 1)
        {
            CreateUnitButton<PaladinEgg>();
        }

    }
    bool inPlane;

    private void Update()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        if (selectedButton != null && isBeingSelected)
        {
            selectedButton.transform.position = LimitedPlane(mousePos);
            if (Input.GetMouseButtonDown(0))
            {
                isBeingSelected = !isBeingSelected;

                selectedButton.AddComponent<DragObjectScript>();
                selectedButtonNumber--;
                prefabText.text = "" + selectedButtonNumber;
            }
        }
        if (!isBeingSelected && selectedButtonNumber > 0 && selectedButton != null)
        {
            if (selectedType == typeof(WarriorEgg))
            {
                prefabButton = EggManager.CreateEgg<WarriorEgg>(mousePos, userEggTagName);
            }
            else if (selectedType == typeof(ArcherEgg))
            {
                prefabButton = EggManager.CreateEgg<ArcherEgg>(mousePos, userEggTagName);
            }
            else if (selectedType == typeof(BomberEgg))
            {
                prefabButton = EggManager.CreateEgg<BomberEgg>(mousePos, userEggTagName);
            }
            else if (selectedType == typeof(CannonEgg))
            {
                prefabButton = EggManager.CreateEgg<CannonEgg>(mousePos, userEggTagName);
            }
            else if (selectedType == typeof(CavalryEgg))
            {
                prefabButton = EggManager.CreateEgg<CavalryEgg> (mousePos, userEggTagName);
            }
            else if (selectedType == typeof(HealerEgg))
            {
                prefabButton = EggManager.CreateEgg<HealerEgg>(mousePos, userEggTagName);
            }
            else if (selectedType == typeof(WoodFenceEgg))
            {
                prefabButton = EggManager.CreateEgg<WoodFenceEgg>(mousePos, userEggTagName);
            }
            else if (selectedType == typeof(PaladinEgg))
            {
                prefabButton = EggManager.CreateEgg<PaladinEgg>(mousePos, userEggTagName);
            }
            else if (selectedType == typeof(ShieldEgg))
            {
                prefabButton = EggManager.CreateEgg<ShieldEgg>(mousePos, userEggTagName);

            }
            else if (selectedType == typeof(SiegeWeaponEgg))
            {
                prefabButton = EggManager.CreateEgg<SiegeWeaponEgg>(mousePos, userEggTagName);

            }
            GameManager.userUnitCount += 1;         
            selectedButton = prefabButton;
            isBeingSelected = !isBeingSelected;

        }
        else if (!isBeingSelected && selectedButtonNumber == 0 && selectedButton != null)
        {
            selectedButton = null;
        }

    }
    GameObject prefabButton;
    int selectedButtonNumber = 1;
    public Text prefabText;
    Type selectedType;
    public void OnUnitClick<EggType>() where EggType : UserEggManager
    {
        if (selectedButton == null)
        {
            Text text = GameObject.Find(GetClassName<EggType>() + "Text").GetComponent<Text>();
            prefabText = text;
            if (copy[typeof(EggType)] == SelectedUnitData.unitCounts[typeof(EggType)] && !copyBool[typeof(EggType)])
            {
                selectedButtonNumber = copy[typeof(EggType)];
                selectedButton = EggManager.CreateEgg<EggType>(mousePos, userEggTagName);
                oneSelected++;
                GameManager.userUnitCount += 1;
                selectedType = typeof(EggType);
                copy[typeof(EggType)]--;
                text.text = "" + copy[typeof(EggType)];
                isBeingSelected = !isBeingSelected;
                copyBool[typeof(EggType)] = !copyBool[typeof(EggType)];
            }
        }

    }
  
    public void BattleStart()
    {
        if (oneSelected >= 1)
        {
            EggManager.userEggManagers = EggManager.GetEggManagersByType<UserEggManager>();
            completeReady = !completeReady;
            Vector3 vector3 = new Vector3(0, 0, -10);
            mainCamera.transform.position = vector3;
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject player in players)
            {
                Destroy(player.GetComponent<DragObjectScript>());
            }
            Destroy(GameObject.Find("limitedPlane"));
            Destroy(this);
            parentObject.SetActive(false);
            parentTextObject.SetActive(false);
            unitPlane.SetActive(false);
            battleButton.SetActive(false);
        }

    }

    public Vector3 LimitedPlane(Vector3 mousePos)
    {
        if (GameManager.stageNumber >= 1 && GameManager.stageNumber <= 4)
        {
            if (mousePos.x < -8.1)
            {
                mousePos.x = -8.1f;
                if (mousePos.y < -3.75)
                {
                    mousePos.y = -3.75f;
                }
                else if (mousePos.y > 3.75)
                {
                    mousePos.y = 3.75f;
                }
            }
            else if (mousePos.x > 0.1)
            {
                mousePos.x = 0.1f;
                if (mousePos.y < -3.75)
                {
                    mousePos.y = -3.75f;
                }
                else if (mousePos.y > 3.75)
                {
                    mousePos.y = 3.75f;
                }
            }
            else if (mousePos.y > 3.75)
            {
                mousePos.y = 3.75f;
                if (mousePos.x < -8.1)
                {
                    mousePos.x = -8.1f;
                }
                else if (mousePos.x > 0.1)
                {
                    mousePos.x = 0.1f;
                }
            }
            else if (mousePos.y < -3.75)
            {
                mousePos.y = -3.75f;
                if (mousePos.x < -8.1)
                {
                    mousePos.x = -8.1f;
                }
                else if (mousePos.x > 0.1)
                {
                    mousePos.x = 0.1f;
                }
            }
        }
        else if (GameManager.stageNumber >= 5 && GameManager.stageNumber <= 8)
        {
            if (mousePos.x < -7.95)
            {
                mousePos.x = -7.95f;
                if (mousePos.y < -3.84)
                {
                    mousePos.y = -3.84f;
                }
                else if (mousePos.y > 3.84)
                {
                    mousePos.y = 3.84f;
                }
            }
            else if (mousePos.x > -4.57)
            {
                mousePos.x = -4.57f;
                if (mousePos.y < -3.84)
                {
                    mousePos.y = -3.84f;
                }
                else if (mousePos.y > 3.84)
                {
                    mousePos.y = 3.84f;
                }
            }
            else if (mousePos.y > 3.84)
            {
                mousePos.y = 3.84f;
                if (mousePos.x < -7.95)
                {
                    mousePos.x = -7.95f;
                }
                else if (mousePos.x > -4.57)
                {
                    mousePos.x = -4.57f;
                }
            }
            else if (mousePos.y < -3.84)
            {
                mousePos.y = -3.84f;
                if (mousePos.x < -7.95)
                {
                    mousePos.x = -7.95f;
                }
                else if (mousePos.x > -4.57)
                {
                    mousePos.x = -4.57f;
                }
            }
        }
        else if (GameManager.stageNumber >= 9 && GameManager.stageNumber <= 12)
        {
            if (mousePos.x < -3.57)
            {
                mousePos.x = -3.57f;
                if (mousePos.y < -1.7)
                {
                    mousePos.y = -1.7f;
                }
                else if (mousePos.y > 1.7)
                {
                    mousePos.y = 1.7f;
                }
            }
            else if (mousePos.x > 4.24)
            {
                mousePos.x = 4.24f;
                if (mousePos.y < -1.7)
                {
                    mousePos.y = -1.7f;
                }
                else if (mousePos.y > 1.7)
                {
                    mousePos.y = 1.7f;
                }
            }
            else if (mousePos.y > 1.7)
            {
                mousePos.y = 1.7f;
                if (mousePos.x < -3.57)
                {
                    mousePos.x = -3.57f;
                }
                else if (mousePos.x >4.24)
                {
                    mousePos.x = 4.24f;
                }
            }
            else if (mousePos.y < -1.7)
            {
                mousePos.y = -1.7f;
                if (mousePos.x < -3.57)
                {
                    mousePos.x = -3.57f;
                }
                else if (mousePos.x >4.24)
                {
                    mousePos.x = 4.24f;
                }
            }
        }
        else if (GameManager.stageNumber >= 13 && GameManager.stageNumber <= 14)
        {
            if (mousePos.x < -8.76)
            {
                mousePos.x = -8.76f;
                if (mousePos.y < -4.04)
                {
                    mousePos.y = -4.04f;
                }
                else if (mousePos.y > 4.04)
                {
                    mousePos.y = 4.04f;
                }
            }
            else if (mousePos.x > -3.48)
            {
                mousePos.x = -3.48f;
                if (mousePos.y < -4.04)
                {
                    mousePos.y = -4.04f;
                }
                else if (mousePos.y > 4.04)
                {
                    mousePos.y = 4.04f;
                }
            }
            else if (mousePos.y > 4.04)
            {
                mousePos.y = 4.04f;
                if (mousePos.x < -8.76)
                {
                    mousePos.x = -8.76f;
                }
                else if (mousePos.x > -3.48)
                {
                    mousePos.x = -3.48f;
                }
            }
            else if (mousePos.y < -4.04)
            {
                mousePos.y = -4.04f;
                if (mousePos.x < -8.76)
                {
                    mousePos.x = -8.76f;
                }
                else if (mousePos.x > -3.48)
                {
                    mousePos.x = -3.48f;
                }
            }
        }
        return mousePos;
    }




}
