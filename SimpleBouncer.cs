using UnityEngine;

public class SimpleBouncer : MonoBehaviour
{
    public float duration = 2f; // Set from Inspector

    private float timer;
    private bool bouncing;
    private PhysicsMaterial mat;

    void Start()
    {
        mat = GetComponent<Collider>().material;
        mat.bounciness = 1f; // Start bouncing
        timer = 0f;
        bouncing = true;
    }

    void Update()
    {
        if (bouncing)
        {
            timer += Time.deltaTime;
            mat.bounciness = Mathf.Lerp(1f, 0f, timer / duration);
            if (timer >= duration)
            {
                bouncing = false;
            }
        }
    }
}
