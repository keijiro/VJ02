using UnityEngine;
using System.Collections;

public class AmbientSwitcher : MonoBehaviour
{
    public Color lightColor;
    public Color darkColor;

    bool flipFlop;

    public void Start()
    {
        SetLight();
    }

    public void Toggle()
    {
        flipFlop = !flipFlop;
        Camera.main.backgroundColor = flipFlop ? darkColor : lightColor;
        RenderSettings.fogColor = flipFlop ? darkColor : lightColor;
    }

    public void SetLight()
    {
        flipFlop = false;
        Camera.main.backgroundColor = lightColor;
        RenderSettings.fogColor = lightColor;
    }
}
