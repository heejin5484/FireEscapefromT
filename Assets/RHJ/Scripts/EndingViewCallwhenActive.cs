using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingViewCallwhenActive : MonoBehaviour
{
    // 인스펙터 창에서 호출할 엔딩 번호 넣기
    public int endingIndex;
    public float waittime;

    void Start()
    {
        StartCoroutine(CallEndingAfterDelay(waittime));
    }


    IEnumerator CallEndingAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ScoreManager.Instance.PlayerViewedEnding(endingIndex);
    }
}
