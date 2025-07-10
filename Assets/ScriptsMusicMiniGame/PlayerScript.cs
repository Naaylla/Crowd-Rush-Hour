using TMPro;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private bool isColliding = false;
    public float speed = 20f;
    public int counter = 0;
    public AudioSource As;
    public TMP_Text score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        counter = 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("point")) Debug.Log("Colided");
        isColliding = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("exited");
        isColliding = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        if (mousePos.y > 4.3f) mousePos.y = 4.2f;
        if (mousePos.y < -4.3f) mousePos.y = -4.1f;

        Vector3 targetPosition = new Vector3(transform.position.x, mousePos.y, 0f);

        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);


        if (isColliding && Input.GetMouseButtonDown(0))
        {

            counter++;
            As.Play();
            Debug.Log(counter);

        }
        if (GameManager.instance != null)
        {
            GameManager.instance.scoreMiniGame = counter;

        }
        else
        {
            Debug.Log("problemo no instance detectedissimo");
        }
       
        score.text = counter.ToString();
    }

}
