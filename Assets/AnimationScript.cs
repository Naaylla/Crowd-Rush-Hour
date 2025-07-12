using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public GameObject effectPrefab; // ton prefab avec animation
    public Camera mainCamera;       // r�f�rence � la cam�ra principale

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldPos = mainCamera.ScreenToWorldPoint(mousePos);
            worldPos.z = 0f; // pour �viter que ce soit derri�re la cam�ra

            Instantiate(effectPrefab, worldPos, Quaternion.identity);
        }
    }
}
