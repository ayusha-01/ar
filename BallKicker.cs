using UnityEngine;

public class BallKicker : MonoBehaviour
{
    public Rigidbody ball;
    public float lowSpeed = 5f;
    public float mediumSpeed = 10f;
    public float highSpeed = 15f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeSpeed(lowSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeSpeed(mediumSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeSpeed(highSpeed);
        }
    }

    void ChangeSpeed(float newSpeed)
    {
        if (ball.linearVelocity.magnitude > 0.1f)
        {
            Vector3 currentDirection = ball.linearVelocity.normalized;
            ball.linearVelocity = currentDirection * newSpeed;
        }
        else
        {
            // If ball is stationary, kick it forward (optional)
            ball.linearVelocity = Vector3.back * newSpeed;
        }
    }
}
