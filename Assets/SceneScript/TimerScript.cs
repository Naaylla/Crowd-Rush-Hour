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
        timeRemaining = GameManager.instance.timeRemain;
        timerIsRunning = true;
        DisplayTime(timeRemaining);
        timeSinceLastSound = 0f;
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
                GameManager.instance.timeRemain = timeRemaining;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Temps écoulé !");
                timeRemaining = 0f;
                timerIsRunning = false;
                DisplayTime(60);
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ResetTimer(float newTime)
    {
        timeRemaining = newTime;
        timerIsRunning = true;
        DisplayTime(timeRemaining);
        timeSinceLastSound = 0f;
    }
}
