using UnityEngine;
using UnityEngine.SceneManagement;

public class backFromWriting : MonoBehaviour
{
    public string tutorialSceneName = "SampleScene";

    public void LoadTutorial()
    {
        SceneManager.LoadScene(tutorialSceneName);
    }
}