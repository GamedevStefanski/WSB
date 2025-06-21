using UnityEngine;

using System;
public class BossUniversal : MonoBehaviour
{
    // Universal stats
    public float health;

    // Color Change
    [SerializeField] private ColorChange colorChange;

    private void Update()
    {
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= collision.gameObject.GetComponent<Bullet>().bulletDamage;
            StartCoroutine(colorChange.ChangeColor());

        }
    }

}
