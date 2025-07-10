using UnityEngine;
using System.Collections;

public class InteractionDetection : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject flashNewsManager;
    [SerializeField] float timing = 4f;

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (Input.GetMouseButtonDown(0) && hit.collider != null && hit.collider.gameObject == gameObject)
        {
            flashNewsManager.SetActive(true);
            StartCoroutine(ReappearAfterDelay(timing)); // Lance une coroutine qui le réactive après 5 secondes
        }
    }

    private IEnumerator ReappearAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        flashNewsManager.SetActive(false);
    }
}
