using UnityEngine;
using System.Collections;

public class Enemybullet : MonoBehaviour
{
    [SerializeField] private float lifespan;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
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

