using UnityEngine;

public class TVClickTrigger : MonoBehaviour
{
    public TVDialogueManager dialogueManager;

    [TextArea(2, 5)]
    public string[] dialogueLines = {
        "BREAKING NEWS!",
        "The crowd is going wild...",
        "More chaos coming up next!"
    };

    private bool triggered = false;

    void Update()
    {
        if (triggered) return;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (Input.GetMouseButtonDown(0) && hit.collider != null && hit.collider.gameObject == gameObject)
        {
            dialogueManager.StartDialogue(dialogueLines);
            triggered = true;
        }
    }
}
