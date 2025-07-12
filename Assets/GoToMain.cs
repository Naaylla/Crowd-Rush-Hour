using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMain : MonoBehaviour
{
    public void LoadMain()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        string nextScene = "";

        // Exemple de logique pour naviguer selon la scène actuelle
        switch (currentScene)
        {
            case "HowToPlay":
                nextScene = "main menu";
                break;
            case "MiniGameMusic":
                nextScene = "SampleScene";
                break;
            case "miniGameWriting":
                nextScene = "SampleScene";
                break;
            case "shootMiniGame":
                nextScene = "SampleScene";
                break;
            default:
                break;
        }

        SceneManager.LoadScene(nextScene);
    }
}