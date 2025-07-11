using UnityEngine;

public class PointsMovingScript : MonoBehaviour
{
    public float speed = 5f;
    private bool isColliding = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("star")) isColliding = true;
        if (collision.CompareTag("counter")) Debug.Log("conté");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isColliding = false;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < -12.0f)
        {
            Destroy(gameObject);
        }
        if (isColliding && Input.GetMouseButtonDown(0)) {
            Destroy(gameObject);
        }
    }
}
