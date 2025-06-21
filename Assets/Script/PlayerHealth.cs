using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    // Health
    public float health;
    private bool canTakeDamage = true;
    private float invincibilityDuration = 0.5f;

    // Health UI
    [SerializeField] private int numOfHearts;
    private PlayerMovement playerMovement;
    [SerializeField] private ColorChange colorChange;
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;
    [SerializeField] private GameObject gameOverText;

    private void Start()
    {
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }
    void Update()
    {
        // Heart UI display – musi byæ zawsze aktualizowane
        if (health > numOfHearts)
            health = numOfHearts;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;

            hearts[i].enabled = (i < numOfHearts);
        }

        // Game losing
        if (health <= 0)
        {
            Destroy(this.gameObject);
            gameOverText.SetActive(true);

            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
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
        StartCoroutine(Invincibility());
    }

    private IEnumerator Invincibility()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(invincibilityDuration);
        canTakeDamage = true;
    }
}
