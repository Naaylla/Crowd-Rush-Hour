using UnityEngine;

public class GameLogicScript : MonoBehaviour
{
    public GameObject player;
    public GameObject pointPrefab;
    private string[] Hobbies = { "music", "cooking", "painting" };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.instance.hadBeenDiverted = true;
        GameManager.instance.playedActivite = Hobbies[2]; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("return to normal scene");
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

        
    }


}
