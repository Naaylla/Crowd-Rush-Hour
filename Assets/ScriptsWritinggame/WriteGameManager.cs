using TMPro;
using UnityEngine;

public class WriteGameManager : MonoBehaviour
{
    [SerializeField] TMP_Text uiText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.instance.hadBeenDiverted = true;
        GameManager.instance.playedActivite = GameManager.instance.Hobbies[2];
    }

    // Update is called once per frame
    void Update()
    {
        if (uiText.text == "Win")
        {
            GameManager.instance.scoreMiniGame = 30;
        }else
        {
            GameManager.instance.scoreMiniGame = 0;
        }
    }
}
