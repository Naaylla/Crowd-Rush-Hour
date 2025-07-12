using System.Collections;
using TMPro;
using UnityEngine;

public class TVDialogueManager : MonoBehaviour
{
    public GameObject tvWindow;         // The FlashNewsScreen GameObject
    public TMP_Text dialogueText;       // The TMP text inside the TV
    public float typingSpeed = 0.04f;   // Time between each letter
    public float delayBetweenLines = 1f;

    public void StartDialogue(string[] lines)
    {
        StopAllCoroutines();
        tvWindow.SetActive(true);
        StartCoroutine(PlayDialogue(lines));
    }

    private IEnumerator PlayDialogue(string[] lines)
    {
        foreach (string line in lines)
        {
            yield return StartCoroutine(TypeLine(line));
            yield return new WaitForSeconds(delayBetweenLines);
        }

        tvWindow.SetActive(false);
    }

    private IEnumerator TypeLine(string line)
    {
        dialogueText.text = "";
        foreach (char c in line)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
