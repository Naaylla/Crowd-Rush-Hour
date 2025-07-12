using UnityEngine;
using UnityEngine.UI;

public class ClickShrinkEffect : MonoBehaviour
{
    public RectTransform circle;
    public float duration = 0.5f;
    public float startSize = 200f;
    public float endSize = 20f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 screenPos = Input.mousePosition;
            StartCoroutine(ShrinkCircle(screenPos));
        }
    }

    System.Collections.IEnumerator ShrinkCircle(Vector2 pos)
    {
        // Position the circle
        circle.gameObject.SetActive(true);
        circle.position = pos;
        circle.sizeDelta = new Vector2(startSize, startSize);
        Image img = circle.GetComponent<Image>();
        img.color = new Color(1, 1, 1, 1); // Reset alpha

        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;

            float size = Mathf.Lerp(startSize, endSize, t);
            circle.sizeDelta = new Vector2(size, size);

            float alpha = Mathf.Lerp(1f, 0f, t);
            img.color = new Color(1, 1, 1, alpha);

            yield return null;
        }

        circle.gameObject.SetActive(false);
    }
}
