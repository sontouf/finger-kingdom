using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;


public class Archer_arrow : MonoBehaviour
{
    const string arrowPrefabPath = "Prefabs/ArrowPrefab";

    static private GameObject arrowPrefab;
    private int arrowDamage;
    public GameObject shakeManager;
    public AudioSource audioSource;
    private void Start()
    {
        shakeManager = GameObject.Find("Master");
        Invoke("DestroyArrow", 1.2f);
        arrowDamage = 25;
        
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = 0.3f;
    }

    static public GameObject CreateArrow(Vector3 pos, Quaternion rotation)
    {
        arrowPrefab = Resources.Load<GameObject>(arrowPrefabPath);
        GameObject newArrow = Instantiate(arrowPrefab, pos, rotation);
        newArrow.AddComponent<Archer_arrow>();
        return newArrow;
    }
    public void ShotArrow(float speed, Vector2 force)
    {
        GetComponent<Rigidbody2D>().AddForce(speed * force.normalized);
    }

    public void DestroyArrow()
    {
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        GameObject otherObject = other.gameObject;
        EggManager otherEggManager = otherObject.GetComponent<EggManager>();
        /*        if (otherObject.CompareTag("Trap"))
                {
                    DestroyEgg(this);
                }*/
        if (otherObject.CompareTag("Enemy") || otherObject.CompareTag("Boss"))
        {
            audioSource.Play();
            shakeManager.GetComponent<ShakeManager>().Shake();
            Destroy(gameObject, 0.2f);
            if (otherEggManager != null)
            {
                otherEggManager.curHp -= arrowDamage;
                otherObject.GetComponent<HpBarController>()
                        .SetHealth(otherEggManager.curHp, otherEggManager.maxHp);
            }

        }
    }
    public int GetArrowDamage()
    {
        return arrowDamage;
    }
}
