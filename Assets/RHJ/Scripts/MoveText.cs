using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoveText : MonoBehaviour
{
    public float moveSpeed = 300f; // �ؽ�Ʈ�� �̵��ϴ� �ӵ�
    public float targetPosX1 = 242f; // ù ��° ��ǥ ��ġ
    public float targetPosX2 = 511f; // �� ��° ��ǥ ��ġ

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

        // ù ��° ��ǥ ��ġ���� �̵�
        while (rectTransform.anchoredPosition.x > targetPosX1)
        {
            rectTransform.anchoredPosition -= Vector2.right * moveSpeed * Time.deltaTime;
            yield return null;
        }

        //3�� ��ٸ���
        yield return new WaitForSeconds(4f);


        // �� ��° ��ǥ ��ġ���� �̵�
        while (rectTransform.anchoredPosition.x < targetPosX2)
        {
            rectTransform.anchoredPosition += Vector2.right * moveSpeed * Time.deltaTime;
            yield return null;
        }

        // �̵� �Ϸ� �� ��Ȱ��ȭ
        //gameObject.SetActive(false);

        isMoving = false;
    }
}
