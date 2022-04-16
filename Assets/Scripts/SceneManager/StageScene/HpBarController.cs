using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class HpBarController : MonoBehaviour
{
    // HpBar에 대한 정보를 담고 HpBar를 구현한다.

    //const string sliderPrefabPath = "Prefabs/Slider";

    //public GameObject mainCanvas;
    public Slider hpBar;
    public Color low = Color.red;
    public Color high = Color.green;
    public Image image;
    Vector3 pos;
    // Update is called once per frame



    void FixedUpdate()
    {
/*        pos = gameObject.GetComponent<Rigidbody2D>().position;
        pos = Camera.main.WorldToScreenPoint(pos);
        if (hpBar != null)
        {
            hpBar.transform.position = pos;
            // World 화면을 기준으로 마우스위치를 받아와서 CirclePrefab의 위치로 위치한다.
        }*/
    }

    // HpBar 초기화하는 함수, EggManager가 초기화될때 호출된다.
    public void Init(float curHp, float maxHp)
    {
        /*        mainCanvas = GameObject.Find("Canvas");
                hpBar = Resources.Load<Slider>(sliderPrefabPath);

                Slider child = Instantiate(hpBar);
                child.transform.SetParent(mainCanvas.transform);*/
        //hpBar = transform.GetChild(0).GetChild(0).GetComponent<Slider>();

        hpBar = gameObject.GetComponent<EggManager>().child;
        image = hpBar.fillRect.GetComponentInChildren<Image>();
        SetHealth(curHp, maxHp);
    }

    // EggManager의 충돌감지하는 함수 OnCollider에서 호출된다.
    public void SetHealth(float curHp, float maxHp)
    {
        if (curHp > maxHp)
            curHp = maxHp;
        hpBar.gameObject.SetActive(curHp <= maxHp);
        hpBar.maxValue = maxHp;
        hpBar.value = curHp;
        image.color
            = Color.Lerp(low, high, hpBar.normalizedValue);
    }

}

