using UnityEngine;
using UnityEngine.SceneManagement;

public class SatisfactionBarPositionManager : MonoBehaviour
{
    public RectTransform barTransform;

    // Tu définis ici les positions selon la scène
    [Header("Positions par scène")]
    public Vector2 positionSceneMenu = new Vector2(0,0);
    public Vector2 positionSceneMiniJeu = new Vector2(0, 0);
    public Vector2 positionSceneFinale = new Vector2(0, 0);

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        UpdateBarPosition(SceneManager.GetActiveScene().name);
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateBarPosition(scene.name);
    }

    void UpdateBarPosition(string sceneName)
    {
        if (sceneName == "SampleScene")
            barTransform.anchoredPosition = positionSceneMenu;
        else if (sceneName == "MiniGameMusic")
            barTransform.anchoredPosition = positionSceneMiniJeu;
        else if (sceneName == "miniGameWriting")
            barTransform.anchoredPosition = positionSceneFinale;
        // Ajoute autant de cas que nécessaire
    }
}
