using UnityEngine;
using UnityEngine.UI; // or TMPro for TextMeshPro
using System.Collections;

public class UIFader : MonoBehaviour
{
    public Graphic uiElement; // Image, Text, or TextMeshProUGUI
    public float duration = 1f;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float elapsed = 0f;
        Color color = uiElement.color;
        color.a = 0f;
        uiElement.color = color;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsed / duration);
            uiElement.color = color;
            yield return null;
        }
    }
}
