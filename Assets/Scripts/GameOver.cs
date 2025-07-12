using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour
{
    public void RestartGame()
    {
        GameManager.instance.isReseted = true;
        SceneManager.LoadScene("dialogue");
    }

    public void GoToMainMenu()
    {
        GameManager.instance.isReseted = true;
        SceneManager.LoadScene("main menu");
    }
}
