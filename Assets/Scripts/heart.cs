using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit by: " + other.name);
    }
}
