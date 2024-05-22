using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhiteScreenFade : MonoBehaviour
{
    public float fadeDuration = 2.0f; // 페이드 인 시간
    private Image image;

    void OnEnable()
    {
        image = GetComponent<Image>();
        if (image != null)
        {
            StartCoroutine(FadeIn());
        }
        else
        {
            Debug.LogError("Image component not found!");
        }
    }

    IEnumerator FadeIn()
    {
        float elapsedTime = 0.0f;
        Color color = image.color;
        color.a = 0.0f;
        image.color = color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            image.color = color;
            yield return null;
        }

        color.a = 1.0f;
        image.color = color;
    }
}
