using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    int page = 1;
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;
    public GameObject page4;
    public GameObject page5;
    public GameObject page6;
    public GameObject page7;

    public GameObject exitPage;
    public GameObject prevButton;
    public GameObject nextButton;
    List<GameObject> pages = new List<GameObject>();
    private void Start()
    {
        pages.Add(page1);
        pages.Add(page2);
        pages.Add(page3);
        pages.Add(page4);
        pages.Add(page5);
        pages.Add(page6);
        pages.Add(page7);
    }

    public void nextPage()
    {
        if( page < 7)
        {
            page++;
        }
        ViewPage(page);
    }
    public void prevPage()
    {
        if ( page > 1)
        {
            page--;
        }
        ViewPage(page);
    }
    public void ViewPage(int i)
    {
        for ( int j = 0; j< 7; j++)
        {
            if ( j == i-1)
            {
                pages[j].SetActive(true);
            }
            else
            {
                pages[j].SetActive(false);
            }
        }
    }
    public void ExitPage()
    {
        for (int i = 0; i < 7; i++)
        {
            pages[i].SetActive(false);
        }
        exitPage.SetActive(false);
        prevButton.SetActive(false);
        nextButton.SetActive(false);
    }

}
