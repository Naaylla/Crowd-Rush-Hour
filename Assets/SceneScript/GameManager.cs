using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [NonSerialized] public int scoreMiniGame = 0;
    [NonSerialized] public bool hadBeenDiverted = false;
    public float currentGameSatisfaction = 100f;
    [NonSerialized] public string playedActivite;
    [SerializeField] public float timeRemain = 10f;
    [NonSerialized] public string selectedType;

    public bool gameEnd = false;

    public float satisfactionDecreaseSpeed = 3.2f;

    [SerializeField] Animator transitionAnimator;

    public string[] Hobbies = { "music", "writing", "cooking", "painting" };

    public string lovedHobbie;
    public string hatedHobbie;

    public bool isReseted = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            int lovdHobbieIndex = UnityEngine.Random.Range(0, 3);
            int hatdHobbieIndex = UnityEngine.Random.Range(0, 3);
            while (lovdHobbieIndex == hatdHobbieIndex)
            {
                hatdHobbieIndex = UnityEngine.Random.Range(0, 3);
            }

            lovedHobbie = Hobbies[lovdHobbieIndex];
            hatedHobbie = Hobbies[hatdHobbieIndex];



        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (currentGameSatisfaction > 0f )
        {
            currentGameSatisfaction -= Time.deltaTime * satisfactionDecreaseSpeed;
            currentGameSatisfaction = Mathf.Clamp(currentGameSatisfaction, 0f, 100f);
        }

        if (timeRemain > 0f)
        {
            timeRemain -= Time.deltaTime;
            timeRemain = Mathf.Clamp(timeRemain, 0f, 999f); // met une limite haute si besoin
        }

        if (timeRemain == 0)
        {

            SceneManager.LoadScene("GameOver");
        }

        if (isReseted)
        {
            ResetGame();
            Debug.Log(currentGameSatisfaction);
            Debug.Log(timeRemain);

        }

    }

    public void NextLevel()
    {
        StartCoroutine(LoadLevel());
    }
    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(1);
        transitionAnimator.SetTrigger("Start");
    }

    public void ResetGame()
    {
        scoreMiniGame = 0;
        gameEnd = false;
        hadBeenDiverted = false;
        currentGameSatisfaction = 100f;
        playedActivite = "";
        timeRemain = 30f; // Valeur initiale du timer
        selectedType = "";

        // Réinitialiser les hobbies aléatoirement
        int lovdHobbieIndex = UnityEngine.Random.Range(0, Hobbies.Length);
        int hatdHobbieIndex = UnityEngine.Random.Range(0, Hobbies.Length);
        while (lovdHobbieIndex == hatdHobbieIndex)
        {
            hatdHobbieIndex = UnityEngine.Random.Range(0, Hobbies.Length);
        }
        lovedHobbie = Hobbies[lovdHobbieIndex];
        hatedHobbie = Hobbies[hatdHobbieIndex];
    }
}
