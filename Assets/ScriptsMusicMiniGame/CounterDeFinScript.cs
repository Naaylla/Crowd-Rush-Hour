using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CounterDeFinScript : MonoBehaviour
{
    private int counter = 0;
    public TMP_Text EndText;
    public GameObject canva;
    public TMP_Text score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int scoreint = int.Parse(score.text);
        if (counter + scoreint >= 30)
        {
            canva.SetActive(true);
            AffichageTheEnd();
            StartCoroutine(WaitAndDoSomething(20f));
            SceneManager.LoadScene("SampleScene");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("point"))
        {
            Debug.Log("counted");
            counter++;
        }
    }

    void AffichageTheEnd()
    {
        int i = 255;
        while (i <= 0)
        {
            EndText.alpha = i;
            i--;
        }
    }

    IEnumerator WaitAndDoSomething(float seconds)
    {
        // Attendre X secondes
        yield return new WaitForSeconds(seconds);

    }
}
