using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingViewCallwhenActive : MonoBehaviour
{
    // �ν����� â���� ȣ���� ���� ��ȣ �ֱ�
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
