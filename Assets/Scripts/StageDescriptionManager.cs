using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageDescriptionManager : MonoBehaviour
{
    public GameObject chapter1;
    public GameObject chapter2;
    public GameObject chapter3;
    public GameObject chapter4;

    public GameObject chapter1stage0;
    public GameObject chapter1stage1;
    public GameObject chapter1stage2;
    public GameObject chapter1stage3;
    public GameObject chapter1stage4;
    public GameObject chapter2stage1;
    public GameObject chapter2stage2;
    public GameObject chapter2stage3;
    public GameObject chapter2stage4;
    public GameObject chapter3stage1;
    public GameObject chapter3stage2;
    public GameObject chapter3stage3;
    public GameObject chapter3stage4;
    public GameObject chapter4stage1;

    private void Start()
    {
        InitStageDexcription();
        if (GameManager.stageNumber == 0)
        {
            chapter1.SetActive(true);
            chapter1stage1.SetActive(true);
        }
        if ( GameManager.stageNumber == 1)
        {
            chapter1.SetActive(true);
            chapter1stage1.SetActive(true);
        }
        if (GameManager.stageNumber == 2)
        {
            chapter1.SetActive(true);
            chapter1stage2.SetActive(true);
        }
        if (GameManager.stageNumber == 3)
        {
            chapter1.SetActive(true);
            chapter1stage3.SetActive(true);
        }
        if (GameManager.stageNumber == 4)
        {
            chapter1.SetActive(true);
            chapter1stage4.SetActive(true);
        }
        if (GameManager.stageNumber == 5)
        {
            chapter2.SetActive(true);
            chapter2stage1.SetActive(true);
        }
        if (GameManager.stageNumber == 6)
        {
            chapter2.SetActive(true);
            chapter2stage2.SetActive(true);
        }
        if (GameManager.stageNumber == 7)
        {
            chapter2.SetActive(true);
            chapter2stage3.SetActive(true);
        }
        if (GameManager.stageNumber == 8)
        {
            chapter2.SetActive(true);
            chapter2stage4.SetActive(true);
        }
        if (GameManager.stageNumber == 9)
        {
            chapter3.SetActive(true);
            chapter3stage1.SetActive(true);
        }
        if (GameManager.stageNumber == 10)
        {
            chapter3.SetActive(true);
            chapter3stage2.SetActive(true);
        }
        if (GameManager.stageNumber == 11)
        {
            chapter3.SetActive(true);
            chapter3stage3.SetActive(true);
        }
        if (GameManager.stageNumber == 12)
        {
            chapter3.SetActive(true);
            chapter3stage4.SetActive(true);
        }
        if (GameManager.stageNumber == 13)
        {
            chapter4.SetActive(true);
            chapter4stage1.SetActive(true);
        }
    }

    public void InitStageDexcription()
    {
        chapter1.SetActive(false);
        chapter2.SetActive(false);
        chapter3.SetActive(false);
        chapter4.SetActive(false);
        chapter1stage0.SetActive(false);
        chapter1stage1.SetActive(false);
        chapter1stage2.SetActive(false);
        chapter1stage3.SetActive(false);
        chapter1stage4.SetActive(false);
        chapter2stage1.SetActive(false);
        chapter2stage2.SetActive(false);
        chapter2stage3.SetActive(false);
        chapter2stage4.SetActive(false);
        chapter3stage1.SetActive(false);
        chapter3stage2.SetActive(false);
        chapter3stage3.SetActive(false);
        chapter3stage4.SetActive(false);
        chapter4stage1.SetActive(false);
    }
}
