using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction;
    public float speed = 150f;
    public float turnSpeed = 5f; // How sharply the bullet turns toward the heart

    public RectTransform battleBox;
    public RectTransform playerHeart;
    public float collisionDistance = 20f;

    private RectTransform rectTransform;
    private float homingTime = 4f; // Duration the bullet homes toward the heart

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // Homing for a limited time
        if (homingTime > 0)
        {
            Vector2 toHeart = (playerHeart.anchoredPosition - rectTransform.anchoredPosition).normalized;
            direction = Vector2.Lerp(direction, toHeart, turnSpeed * Time.deltaTime).normalized;
            homingTime -= Time.deltaTime;
        }

        // Move the bullet
        rectTransform.anchoredPosition += direction * speed * Time.deltaTime;

        // Rotate to face the movement direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rectTransform.rotation = Quaternion.Euler(0, 0, angle);

        // Collision detection with the player heart
        if (Vector2.Distance(rectTransform.anchoredPosition, playerHeart.anchoredPosition) < collisionDistance)
        {
            Debug.Log("HIT!");
            Destroy(gameObject);
        }

        // Destroy the bullet if it exits the battleBox area (with buffer)
        float halfWidth = battleBox.rect.width / 2;
        float halfHeight = battleBox.rect.height / 2;

        if (rectTransform.anchoredPosition.x < -halfWidth - 30 || 
            rectTransform.anchoredPosition.x > halfWidth + 30 ||
            rectTransform.anchoredPosition.y < -halfHeight - 30 ||
            rectTransform.anchoredPosition.y > halfHeight + 30)
        {
            Destroy(gameObject);
        }
    }
}
