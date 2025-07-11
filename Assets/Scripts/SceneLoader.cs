using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{
    public string sceneName;

    public void GoToScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
