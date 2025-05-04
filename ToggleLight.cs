using UnityEngine;

public class ToggleLight : MonoBehaviour
{
    public Light sunLight;
    public Material daySkyBox;
    public Material nightSkyBox;

    private bool isNight = false;

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            ToggleDayNight();
        }
    }

    void ToggleDayNight() {
        isNight = !isNight;

        if (isNight)
        {

            RenderSettings.skybox = nightSkyBox;
            sunLight.intensity = 0.1f;
            sunLight.color = new Color(0.2f, 0.2f, 0.35f);
            RenderSettings.ambientLight = Color.black;
        }

        else {
            RenderSettings.skybox = daySkyBox;
            sunLight.intensity = 1;
            sunLight.color = Color.white;
            RenderSettings.ambientLight = Color.grey;
        }

        DynamicGI.UpdateEnvironment();
    }
}
