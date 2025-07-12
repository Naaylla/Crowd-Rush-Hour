using UnityEngine;
using UnityEngine.UI;

public class SatisfactionBarScript : MonoBehaviour
{
    public Image satisBar;

    private static SatisfactionBarScript instance; // Pour �viter les doublons

    private float satisfaction;

    private Color green = new Color(145f / 255f, 224f / 255f, 7f / 255f);
    private Color red = new Color(245f / 255f, 8f / 255f, 13f / 255f);

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persiste entre les sc�nes
        }
        else
        {
            Destroy(gameObject); // D�truit les doublons si d�j� pr�sent
        }
    }

    void Update()
    {
        satisfaction = GameManager.instance.currentGameSatisfaction;
        satisBar.fillAmount = satisfaction / 100f;
        UpdateColor();
    }

    void UpdateColor()
    {
        satisBar.color = Color.Lerp(red, green, satisfaction / 100f);
    }
}
