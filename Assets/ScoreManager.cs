using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TMP_Text scoreText;
    public TMP_Text messageText;

    private void Start()
    {
        // Simulate a random score for testing
        float randomScore = Random.Range(0f, 100f);
        ShowGameOverScreen(randomScore);
    }

    public void ShowGameOverScreen(float score)
    {
        gameOverPanel.SetActive(true);
        scoreText.text = $"Your Satisfiability Score: {score:F1}%";

        if (score == 0)
        {
            messageText.text = "The crowd RIOTED !";
        }
        else if (score < 50)
        {
            messageText.text = "The crowd is... unimpressed ";
        }
        else if (score >= 80)
        {
            messageText.text = "The crowd ADORES you!";
        }
        else
        {
            messageText.text = "Not bad! Some cheers, some yawns ";
        }
    }
}
