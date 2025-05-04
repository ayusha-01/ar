using UnityEngine;

public class Player2DMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right
        float moveY = Input.GetAxisRaw("Vertical");   // W/S or Up/Down

        Vector2 move = new Vector2(moveX, moveY).normalized;
        transform.Translate(move * moveSpeed * Time.deltaTime);
    }
}
