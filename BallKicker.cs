using UnityEngine;

public class BallKicker : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // Low Speed
        {
            KickBall(5f); // Small force
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) // Medium Speed
        {
            KickBall(10f); // Moderate force
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) // High Speed
        {
            KickBall(20f); // Strong force
        }
    }

    void KickBall(float force)
    {
        rb.linearVelocity = Vector3.zero; // Reset current motion
        rb.AddForce(Vector3.forward * force, ForceMode.Impulse);
    }
}
