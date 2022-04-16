using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{

    Dictionary<int, string[]> talkData;
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(0 , new string []
        { " 저.. 저깄다 여기 계셨군요!?", 
          " 반갑습니다. 저는 당신의 임무를 돕기위해 왕국에서 파견된 전령, Owl입니다." ,
            " 지금 시간이 급하니 빠르게 설명드리고 마왕이 훔쳐간 옥새를 되찾으러 갑시다!" , 
            " 밑에 그림에서처럼 열려있는 챕터를 선택하고, 스테이지를 선택하면 됩니다." });
        //================
        talkData.Add(2, new string[] { " 스테이지를 시작하기 전 부대를 편성해야 합니다." , 
            " 현재 표시된 것처럼 위의 버튼은 병사추가, 밑의 버튼은 병사취소입니다. "} );
        //=================
        talkData.Add(3, new string[] { " 병사를 추가하실때 최대 cost를 넘을 순 없으니, 신중하게 선택해주세요." ,
            " 병사의 인구수나 체력,공격력 등 같은 정보가 제공되어 있으니 편성에 도움이 됐으면 좋겠습니다. "
            , " 또한 앞으로 나아가다보면 새로운 병사들을 만나실 수 있으니 기대해보셔도 좋습니다. " , " 아 참, 해당 창 오른쪽 위에 제가 있을겁니다. "
            , " 저를 누르시면 현재 스테이지를 클리어하는데 도움이 될만한 정보가 있을겁니다. " ," 자 그러면 전투를 시작해봅시다. " });

        ///========
        talkData.Add(4, new string[] { " 전투는 배치, 전투 2단계로 나뉩니다. ",
            " 먼저 하단에 이전 편성창에서 선택한 병사들이 보일 겁니다. " 
            , " 그럼 병사들을 선택해서 현재 전장에 파란색 범위 내에서 병사들을 배치하면 됩니다.",
            " 병사를 클릭하면 알아서 마우스커서에 병사가 생겨있으니 원하는 공간에서 클릭하시면 됩니다. ",
            " 배치하면 자리를 못바꾸는 건 아닙니다. 다시 드래그하면 위치를 변경할 수 있습니다.",
            " 배치를 다 끝냈으면 전투시작을 누릅니다." });

        //===========
        talkData.Add(5, new string[] { " 당신과 적은 서로 한번씩 턴을 주고받습니다." ,
            "자신의 턴이 왔을때 병사를 마우스 왼쪽으로 드래그를 하면 ", 
            "과녁방향으로 이동을 하게되고 적들과 부딪혀서 공격을 할 수 있습니다."," 전투는 승리조건을 충족시키면 끝나게 됩니다." ,
            "그리고 필요 시 'ESC'를 눌러 전장을 이탈하실 수 있습니다. " });
        //
        talkData.Add(6, new string[] { " 필요한 모든 설명은 끝이 났네요. 옥새를 훔쳐간 마왕을 잡기까지 먼 여정을 앞두고 있겠지만 ",
            " 당신이라면 충분히 승리의 깃발을 꽂을수 있을 것이라 생각합니다.",
            " 왕국의 승리를 기원합니다!! " });

    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            /*            if (!talkData.ContainsKey(id - id % 10))
                        {
                            return GetTalk(id - id % 100, talkIndex);
                        }
                        else
                        {
                            return GetTalk(id - id % 10, talkIndex);
                        }*/
            return null;
        }
        if (talkIndex == talkData[id].Length)
        {
            return null;
        }
        else
        {
            return talkData[id][talkIndex];
        } 
        
    }
    public string[] ReverseGetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            /*            if (!talkData.ContainsKey(id - id % 10))
                        {
                            return GetTalk(id - id % 100, talkIndex);
                        }
                        else
                        {
                            return GetTalk(id - id % 10, talkIndex);
                        }*/
            return null;
        }
        if (talkIndex == 0)
        {
            return null;
        }
        else
        {
            return talkData[id];
        }

    }
}
