using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 10f; // seconds
    public TextMeshProUGUI countdownText;

    private float currentTime;
    private bool isCounting = false;

    void Start()
    {
        currentTime = countdownTime;
        UpdateDisplay();
        isCounting = true;
    }

    void Update()
    {
        if (isCounting)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0f)
            {
                currentTime = 0f;
                isCounting = false;
                // Do something when timer reaches 0
                Debug.Log("Time's up!");
            }

            UpdateDisplay();
        }
    }

    void UpdateDisplay()
    {
        countdownText.text = Mathf.Ceil(currentTime).ToString("0");
    }
}
