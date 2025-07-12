using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("dialogue");

    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("main menu");
    }
}
