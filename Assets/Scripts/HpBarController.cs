using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class HpBarController : MonoBehaviour
{
    [SerializeField]
    public Slider hpBar ;
    public Color low = Color.red;
    public Color high = Color.green;
    public Vector3 offset;

    public Image image;
    // Update is called once per frame

 
    void Update()
    {
        if (hpBar != null)
        {
            hpBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + offset);
        }
    }
    public void Init(float curHp, float maxHp)
    {
        hpBar = transform.GetChild(0).GetChild(0).GetComponent<Slider>();
        image = hpBar.fillRect.GetComponentInChildren<Image>();
        SetHealth(curHp, maxHp);
    }

    public void SetHealth(float curHp, float maxHp)
    {
        hpBar.gameObject.SetActive(curHp <= maxHp);
        hpBar.maxValue = maxHp;
        hpBar.value = curHp;
        image.color
            = Color.Lerp(low, high, hpBar.normalizedValue);
    }

}

