using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterimageScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Fade");
    }


    IEnumerator Fade()
    {
        for (float f = 1f; f >= 0; f -= 0.04f)
        {
            
            SpriteRenderer spr = GetComponent<SpriteRenderer>();
            Color color = spr.color;
            color.a = f;
            spr.color = color;
            yield return null;
        }
    }
}
