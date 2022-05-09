using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScrollingBarController : MonoBehaviour
{

    static string nextScene;
    public GameObject spaceBarText;
    public GameObject chapter1;
    public GameObject chapter2;
    public GameObject chapter3;
    public GameObject chapter4;
    AsyncOperation op;
    bool oneClick;
    [SerializeField]
    Image progressBar;


    private void Update()
    {
        if (ChapterClear.chapterClear == 1)
        {
            chapter1.SetActive(true);
        }
        else if (ChapterClear.chapterClear == 2)
        {
            chapter2.SetActive(true);
        }
        else if (ChapterClear.chapterClear == 3)
        {
            chapter3.SetActive(true);
        }
        else if (ChapterClear.chapterClear == 4)
        {
            chapter4.SetActive(true);
        }
        if (progressBar.fillAmount >= 0.99f && !oneClick)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
            {
                op.allowSceneActivation = true;
                oneClick = !oneClick;
            }
        }
    }

    public void InitChapterDescription()
    {
        chapter1.SetActive(false);
        chapter2.SetActive(false);
        chapter3.SetActive(false);
        chapter4.SetActive(false);
    }

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("ChapterDescription");

    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneProcess());
        InitChapterDescription();
    }


    IEnumerator LoadSceneProcess()
    {
        op =  SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0f;
        while (!op.isDone)
        {
            yield return null;


            timer += Time.unscaledDeltaTime/10;
            if (op.progress < 0.89f)
            {
                progressBar.fillAmount = Mathf.Lerp(op.progress, 1f, timer);
                if (progressBar.fillAmount >= op.progress)
                {
                    timer = 0f;
                }
            }
            else
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);
                if (progressBar.fillAmount >= 0.99f)
                {
                    spaceBarText.SetActive(true);      
                }
                yield return null;
            }
        }
    }
}
