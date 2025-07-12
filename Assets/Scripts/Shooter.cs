using UnityEngine;
using UnityEngine.UI;

public class ClickEffectSpawner : MonoBehaviour
{
    public RectTransform canvasTransform;       // assign the Canvas
    public GameObject circlePrefab;             // assign the prefab here
    public float duration = 0.5f;
    public float startSize = 200f;
    public float endSize = 20f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 screenPos = Input.mousePosition;
            GameObject circle = Instantiate(circlePrefab, canvasTransform);
            StartCoroutine(ShrinkAndFade(circle.GetComponent<RectTransform>(), screenPos));
        }
    }

    System.Collections.IEnumerator ShrinkAndFade(RectTransform circle, Vector2 pos)
    {
        circle.gameObject.SetActive(true);
        circle.position = pos;
        circle.sizeDelta = new Vector2(startSize, startSize);

        Image img = circle.GetComponent<Image>();
        img.color = new Color(1, 1, 1, 1); // full white with alpha

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

        Destroy(circle.gameObject); // remove the circle after it's done
    }
}
