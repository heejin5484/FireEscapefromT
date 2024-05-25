using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoveText : MonoBehaviour
{
    public float moveSpeed = 300f; // 텍스트가 이동하는 속도
    public float targetPosX1 = 242f; // 첫 번째 목표 위치
    public float targetPosX2 = 511f; // 두 번째 목표 위치

    private RectTransform rectTransform;
    private bool isMoving = false;


    void OnEnable()
    {
        rectTransform = GetComponent<RectTransform>();
        if (rectTransform != null && !isMoving)
        {
            StartCoroutine(Move());
        }
        else
        {
            Debug.LogError("RectTransform component not found!");
        }
    }

    IEnumerator Move()
    {
        isMoving = true;

        // 첫 번째 목표 위치까지 이동
        while (rectTransform.anchoredPosition.x > targetPosX1)
        {
            rectTransform.anchoredPosition -= Vector2.right * moveSpeed * Time.deltaTime;
            yield return null;
        }

        //3초 기다리기
        yield return new WaitForSeconds(4f);


        // 두 번째 목표 위치까지 이동
        while (rectTransform.anchoredPosition.x < targetPosX2)
        {
            rectTransform.anchoredPosition += Vector2.right * moveSpeed * Time.deltaTime;
            yield return null;
        }

        // 이동 완료 후 비활성화
        //gameObject.SetActive(false);

        isMoving = false;
    }
}
