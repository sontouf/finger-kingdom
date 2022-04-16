using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using System.Linq;
using System.IO;

public class SelectedUnitData : MonoBehaviour
{
    // Start is called before the first frame update
    public int warriorNumber = 0;
    public int archerNumber = 0;
    public int shieldNumber = 0;
    public int cavalryNumber = 0;
    public int healerNumber = 0;
    public int bomberNumber = 0;
    public int woodFenceNumber = 0;
    public int ironFenceNumber = 0;
    public int siegeWeaponNumber = 0;
    public int cannonNumber = 0;
    public int paladinNumber = 0;
    public int megalithicNumber = 0;


    
    static public Dictionary<Type, int> unitCounts = new Dictionary<Type, int>();
    static public Dictionary<Type, bool> unitBools = new Dictionary<Type, bool>();


    static SelectedUnitData()
    {
        foreach (Type t in Assembly
            .GetAssembly(typeof(UserEggManager))
            .GetTypes()
            .Where(t => t.IsSubclassOf(typeof(UserEggManager)))
            )
        {
            unitCounts.Add(t, 0);
            unitBools.Add(t, false);
        }
    }
    static public void AddUnitCount<EggType>() where EggType : UserEggManager
    {
        Type t = typeof(EggType);
        unitCounts[t] += 1;
    }
    static public int GetUnitCount<EggType>() where EggType : UserEggManager
    {
        return unitCounts[typeof(EggType)];
    }



    //static public Dictionary<string, Type> userEggTypes = new Dictionary<string, Type>();
    /*    static SelectedUnitData()
        {
            foreach (Type t in Assembly
                .GetAssembly(typeof(UserEggManager))
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(UserEggManager)))
                )
            {
                userEggTypes.Add(t.Name, t);
            }
        }*/
}
