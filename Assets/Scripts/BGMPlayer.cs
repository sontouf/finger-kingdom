using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BGMPlayer : MonoBehaviour
{
    string[] BGM = new string[9] {"Audio/BGM/Select", "Audio/BGM/Forest" , "Audio/BGM/Tree" , "Audio/BGM/Mountain"
        , "Audio/BGM/Ogre" , "Audio/BGM/Ship" , "Audio/BGM/Captain" , "Audio/BGM/LastBoss", "Audio/BGM/Tutorial" };
    public AudioClip audioSourceClip;
    public AudioSource audioSource;
    int BGMnum;
    // Start is called before the first frame update
    private static BGMPlayer instance = null;


    void Awake()
    {
        if (null == instance)
        {
            //이 클래스 인스턴스가 탄생했을 때 전역변수 instance에 게임매니저 인스턴스가 담겨있지 않다면, 자신을 넣어준다.
            instance = this;

            //씬 전환이 되더라도 파괴되지 않게 한다.
            //gameObject만으로도 이 스크립트가 컴포넌트로서 붙어있는 Hierarchy상의 게임오브젝트라는 뜻이지만, 
            //나는 헷갈림 방지를 위해 this를 붙여주기도 한다.
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //만약 씬 이동이 되었는데 그 씬에도 Hierarchy에 GameMgr이 존재할 수도 있다.
            //그럴 경우엔 이전 씬에서 사용하던 인스턴스를 계속 사용해주는 경우가 많은 것 같다.
            //그래서 이미 전역변수인 instance에 인스턴스가 존재한다면 자신(새로운 씬의 GameMgr)을 삭제해준다.
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        BGMnum = 0;
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = Resources.Load(BGM[BGMnum]) as AudioClip;
        audioSource.Play();
    }

    //게임 매니저 인스턴스에 접근할 수 있는 프로퍼티. static이므로 다른 클래스에서 맘껏 호출할 수 있다.
    public static BGMPlayer Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    void OnEnable()
    {
        // 씬 매니저의 sceneLoaded에 체인을 건다.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // 체인을 걸어서 이 함수는 매 씬마다 호출된다.
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int BGMcheck;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 7:
                BGMcheck = 1;
                break;
            case 8:
                BGMcheck = 3;
                break;
            case 9:
                BGMcheck = 5;
                break;
            case 10:
                BGMcheck = 7;
                break;
            case 13:
                BGMcheck = 8;
                break;
            default:
                BGMcheck = 0;
                break;

        }
        if (BGMcheck != BGMnum)
        {
            BGMnum = BGMcheck;
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.clip = Resources.Load(BGM[BGMnum]) as AudioClip;
            audioSource.Play();
        }

    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}
