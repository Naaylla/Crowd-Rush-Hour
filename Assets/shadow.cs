using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverShadow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Shadow shadow;

    void Start()
    {
        shadow = GetComponent<Shadow>();
        if (shadow == null)
        {
            shadow = gameObject.AddComponent<Shadow>();
            shadow.effectColor = new Color(0, 0, 0, 0.5f);
            shadow.effectDistance = Vector2.zero;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        shadow.effectDistance = new Vector2(3, -3);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        shadow.effectDistance = Vector2.zero;
    }
}
