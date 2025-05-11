using UnityEngine;
using System.Collections;

public class bulletp : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;
    [SerializeField] 
    private float lifespan;

    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 direction = (target.transform.position - transform.position).normalized * speed;
        bulletRB.linearVelocity = new Vector2(direction.x, direction.y);
        Destroy(this.gameObject, 2);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().LoseHealth();
        }
    }
    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(lifespan);
        Destroy(this.gameObject);
    }
}
