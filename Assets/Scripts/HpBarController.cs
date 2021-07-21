using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class HpBarController : MonoBehaviour
{
    [SerializeField]
    public Slider hpBar;
    public Color low = Color.red;
    public Color high = Color.green;
    public Vector3 offset;


    private void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        hpBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + offset);
    }

 
    public void SetHealth(float curHp, float maxHp)
    {

        hpBar.gameObject.SetActive(curHp <= maxHp);
        hpBar.maxValue = maxHp;
        hpBar.value = curHp;
        Debug.Log(hpBar.value);


        hpBar.fillRect.GetComponentInChildren<Image>().color
            = Color.Lerp(low, high, hpBar.normalizedValue);
    }

}

