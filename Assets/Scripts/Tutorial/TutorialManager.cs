using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TutorialManager : MonoBehaviour
{
    //public GameObject owlObject;
    public TextManager textManager;
    public GameObject textPanel;
    public Text owlText;
    public int talkIndex;

    public int textNumber;
    public Camera mainCamera;
    public GameObject GoGame;
    public bool spaceOkay;
    public bool one;
    private void Start()
    {
        spaceOkay = true;
        textNumber = 0;
    }
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (spaceOkay)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            { 
                
                Action();
            }
        }
        if (textNumber == 2)
        {
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, new Vector3(17.4f, 0, -10), 100*Time.deltaTime);

        }

        else if (textNumber == 3)
        {
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, new Vector3(34.4f, 0, -10), 100 * Time.deltaTime);
        }
        else if (textNumber == 4)
        {
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, new Vector3(54.2f, 0, -10), 100 * Time.deltaTime);
        }

        else if (textNumber == 5)
        {
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, new Vector3(72.2f, 0, -10), 100 * Time.deltaTime);
        }

        else if (textNumber == 6 && !one) 
        {
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, new Vector3(90.88f, 0, -10), 100 * Time.deltaTime);
            GoGame.SetActive(true);
            Invoke("changeSpaceOkay", 0.4f);
        }
     
    }
    public bool isAction;

    public void Action()
    {
        Talk(textNumber);
        textPanel.SetActive(true);
    }

    void Talk(int id)
    {
        string talkData = textManager.GetTalk(id , talkIndex);
        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            if (textNumber < 6)
            {
                textNumber++;
            }
            return;
        }
        owlText.text = talkData;
        isAction = true;
        talkIndex++;
        
    }

    public void changeSpaceOkay()
    {
        one = !one;
    }
}
