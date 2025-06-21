using UnityEngine;

public class BeeShooter : MonoBehaviour
{
    public float shootingRange;
    public GameObject bullet;
    public GameObject bulletParent;
    public float fireRate = 1f;
    private float nextFireTime = 0f;
    void Update()
    {
        if (nextFireTime < Time.time)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }
            
    }
}
