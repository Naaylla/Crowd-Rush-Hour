using UnityEngine;

public class HowToPlayUI : MonoBehaviour
{
    public GameObject howToPlayPanel;

    public void ShowInstructions()
    {
        howToPlayPanel.SetActive(true);
    }

    public void HideInstructions()
    {
        howToPlayPanel.SetActive(false);
    }
}
