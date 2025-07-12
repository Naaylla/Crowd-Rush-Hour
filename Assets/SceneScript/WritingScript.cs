using UnityEngine;

public class WritingScript : MonoBehaviour
{
    public GameObject TV;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (Input.GetMouseButtonDown(0) && hit.collider != null && hit.collider.gameObject == gameObject)
        {
            if (!TV.activeInHierarchy)
            UnityEngine.SceneManagement.SceneManager.LoadScene("miniGameWriting");
        }
    }
}
