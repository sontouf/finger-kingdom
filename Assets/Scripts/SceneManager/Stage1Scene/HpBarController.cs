using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class HpBarController : MonoBehaviour
{
    // HpBar에 대한 정보를 담고 HpBar를 구현한다.


    public Slider hpBar ;
    public Color low = Color.red;
    public Color high = Color.green;
    public Vector3 offset;

    public Image image;
    // Update is called once per frame

 
    void FixedUpdate()
    {
        if (hpBar != null)
        {
            hpBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + offset);
            // World 화면을 기준으로 마우스위치를 받아와서 CirclePrefab의 위치로 위치한다.
        }
    }

    // HpBar 초기화하는 함수, EggManager가 초기화될때 호출된다.
    public void Init(float curHp, float maxHp)
    {
        hpBar = transform.GetChild(0).GetChild(0).GetComponent<Slider>();
        image = hpBar.fillRect.GetComponentInChildren<Image>();
        SetHealth(curHp, maxHp);
    }

    // EggManager의 충돌감지하는 함수 OnCollider에서 호출된다.
    public void SetHealth(float curHp, float maxHp)
    {
        hpBar.gameObject.SetActive(curHp <= maxHp);
        hpBar.maxValue = maxHp;
        hpBar.value = curHp;
        image.color
            = Color.Lerp(low, high, hpBar.normalizedValue);
    }

}

