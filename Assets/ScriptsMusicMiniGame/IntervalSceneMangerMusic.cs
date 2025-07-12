using UnityEngine;

public class IntervalSceneMangerMusic : MonoBehaviour
{
    public int addingToSatisfaction=1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.instance.currentGameSatisfaction += addingToSatisfaction;
    }
}
