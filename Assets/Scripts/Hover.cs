using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class HoverOutlineToggle : MonoBehaviour
{
    private SpriteRenderer sr;
    private MaterialPropertyBlock block;

    private static readonly string OUTLINE_ENABLED = "_OutlineEnabled";
    private static readonly string OUTLINE_WIDTH = "_Thickness";

    private float normalThickness = 0f;
    private float hoverThickness = 10f; // same as your default

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        block = new MaterialPropertyBlock();
    }

    void Start()
    {
        SetOutline(false);
    }

    void OnMouseEnter()
    {
        SetOutline(true);
    }

    void OnMouseExit()
    {
        SetOutline(false);
    }

    void SetOutline(bool on)
    {
        sr.GetPropertyBlock(block);

        block.SetFloat(OUTLINE_ENABLED, on ? 1f : 0f);
        block.SetFloat(OUTLINE_WIDTH, on ? hoverThickness : normalThickness);

        sr.SetPropertyBlock(block);
    }
}
