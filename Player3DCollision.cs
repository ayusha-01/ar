using UnityEngine;

public class Player3DCollision : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    private Rigidbody rb;
    private bool isGrounded;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (rb == null) return;

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, 0, moveZ) * moveSpeed;
        Vector3 velocity = new Vector3(move.x, rb.linearVelocity.y, move.z);
        rb.linearVelocity = velocity;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
            isGrounded = true;

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Play collision sound
            if (audioSource != null)
                audioSource.Play();

            // Hide the player (disable mesh and physics)
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            rb.linearVelocity = Vector3.zero;
            rb.isKinematic = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
