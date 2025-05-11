using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeBoss : MonoBehaviour
    
{
    public float shootingRange;
    public GameObject bullet;
    public GameObject bulletParent;
    public float fireRate = 1f;
    private float nextFireTime = 0f;

    [SerializeField]
    float moveSpeed = 5f;

    [SerializeField]
    float frequency = 20f;

    [SerializeField]
    float magnitude = 0.5f;

    bool facingRight = true;

    Vector3 pos, localScale;


    void Start()
    {

        pos = transform.position;

        localScale = transform.localScale;

    }


    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
        if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }

            CheckWhereToFace();

        if (facingRight)
            MoveRight();
        else
            MoveLeft();
    }

    void CheckWhereToFace()
    {
        if (pos.x < -7f)
            facingRight = true;

        else if (pos.x > 7f)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;

    }

    void MoveRight()
    {
        pos += transform.right * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
    }

    void MoveLeft()
    {
        pos -= transform.right * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}