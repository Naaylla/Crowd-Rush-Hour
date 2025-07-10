using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DamageHealthScript : MonoBehaviour
{
    public Sprite heart;               // Sprite image for the heart
    public int pv = 3;                 // Number of lives
    public GameObject heartContainer;  // UI GameObject to hold the hearts
    public GameObject heartPrefab;     // Prefab with an Image component

    private List<GameObject> heartIcons = new List<GameObject>();

    void Start()
    {
        DrawHearts();
    }

    void DrawHearts()
    {
        // Clean existing hearts
        foreach (GameObject obj in heartIcons)
        {
            Destroy(obj);
        }
        heartIcons.Clear();

        // Create new hearts
        for (int i = 0; i < pv; i++)
        {
            GameObject newHeart = Instantiate(heartPrefab, heartContainer.transform);
            newHeart.GetComponent<Image>().sprite = heart;
            heartIcons.Add(newHeart);
        }
    }

    public void TakeDamage(int amount)
    {
        pv -= amount;
        pv = Mathf.Max(pv, 0); // Prevent negative values
        DrawHearts();
    }
}
