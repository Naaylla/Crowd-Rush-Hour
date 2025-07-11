using System.Collections;
using UnityEngine;
using TMPro;

public class FakeTwitchChat : MonoBehaviour
{
    public Transform chatContent;
    public GameObject chatMessagePrefab;
    public float minDelay = 0.5f;
    public float maxDelay = 2f;
    private float currentSatis;
    private string[] chatMessages = new string[]
    {
        "Nayla: W's in the chaat",
        "Yacine: W",
        "Kenpa: W",
        "Nana: W",
        "Yacine: Im coding",
        "Kenpa: same",
        "Nana: send help",
        "Nayla: same fr",
        "Nayla: W's in the chaat",
        "Yacine: W",
        "Kenpa: W",
        "Nana: W",
        "Yacine: Im coding",
        "Kenpa: same",
        "Nana: send help",
        "Nayla: same fr",
        "Nayla: W's in the chaat",
        "Yacine: W",
        "Kenpa: W",
        "Nana: W",
        "Yacine: Im coding",
        "Kenpa: same",
        "Nana: send help",
        "Nayla: same fr"
    };

    void Start()
    {
        currentSatis = GameManager.instance.currentGameSatisfaction;
        StartCoroutine(SpawnChat());
    }
    private void Update()
    {
        currentSatis = GameManager.instance.currentGameSatisfaction;
    }


    // THIS IS RANDOM GENERATING


    IEnumerator SpawnChat()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
            GameObject msg = Instantiate(chatMessagePrefab, chatContent);
            TMP_Text text = msg.GetComponent<TMP_Text>();
            text.text = chatMessages[Random.Range(0, chatMessages.Length)];
        }
    }


    // THIS IS ONE BY ONE
    /*IEnumerator SpawnChat()
{
    for (int i = 0; i < chatMessages.Length; i++)
    {
        GameObject msg = Instantiate(chatMessagePrefab, chatContent);
        TMP_Text text = msg.GetComponent<TMP_Text>();
        text.text = chatMessages[i];

        yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
    }
    */
}


