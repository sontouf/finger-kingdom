using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontBattleStart : MonoBehaviour
{
    public void ActiveObject()
    {
        if (BattleReady.oneSelected == 0)
        {
            this.gameObject.SetActive(true);
        }
    }
    public void UnActiveObject()
    {
        if (BattleReady.oneSelected == 0)
        {
            this.gameObject.SetActive(false);
        }
    }
    
    public void ActiveReady()
    {
        if ( CurrentCostScript.curCost == 0)
        {
            this.gameObject.SetActive(true);
        }
    }
    public void UnActiveReady()
    {
        if (CurrentCostScript.curCost == 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
