using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WarriorNum : MonoBehaviour
{
    public Text text;
    // Update is called once per frame
    void Update()
    {
       text.text = "" + SelectedUnitData.warriorNumber;
    }
}
