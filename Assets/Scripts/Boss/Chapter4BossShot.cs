using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter4BossShot : MonoBehaviour
{
    const string bulletPrefabPath = "Prefabs/Boss/Chapter4BossShotPrefab";

    static private GameObject bulletPrefab;
    private int bulletDamage;
    public GameObject shakeManager;
    //public AudioSource audioSource;
    private void Start()
    {
        shakeManager = GameObject.Find("Master");
        Invoke("DestroyBullet", 1f);
        bulletDamage = 50;

        //audioSource = gameObject.GetComponent<AudioSource>();
        //audioSource.volume = 0.3f;
    }

    static public GameObject CreateBullet(Vector3 pos, Quaternion rotation)
    {
        bulletPrefab = Resources.Load<GameObject>(bulletPrefabPath);
        GameObject newBullet = Instantiate(bulletPrefab, pos, rotation);
        newBullet.AddComponent<Chapter4BossShot>();
        return newBullet;
    }
    public void ShotBullet(float speed, Vector2 force)
    {
        GetComponent<Rigidbody2D>().AddForce(speed * force.normalized);
    }

    public void DestroyBullet()
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

        if (otherObject.CompareTag("Player"))
        {
            //audioSource.Play();
            //shakeManager.GetComponent<ShakeManager>().Shake();

            if (otherEggManager != null)
            {
                otherEggManager.curHp -= bulletDamage;
                otherObject.GetComponent<HpBarController>()
                        .SetHealth(otherEggManager.curHp, otherEggManager.maxHp);
            }
            Destroy(gameObject);
        }
    }
    public int GetBulletDamage()
    {
        return bulletDamage;
    }
}
