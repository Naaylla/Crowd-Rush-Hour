using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI finalScoreText;

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ShowGameOverScreen()
    {
        gameObject.SetActive(true); // show Game Over panel

        if (finalScoreText != null)
        {
            finalScoreText.text = "Final Score: " + ScoreManager.score;
        }
    }
}
