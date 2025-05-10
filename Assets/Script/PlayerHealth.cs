using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    // Health
    public float health;
    private bool canTakeDamage = true;
    private float invincibilityDuration = 0.5f;

    // Health UI
    [SerializeField] private int numOfHearts;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private ColorChange colorChange;
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;
    [SerializeField] private GameObject gameOverText;

    void Update()
    {
        // Game losing
        if (health <= 0)
        {
            Debug.Log("You're dead!");
            Destroy(this.gameObject);
            gameOverText.SetActive(true);
        }

        // Heart UI display
        if(health > numOfHearts)
            health = numOfHearts;

        for (int i = 0; i < numOfHearts; i++)
        {
            if (i<health)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;

            if (i < numOfHearts)
                hearts[i].enabled = true;
            else
                hearts[i].enabled = false;
        }
    }

    // Jump after touching something you shouldn't have 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Killzone")
        {
            LoseHealth();
            StartCoroutine(colorChange.ChangeColor());
            playerMovement.Jump();
        }
    }
    public void LoseHealth()
    {
        if (!canTakeDamage) 
            return;

        health -= 1;
        Debug.Log("Gracz otrzyma³ obra¿enia! Zdrowie: " + health);
        StartCoroutine(Invincibility());
    }

    private IEnumerator Invincibility()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(invincibilityDuration);
        canTakeDamage = true;
    }
}
