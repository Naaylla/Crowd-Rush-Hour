using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class SceneManage : MonoBehaviour
{
    private Keyboard keyboard;

    void Start()
    {
        keyboard = Keyboard.current; // R�cup�re le clavier actuel
    }
    void Update()
    {
        if (keyboard.iKey.isPressed)
        {
            Debug.Log("Tentative de chargement de la sc�ne Music");
            // Charge par nom si l'index pose probl�me
            UnityEngine.SceneManagement.SceneManager.LoadScene("MiniGameMusic");
        }
        if (keyboard.oKey.isPressed)
        {
            Debug.Log("Tentative de chargement de la sc�ne Writing...");
            // Charge par nom si l'index pose probl�me
            UnityEngine.SceneManagement.SceneManager.LoadScene("miniGameWriting");
        }
    }
}



