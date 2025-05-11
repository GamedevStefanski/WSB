using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float fireRate = 0.2f;
    public Transform firingPoint;
    public GameObject bulletPrefab;

    float timeUntilFire;

    void Update()
    {
        Vector2 shootDirection = Vector2.zero;


        if (Input.GetKey(KeyCode.UpArrow)) shootDirection += Vector2.up;
        if (Input.GetKey(KeyCode.DownArrow)) shootDirection += Vector2.down;
        if (Input.GetKey(KeyCode.LeftArrow)) shootDirection += Vector2.left;
        if (Input.GetKey(KeyCode.RightArrow)) shootDirection += Vector2.right;


        if (shootDirection != Vector2.zero && Time.time >= timeUntilFire)
        {
            Shoot(shootDirection.normalized);
            timeUntilFire = Time.time + fireRate;
        }
    }

    void Shoot(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Instantiate(bulletPrefab, firingPoint.position, Quaternion.Euler(0f, 0f, angle));
    }
}
