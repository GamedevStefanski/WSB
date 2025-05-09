using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private ColorChange colorChange;

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Debug.Log("You're dead!");
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Killzone")
        {
            health -= 1;
            StartCoroutine(colorChange.ChangeColor());
            playerMovement.Jump();
        }
    }

}
