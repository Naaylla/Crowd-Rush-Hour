using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    private AudioSource audioSource;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();

        CheckScene(SceneManager.GetActiveScene().name);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CheckScene(scene.name);
    }

    void CheckScene(string sceneName)
    {
        if (sceneName == "MiniGameMusic")
        {
            if (audioSource != null)
                audioSource.Pause(); // Met la musique en pause
        }
        else
        {
            if (audioSource != null && !audioSource.isPlaying)
                audioSource.UnPause(); // Reprend la musique si elle est en pause
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}