using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public RectTransform battleBox;
    public RectTransform playerHeart;

    void Start()
    {
        InvokeRepeating("SpawnBullet", 1f, 1.0f);
    }

    void SpawnBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, battleBox);
        RectTransform bulletRT = bullet.GetComponent<RectTransform>();
        Bullet bulletScript = bullet.GetComponent<Bullet>();

        int side = Random.Range(0, 2); // 0 = left, 1 = bottom

        if (side == 0)
        {
            // Left side → move right
            bulletRT.anchoredPosition = new Vector2(
                -battleBox.rect.width / 2,
                Random.Range(-battleBox.rect.height / 2, battleBox.rect.height / 2)
            );
            bulletScript.direction = Vector2.right;
        }
        else
        {
            // Bottom side → move up
            bulletRT.anchoredPosition = new Vector2(
                Random.Range(-battleBox.rect.width / 2, battleBox.rect.width / 2),
                -battleBox.rect.height / 2
            );
            bulletScript.direction = Vector2.up;
        }

        bulletScript.speed = Random.Range(100f, 250f);
        bulletScript.battleBox = battleBox;
        bulletScript.playerHeart = playerHeart;
    }
}
