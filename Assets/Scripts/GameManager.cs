using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Vector3 p1 = new Vector3(-5, 2, 0);
    Vector3 p2 = new Vector3(-5, 0, 0);
    Vector3 p3 = new Vector3(-5, -2, 0);
    private List<Vector3> positions = new List<Vector3>();
   
    [SerializeField]
    private GameObject planePrefeb;

    // Start is called before the first frame update
    void Start()
    {
        positions.Add(p1);
        positions.Add(p2);
        positions.Add(p3);

        foreach (Vector3 pos in positions)
        {
            EggManager.CreateEgg(pos);
        }
        Instantiate(planePrefeb, Vector3.zero, Quaternion.identity);

    }
}
