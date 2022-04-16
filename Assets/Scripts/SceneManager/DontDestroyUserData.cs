using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyUserData : MonoBehaviour
{

    // 유저의 정보는 stage 어디까지 깻는지, 그래서 어느정도 유닛을 얻었는지 정도만 있으면 된다.

    static public int storyNumber = 0;
    static public bool stageClearCheck = false; // 스테이지가 클리어 됐는지 확인. stageClearCheck가 true일때 story가 1 증가.

}
