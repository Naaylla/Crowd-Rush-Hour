using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public Camera mainCamera;
    public LayerMask idiotLayer;
    public AudioSource[] As;
    int random;
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0)) // Clic gauche
        {
            random = Random.Range(0, As.Length);
            Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, idiotLayer);

            if (hit.collider != null && hit.collider.CompareTag("Idiot"))
            {
                
                As[random].Play();
                Destroy(hit.collider.gameObject); // Supprime l'idiot
                // Ajoute un son ou un effet ici si tu veux
            }
        }
    }
}
