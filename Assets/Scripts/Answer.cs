using UnityEngine;

public class AnswerButton : MonoBehaviour
{
    public bool isCorrect;             
    public Manager gameManager;        

    public void OnClick()
    {
        if (isCorrect)
        {
            GameManager.instance.currentGameSatisfaction += 10;
            gameManager.correctAnswer();
           
        }
        else
        {
            GameManager.instance.currentGameSatisfaction -= 10;
            gameManager.wrongAnswer();
            
        }
    }
}
