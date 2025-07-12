using System;
using TMPro;
using UnityEngine;


public class TextCompletionGame : MonoBehaviour
{
    const int nbrOfSentences = 3;
    [SerializeField] TMP_Text uiText;
    [SerializeField] string[] AllPhrase = new string[nbrOfSentences]{ "90% of studying is staring at the same page and hoping it makes sense.",
    "Game devs fix one bug and spawn three more.",
    "Did you know that studying at USTHB is a foretaste of war?",
    };
    [SerializeField] string fullText;
    [SerializeField] Vector2Int hiddenWordRanges = new Vector2Int(7, 20); 
    [SerializeField] float timeLimit = 30f;

    [SerializeField] AudioSource tapingKey;

    float timer;
    int revealIndex = 0;
    char[] currentChars;
    int addingToSatis = 1;

    void Start()
    {
        if (GameManager.instance.lovedHobbie == GameManager.instance.Hobbies[1]) addingToSatis = 2;
        if (GameManager.instance.hatedHobbie == GameManager.instance.Hobbies[1]) addingToSatis = 0;
        int randNum = UnityEngine.Random.Range(0, nbrOfSentences);
        fullText = AllPhrase[randNum];
        timer = timeLimit;
        // Prépare currentChars
        currentChars = fullText.ToCharArray();
        // Applique le masque alpha aux mots cachés
        hiddenWordRanges = new Vector2Int(UnityEngine.Random.Range(0, 10), UnityEngine.Random.Range(20, 30));

        for (int i = hiddenWordRanges.x; i < hiddenWordRanges.y; i++)
            if (fullText[i] != ' ')
                currentChars[i] = '\0'; // on marque pour cacher

        UpdateDisplayText();
    }

    void UpdateDisplayText()
    {
        var sb = new System.Text.StringBuilder();
        for (int i = 0; i < fullText.Length; i++)
        {
            if (currentChars[i] == '\0')
                sb.Append("<color=#99996650>" + fullText[i] + "</color>");
            else
                sb.Append(fullText[i]);
        }
        uiText.text = sb.ToString();
    }

    void Update()
    {
        // Timer
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            EndGame(false);
            UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
            return;
        }

        // Saisie clavier
        foreach (char c in Input.inputString)
        {
            TryRevealLetter(c);
            tapingKey.Play();
        }
    }

    void TryRevealLetter(char inputChar)
    {
        for (int i = revealIndex; i < fullText.Length; i++)
        {
            if (currentChars[i] != '\0') continue; // déjà révélé

            // saute les espaces automatiquement
            if (fullText[i] == ' ')
            {
                currentChars[i] = ' ';
                revealIndex = i + 1;
                continue;
            }

            if (char.ToLower(inputChar) == char.ToLower(fullText[i]))
            {
                currentChars[i] = fullText[i];
                revealIndex = i + 1;
                GameManager.instance.currentGameSatisfaction += addingToSatis;
                UpdateDisplayText();
                CheckVictory();
            }
            break;
        }
    }


    void CheckVictory()
    {
        // Si plus aucun '\0', victoire
        foreach (var ch in currentChars)
            if (ch == '\0') return;
        EndGame(true);
    }

    void EndGame(bool win)
    {
        uiText.text = win ? "Win" : "Lose";
        enabled = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
}
