using UnityEngine;
using UnityEngine.SceneManagement;

public class selectingOptionMusic : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (Input.GetMouseButtonDown(0) && hit.collider != null)
        {
            if (hit.collider.CompareTag("jazz")) GameManager.instance.selectedType = "jazz";
            if (hit.collider.CompareTag("rock")) GameManager.instance.selectedType = "rock";
            if (hit.collider.CompareTag("classic")) GameManager.instance.selectedType = "classic";

            SceneManager.LoadScene("MiniGameMusic");

        }
    }
    

}
