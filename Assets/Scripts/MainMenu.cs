using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("dialogue");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
