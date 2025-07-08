using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int scoreMiniGame = 0;
    public bool hadBeenDiverted = false;
    public float currentGameSatisfaction = 100f;
    public string playedActivite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
