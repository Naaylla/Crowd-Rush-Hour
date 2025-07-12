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

    // Messages à définir
    private string[] positiveMsg = new string[]
    {
    "Loving it!",
    "More of this please!",
    "Haha that was funny!",
    "Such a cool moment!",
    "Loving it!",
    "More of this please!",
    "Haha that was funny!",
    "Such a cool moment!",
    "Loving it!",
    "More of this please!"
    };

    private string[] negativeMsg = new string[]
    {
    "Boring...",
    "What's happening?",
    "This sucks.",
    "I'm leaving.",
    "Worst game ever.",
    "Boring...",
    "What's happening?",
    "This sucks.",
    "I'm leaving.",
    "Worst game ever."
    };

    void Start()
    {
        currentSatis = GameManager.instance.currentGameSatisfaction;
        StartCoroutine(SpawnChat());
    }

    void Update()
    {
        currentSatis = GameManager.instance.currentGameSatisfaction;
    }

    IEnumerator SpawnChat()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));

            GameObject msg = Instantiate(chatMessagePrefab, chatContent);
            TMP_Text text = msg.GetComponent<TMP_Text>();

            float satisfactionRatio = Mathf.Clamp01(currentSatis / 100f); // entre 0 et 1

            // Tirage aléatoire : si satisfaction haute, + de chances de msg positifs
            bool isPositive = Random.value < satisfactionRatio;
            int randomSpec = Random.Range(0, 20);
            string[] sourceArray = isPositive ? (positiveMsg) : negativeMsg;
            text.text = "Spec #"+ randomSpec.ToString()+ " : " + sourceArray[Random.Range(0, sourceArray.Length)];
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


