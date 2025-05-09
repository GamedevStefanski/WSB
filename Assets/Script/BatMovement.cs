using UnityEngine;

public class DualAxisMovement : MonoBehaviour
{
    public float verticalAmplitude = 2f;      // Zakres ruchu g�ra-d�
    public float verticalSpeed = 2f;          // Pr�dko�� g�ra-d�
    public float horizontalAmplitude = 3f;    // Zakres ruchu lewo-prawo
    public float horizontalSpeed = 1f;        // Pr�dko�� lewo-prawo

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
