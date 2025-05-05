using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    public float initialBounceForce = 8f;
    public float bounceDamping = 0.95f;
    public float bounceDuration = 5f; // Duration after which bouncing stops

    private Rigidbody rb;
    private float timer = 0f;
    private bool canBounce = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (canBounce)
        {
            timer += Time.deltaTime;
            if (timer >= bounceDuration)
            {
                canBounce = false;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!canBounce) return;

        // Bounce only if hitting the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Only bounce if going downward
            if (rb.linearVelocity.y <= 0)
            {
                float bounceForce = initialBounceForce * Mathf.Pow(bounceDamping, timer);
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, bounceForce, rb.linearVelocity.z);
            }
        }
    }
}