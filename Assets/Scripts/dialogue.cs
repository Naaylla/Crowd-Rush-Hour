using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public AudioSource typingAudioSource;
    public GameObject characterObject; // the visual character
    public GameObject dialogueUI;      // the dialogue UI box/panel
    public GameObject timerObject;     // the TIMER GameObject with the countdown script
    public GameObject boxObject;       // the box background or frame

    public Animator characterAnimator;
    public TMP_Text dialogueText;
    public string[] dialogueLines;
    public float typingSpeed = 0.03f; // faster typing speed

    private int index = 0;
    private bool isTyping = false;
    private bool dialogueEnded = false;

    void Start()
    {
        StartCoroutine(TypeLine());
    }

    void Update()
    {
        if (dialogueEnded) return; // Prevent further input after dialogue ends

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (isTyping)
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[index];
                characterAnimator.SetBool("IsTalking", false);
                isTyping = false;
            }
            else
            {
                NextLine();
            }
        }
    }
IEnumerator TypeLine()
{
    isTyping = true;
    characterAnimator.SetBool("IsTalking", true);
    dialogueText.text = "";

    // ✅ START the typing sound
    if (typingAudioSource != null && typingAudioSource.clip != null)
    {
        typingAudioSource.loop = true;
        typingAudioSource.Play();
    }

    foreach (char c in dialogueLines[index].ToCharArray())
    {
        dialogueText.text += c;
        yield return new WaitForSeconds(typingSpeed);
    }

    // ✅ STOP the typing sound
    if (typingAudioSource != null)
    {
        typingAudioSource.Stop();
    }

    characterAnimator.SetBool("IsTalking", false);
    isTyping = false;
}



    void NextLine()
    {
        if (index < dialogueLines.Length - 1)
        {
            index++;
            StartCoroutine(TypeLine());
        }
        else
        {
            // Dialogue is finished
            dialogueText.text = "";
            characterObject.SetActive(false);
            dialogueUI.SetActive(false);
            boxObject.SetActive(false); // Hide the box too

            dialogueEnded = true; // Prevent further input
            timerObject.SetActive(true);
            StartCoroutine(CountdownThenStartGame());
        }
    }

    IEnumerator CountdownThenStartGame()
    {
        TMP_Text timerText = timerObject.GetComponentInChildren<TMP_Text>();

        if (timerText == null)
        {
            Debug.LogError("No TMP_Text found inside TIMER!");
            yield break;
        }

        timerText.text = "Ready?";
        yield return new WaitForSeconds(0.5f);

        int countdown = 3;
        while (countdown > 0)
        {
            timerText.text = countdown.ToString();
            yield return new WaitForSeconds(0.5f); // faster countdown
            countdown--;
        }

        timerText.text = "GO!";
        yield return new WaitForSeconds(0.5f);

        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
}
