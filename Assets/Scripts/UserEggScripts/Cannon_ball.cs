using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon_ball : MonoBehaviour
{
    const string cannonBallPrefabPath = "Prefabs/CannonBallPrefab";
    const string cannonBallEffectPath = "Prefabs/CannonBomb";
    const string audioAttackImpactPath = "Audio/cannon";
    public AudioClip audioSourceClip;
    static private GameObject cannonBallPrefab;
    private int cannonBallDamage;
    public GameObject shakeManager;
    public AudioSource audioSource;
    GameObject cannonBallEffect;
    float distancd;

    private void Start()
    {
        distancd = 0;
        shakeManager = GameObject.Find("Master");
        Invoke("DestroyCannonBall", 1.2f);
        cannonBallDamage = 55;
        cannonBallEffect = Resources.Load<GameObject>(cannonBallEffectPath);
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = 0.3f;
        audioSourceClip = Resources.Load(audioAttackImpactPath) as AudioClip;
        audioSource.clip = audioSourceClip;
    }

    static public GameObject CreateCannonBall(Vector3 pos, Quaternion rotation)
    {
        cannonBallPrefab = Resources.Load<GameObject>(cannonBallPrefabPath);
        GameObject newCannonBall = Instantiate(cannonBallPrefab, pos, rotation);
        newCannonBall.AddComponent<Cannon_ball>();
        return newCannonBall;
    }
    public void ShotCannonBall(float speed, Vector2 force)
    {
        GetComponent<Rigidbody2D>().AddForce(speed * force.normalized * 10);
    }

    public void DestroyCannonBall()
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
        if (otherObject.CompareTag("Enemy") || otherObject.CompareTag("Boss") && BattleReady.completeReady)
        {
            if (otherEggManager != null)
            {
                otherEggManager.curHp -= cannonBallDamage;
                otherObject.GetComponent<HpBarController>()
                        .SetHealth(otherEggManager.curHp, otherEggManager.maxHp);
                foreach (EnemyEggManager otherEnemyEggManager in EnemyEggManager.enemyEggManagers)
                {
                    if (otherEnemyEggManager.gameObject != other.gameObject)
                    {
                        GameObject otherEnemy = otherEnemyEggManager.gameObject;
                        distancd = Vector2.Distance(otherEnemy.transform.position, transform.position);
                        if (distancd <= 1.5)
                        {
                            otherEnemy.GetComponent<EggManager>().curHp -= 50;
                            otherEnemy.GetComponent<HpBarController>()
                                    .SetHealth(otherEnemyEggManager.curHp, otherEnemyEggManager.maxHp);
                            Vector2 force = otherEnemy.transform.position - transform.position;
                            otherEnemy.GetComponent<Rigidbody2D>().AddForce(force * 30);
                        }
                    }
                }
            }
            Instantiate(cannonBallEffect, transform.position, Quaternion.identity);
            audioSource.Play();
            shakeManager.GetComponent<ShakeManager>().Shake();
            Destroy(gameObject, 0.3f);

        }
    }
    public int GetCannonBallDamage()
    {
        return cannonBallDamage;
    }

}
