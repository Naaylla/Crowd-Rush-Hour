using UnityEngine;

public class AnswerButton : MonoBehaviour
{
    public bool isCorrect;             
    public Manager gameManager;        

    public void OnClick()
    {
        if (isCorrect)
        {
            gameManager.correctAnswer();
        }
        else
        {
            gameManager.wrongAnswer();
        }
    }
}
