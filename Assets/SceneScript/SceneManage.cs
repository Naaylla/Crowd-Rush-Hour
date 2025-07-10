using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class SceneManage : MonoBehaviour
{
    private Keyboard keyboard;

    void Start()
    {
        keyboard = Keyboard.current; // Récupère le clavier actuel
    }
    void Update()
    {
        if (keyboard.iKey.isPressed)
        {
            Debug.Log("Tentative de chargement de la scène Music");
            // Charge par nom si l'index pose problème
            UnityEngine.SceneManagement.SceneManager.LoadScene("MiniGameMusic");
        }
        if (keyboard.oKey.isPressed)
        {
            Debug.Log("Tentative de chargement de la scène Writing...");
            // Charge par nom si l'index pose problème
            UnityEngine.SceneManagement.SceneManager.LoadScene("miniGameWriting");
        }
    }
}



