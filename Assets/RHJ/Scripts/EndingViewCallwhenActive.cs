using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks; // Task를 사용하기 위한 네임스페이스

public class EndingViewCallwhenActive : MonoBehaviour
{
    // 인스펙터 창에서 호출할 엔딩 번호 넣기
    public int endingIndex;
    public float waittime;

    void Start()
    {
        // 비동기 함수 호출
        CallEndingAfterDelayAsync(waittime);
    }

    private async void CallEndingAfterDelayAsync(float delay)
    {
        await Task.Delay((int)(delay * 1000));
        
        // 딜레이가 끝난 후에 ScoreManager의 메서드 호출
        ScoreManager.Instance.PlayerViewedEnding(endingIndex);
    }
}
