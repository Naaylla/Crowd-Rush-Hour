using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [NonSerialized] public int scoreMiniGame = 0;
    [NonSerialized] public bool hadBeenDiverted = false;
    public float currentGameSatisfaction = 100f;
    [NonSerialized] public string playedActivite;
    [NonSerialized] public float timeRemain = 60f;

    public string[] Hobbies = { "music", "cooking", "painting", "writing"};

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
