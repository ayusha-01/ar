using UnityEngine;

public class Practical3 : MonoBehaviour
{
    // Public variables to assign sprites in the Inspector
    public Sprite sadSprite;
    public Sprite happySprite;
    public Sprite neutralSprite;
    public Sprite angrySprite;

    // Reference to the SpriteRenderer component
    private SpriteRenderer spriteRenderer;

    // Initialize the SpriteRenderer
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Optionally set an initial sprite
        spriteRenderer.sprite = neutralSprite; // Default to Neutral
    }

    // Update method to detect mouse clicks or other inputs
    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // Left mouse button clicked
        {
            // Switch sprites based on the current sprite
            if (spriteRenderer.sprite == neutralSprite)
            {
                spriteRenderer.sprite = happySprite;
            }
            else if (spriteRenderer.sprite == happySprite)
            {
                spriteRenderer.sprite = sadSprite;
            }
            else if (spriteRenderer.sprite == sadSprite)
            {
                spriteRenderer.sprite = angrySprite;
            }
            else
            {
                spriteRenderer.sprite = neutralSprite; // Cycle back to neutral
            }
        }
    }
}