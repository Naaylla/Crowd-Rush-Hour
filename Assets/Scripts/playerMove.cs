using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 200f; // adjust as needed
    private RectTransform rectTransform;
    private RectTransform boxBounds;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        boxBounds = transform.parent.GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        rectTransform.anchoredPosition += input * speed * Time.deltaTime;

        ClampInsideBox();
    }

    void ClampInsideBox()
    {
        Vector2 pos = rectTransform.anchoredPosition;
        Vector2 halfSize = (boxBounds.rect.size - rectTransform.rect.size) / 2f;

        pos.x = Mathf.Clamp(pos.x, -halfSize.x, halfSize.x);
        pos.y = Mathf.Clamp(pos.y, -halfSize.y, halfSize.y);

        rectTransform.anchoredPosition = pos;
    }
}
