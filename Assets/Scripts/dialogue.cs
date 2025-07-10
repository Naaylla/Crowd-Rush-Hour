using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject characterObject; // the visual character
    public GameObject dialogueUI;      // the dialogue UI box/panel
    public GameObject timerObject;     // the TIMER GameObject with the countdown script

    public Animator characterAnimator;
    public TMP_Text dialogueText;
    public string[] dialogueLines;
    public float typingSpeed = 0.05f;

    private int index = 0;
    private bool isTyping = false;

    void Start()
    {

        StartCoroutine(TypeLine());

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (isTyping)
            {
                // Skip the typing animation and display the full line
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

        foreach (char c in dialogueLines[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
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

            // Hide the character and dialogue UI
            characterObject.SetActive(false);
            dialogueUI.SetActive(false);

            // Show the TIMER and start the countdown
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

    // Show "Ready?"
    timerText.text = "Ready?";
    yield return new WaitForSeconds(1f);

    // Countdown from 3 to 1
    int countdown = 3;
    while (countdown > 0)
    {
        timerText.text = countdown.ToString();
        yield return new WaitForSeconds(1f);
        countdown--;
    }

    // Show "GO!" briefly
    timerText.text = "GO!";
    yield return new WaitForSeconds(1f);

    // Load your game scene
    UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
}


}
