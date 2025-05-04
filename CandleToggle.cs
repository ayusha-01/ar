using UnityEngine;

public class CandleToggle : MonoBehaviour
{
    public GameObject fireParticles;
    public GameObject smokeParticles;
    public Light candleLight;

    private bool isLit = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // Left click
        {
            isLit = !isLit;

            fireParticles.SetActive(isLit);
            smokeParticles.SetActive(isLit);
            candleLight.enabled = isLit;
        }
    }
}
