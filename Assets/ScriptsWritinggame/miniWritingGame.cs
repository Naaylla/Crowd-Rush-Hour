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
    [SerializeField] Vector2Int[] hiddenWordRanges = { new Vector2Int(6, 20) }; // exemple : "puissant"
    [SerializeField] float timeLimit = 30f;

    [SerializeField] AudioSource tapingKey;

    string displayText;
    float timer;
    int revealIndex = 0;
    char[] currentChars;

    void Start()
    {
        int randNum = UnityEngine.Random.Range(0, nbrOfSentences);
        fullText = AllPhrase[randNum];
        timer = timeLimit;
        // Prépare currentChars
        currentChars = fullText.ToCharArray();
        // Applique le masque alpha aux mots cachés
        foreach (var range in hiddenWordRanges)
        {
            for (int i = range.x; i < range.y; i++)
                currentChars[i] = '\0'; // on marque pour cacher
        }
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
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
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
        // Trouve le prochain caractère caché et compare
        for (int i = revealIndex; i < fullText.Length; i++)
        {
            if (currentChars[i] != '\0') continue;
            if (char.ToLower(inputChar) == char.ToLower(fullText[i]))
            {
                // On révèle ce caractère
                currentChars[i] = fullText[i];
                revealIndex = i + 1;
                UpdateDisplayText();
                CheckVictory();
            }
            // si faux, on peut pénaliser ou ignorer
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
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
