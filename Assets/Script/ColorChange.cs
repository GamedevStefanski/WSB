using UnityEngine;
using System.Collections;
public class ColorChange : MonoBehaviour
{
    // Color changing
    private Color originalColor;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }
    }
    public IEnumerator ChangeColor()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = originalColor;
    }
}
