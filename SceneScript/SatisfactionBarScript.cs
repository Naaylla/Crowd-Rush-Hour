using UnityEngine;
using UnityEngine.UI;

public class SatisfactionBarScript : MonoBehaviour
{
    public Image satisBar;
    private float satisfaction;

    private Color green = new Color(145f / 255f, 224f / 255f, 7f / 255f); // Normalisé entre 0-1
    private Color red = new Color(245f / 255f, 8f / 255f, 13f / 255f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        satisfaction = GameManager.instance.currentGameSatisfaction;
        UpdateColor();
    }

    // Update is called once per frame
    void Update()
    {
        satisfaction = GameManager.instance.currentGameSatisfaction;
        satisBar.fillAmount = satisfaction / 100;
        UpdateColor();
    }
    void UpdateColor()
    {
        satisBar.color = Color.Lerp(red, green, satisfaction /100);
    }
}
