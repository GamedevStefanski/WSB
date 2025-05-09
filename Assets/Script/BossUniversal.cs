using UnityEngine;
using System.Collections;
using System;
public class BossUniversal : MonoBehaviour
{
    // Universal stats
    public float health;


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
   
    private void Update()
    {
        if(health <= 0)
        {
            Console.WriteLine("You win!");
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= collision.gameObject.GetComponent<Bullet>().bulletDamage;
            StartCoroutine(ChangeColor());

        }
    }
    IEnumerator ChangeColor()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = originalColor;
    }
}
