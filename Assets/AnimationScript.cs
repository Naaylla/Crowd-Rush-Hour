using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public GameObject effectPrefab; // ton prefab avec animation
    public Camera mainCamera;       // référence à la caméra principale

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldPos = mainCamera.ScreenToWorldPoint(mousePos);
            worldPos.z = 0f; // pour éviter que ce soit derrière la caméra

            Instantiate(effectPrefab, worldPos, Quaternion.identity);
        }
    }
}
