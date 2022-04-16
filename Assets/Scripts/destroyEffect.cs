using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyEffect : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, gameObject.GetComponent<ParticleSystem>().main.duration + 0.3f);
    }
}
