using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public float timeRemaining = 60f;
    public bool timerIsRunning = true;
    public TMP_Text timeText;
    public AudioSource audioSource;

    private float soundInterval = 2f;         // Intervalle entre les sons (en secondes)
    private float timeSinceLastSound = 0f;    // Temps depuis le dernier son joué

    void Start()
    {   
        DisplayTime(timeRemaining);
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                timeSinceLastSound += Time.deltaTime;

                if (timeSinceLastSound >= soundInterval)
                {
                    audioSource.Play(); // Joue le son
                    timeSinceLastSound = 0f;
                }

                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Temps écoulé !");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
