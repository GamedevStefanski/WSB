using UnityEngine;

public class OscillatingMovementWithFlip : MonoBehaviour
{
    public float horizontalAmplitude = 2f;
    public float horizontalSpeed = 1f;
    public float verticalAmplitude = 1f;
    public float verticalSpeed = 1f;

    private Vector3 startPosition;
    private Vector3 previousPosition;

    private bool facingRight = true;

    void Start()
    {
        startPosition = transform.position;
        previousPosition = startPosition;
    }

    void Update()
    {
        float time = Time.time;

        float x = Mathf.Sin(time * horizontalSpeed) * horizontalAmplitude;
        float y = Mathf.Sin(time * verticalSpeed) * verticalAmplitude;

        Vector3 newPosition = startPosition + new Vector3(x, y, 0f);
        transform.position = newPosition;

        Vector3 direction = newPosition - previousPosition;

        // Flipuj sprite'a tylko, jeœli kierunek w poziomie siê zmieni³
        if (direction.x > 0.01f && !facingRight)
        {
            Flip(true);
        }
        else if (direction.x < -0.01f && facingRight)
        {
            Flip(false);
        }

        previousPosition = newPosition;
    }

    void Flip(bool faceRight)
    {
        facingRight = faceRight;
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * (facingRight ? -1 : 1);
        transform.localScale = scale;
    }
}
