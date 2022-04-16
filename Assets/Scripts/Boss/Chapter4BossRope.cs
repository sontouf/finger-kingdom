using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter4BossRope : MonoBehaviour
{
    const string ropePrefabPath = "Prefabs/Boss/Chapter4BossRopePrefab";

    static private GameObject ropePrefab;
    private int ropeDamage;
    public GameObject shakeManager;
    Vector3 reverseVector;
    //public AudioSource audioSource;
    private void Start()
    {
        shakeManager = GameObject.Find("Master");
        Invoke("DestroyRope", 1.3f);
        ropeDamage = 65;
        //audioSource = gameObject.GetComponent<AudioSource>();
        //audioSource.volume = 0.3f;
    }

    static public GameObject CreateRope(Vector3 pos, Quaternion rotation)
    {
        ropePrefab = Resources.Load<GameObject>(ropePrefabPath);
        GameObject newRope = Instantiate(ropePrefab, pos, rotation);
        newRope.AddComponent<Chapter4BossRope>();
        return newRope;
    }
    public void ShotRope(float speed, Vector2 force)
    {
        reverseVector = force;
        GetComponent<Rigidbody2D>().AddForce(speed * force.normalized);
    }
    private void Update()
    {
        transform.localScale += new Vector3(0, 0.5f, 0);
    }
    public void DestroyRope()
    {
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObject = other.gameObject;
        EggManager otherEggManager = otherObject.GetComponent<EggManager>();

        if (otherObject.CompareTag("Player"))
        {
            //audioSource.Play();
            //shakeManager.GetComponent<ShakeManager>().Shake();

            if (otherEggManager != null)
            {
                otherEggManager.curHp -= ropeDamage;
                otherObject.GetComponent<HpBarController>()
                        .SetHealth(otherEggManager.curHp, otherEggManager.maxHp);
                otherObject.GetComponent<Rigidbody2D>().AddForce(-400 * reverseVector);
            }
            Destroy(gameObject);
        }
    }
    public int GetRopeDamage()
    {
        return ropeDamage;
    }
}
