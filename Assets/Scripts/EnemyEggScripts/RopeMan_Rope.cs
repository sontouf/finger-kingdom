using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RopeMan_Rope : MonoBehaviour
{
    const string ropePrefabPath = "Prefabs/RopePrefab";

    static private GameObject ropePrefab;
    private int ropeDamage;
    public GameObject shakeManager;
    public bool shooting = false;
    Vector3 reverseVector;
    //public AudioSource audioSource;
    private void Start()
    {
        shakeManager = GameObject.Find("Master");
        Invoke("DestroyRope", 1.5f);
        ropeDamage = 50;

        //audioSource = gameObject.GetComponent<AudioSource>();
        //audioSource.volume = 0.3f;
    }

    static public GameObject CreateRope(Vector3 pos, Quaternion rotation)
    {
        ropePrefab = Resources.Load<GameObject>(ropePrefabPath);
        GameObject newRope = Instantiate(ropePrefab, pos, rotation);
        newRope.AddComponent<RopeMan_Rope>();
        return newRope;
    }
    public void ShotRope(float speed, Vector2 force)
    {
        reverseVector = force;
        GetComponent<Rigidbody2D>().AddForce(speed * force.normalized);
        shooting = !shooting;
    }
    private void Update()
    {
        if (shooting)
        {
            transform.localScale += new Vector3(0, 0.7f, 0);
        }
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
        shooting = !shooting;
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
                otherObject.GetComponent<Rigidbody2D>().AddForce(-300 * reverseVector);
            }
            Destroy(gameObject);
        }
    }
    public int GetRopeDamage()
    {
        return ropeDamage;
    }
}
