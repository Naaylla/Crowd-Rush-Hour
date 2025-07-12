using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMain : MonoBehaviour
{


    public void LoadMain()
    {
        SceneManager.LoadScene("main menu");
    }
}