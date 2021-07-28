using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ArcherNum : MonoBehaviour
{
    public Text text;
    // Update is called once per frame
    void Update()
    {
        text.text = "" + SelectedUnitData.archerNumber;
    }
}
