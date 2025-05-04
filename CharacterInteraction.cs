using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    public float jumpForce = 5f;
    public float rotationAmount = 90f; // Degrees per arrow key press
    public float rotationCooldown = 0.2f;

    private Rigidbody rb;
    private bool canRotate = true;
    private float rotationTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogWarning("No Rigidbody found. Adding one.");
            rb = gameObject.AddComponent<Rigidbody>();
        }
    }

    void Update()
    {
        HandleJump();
        HandleRotationCooldown();
        HandleArrowKeyRotation();
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void HandleArrowKeyRotation()
    {
        if (!canRotate) return;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, rotationAmount);
            TriggerRotationCooldown();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, -rotationAmount);
            TriggerRotationCooldown();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(Vector3.right, -rotationAmount);
            TriggerRotationCooldown();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Rotate(Vector3.right, rotationAmount);
            TriggerRotationCooldown();
        }
    }

    void TriggerRotationCooldown()
    {
        canRotate = false;
        rotationTimer = 0f;
    }

    void HandleRotationCooldown()
    {
        if (!canRotate)
        {
            rotationTimer += Time.deltaTime;
            if (rotationTimer >= rotationCooldown)
            {
                canRotate = true;
            }
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, 1.2f);
    }
}
