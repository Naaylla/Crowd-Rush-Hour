using UnityEngine;
using System.Collections;
using TMPro;

public class Manager : MonoBehaviour
{
    public GameObject[] Levels;
    public TMP_Text feedbackText;
    public float feedbackDuration = 1.5f;

    public void correctAnswer()
{
    UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
}


    public void wrongAnswer()
    {
        StartCoroutine(ShowWrongAnswer());
    }

    IEnumerator ShowWrongAnswer()
    {
        feedbackText.text = "WRONG ANSWER -10";
        feedbackText.gameObject.SetActive(true);
        yield return new WaitForSeconds(feedbackDuration);
        feedbackText.gameObject.SetActive(false);
    }
}
