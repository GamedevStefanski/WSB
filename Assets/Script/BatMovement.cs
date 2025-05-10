using UnityEngine;

public class BatMovement : MonoBehaviour
{
    public float verticalAmplitude = 2f;
    public float verticalSpeed = 2f;
    public float horizontalAmplitude = 3f;
    public float horizontalSpeed = 1f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newX = startPosition.x + Mathf.Sin(Time.time * horizontalSpeed) * horizontalAmplitude;
        float newY = startPosition.y + Mathf.Sin(Time.time * verticalSpeed) * verticalAmplitude;
        transform.position = new Vector3(newX, newY, startPosition.z);
    }
}
 