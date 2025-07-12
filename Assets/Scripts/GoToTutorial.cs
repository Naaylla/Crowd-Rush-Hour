using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToTutorial : MonoBehaviour
{
    public string tutorialSceneName = "HowToPlay"; 

    public void LoadTutorial()
    {
        SceneManager.LoadScene(tutorialSceneName);
    }
}
