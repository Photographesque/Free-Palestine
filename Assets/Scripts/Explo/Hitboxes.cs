using UnityEngine;

public class Hitboxes : MonoBehaviour
{
    private Collider2D col;
    public Color originalColor;
    public Color highlightColor = Color.yellow;

    void Start()
    {
        col = GetComponent<Collider2D>();
        originalColor = col.GetComponent<SpriteRenderer>().color;
    }

    void OnMouseEnter()
    {
        col.GetComponent<SpriteRenderer>().color = highlightColor;
    }

    void OnMouseExit()
    {
        col.GetComponent<SpriteRenderer>().color = originalColor;
    }
}
