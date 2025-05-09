using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 15f;
    public float bulletDamage = 10f;
    public Rigidbody2D rb;

    private void FixedUpdate()
    {
        rb.linearVelocity = transform.right * bulletSpeed;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Destroy(this.gameObject);

    }




}
