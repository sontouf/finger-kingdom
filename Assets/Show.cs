using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show : MonoBehaviour
{
    public GameObject endingCredit;
    private void Update()
    {
        if( DontDestroyUserData.storyNumber>= 13)
        {
            endingCredit.SetActive(true);
        }
    }
}
