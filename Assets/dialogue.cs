using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText;
    public GameObject dialoguePanel;

    [TextArea(2, 5)]
    public string[] dialogueLines;

    public float typingSpeed = 0.03f;
    private int currentLineIndex;
    private bool isTyping;
    private bool skipTyping;

    void Start()
    {
        if (dialoguePanel == null || dialogueText == null)
        {
            Debug.LogError("Dialogue UI elements not assigned!");
            return;
        }

        dialoguePanel.SetActive(true);
        currentLineIndex = 0;
        StartCoroutine(TypeLine(dialogueLines[currentLineIndex]));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                skipTyping = true;
            }
            else
            {
                NextLine();
            }
        }
    }

    IEnumerator TypeLine(string line)
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (char letter in line.ToCharArray())
        {
            if (skipTyping)
            {
                dialogueText.text = line;
                break;
            }

            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
        skipTyping = false;
    }

    void NextLine()
    {
        currentLineIndex++;
        if (currentLineIndex < dialogueLines.Length)
        {
            StartCoroutine(TypeLine(dialogueLines[currentLineIndex]));
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
    }
}
