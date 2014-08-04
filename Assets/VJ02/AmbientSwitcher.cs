using UnityEngine;
using System.Collections;

public class AmbientSwitcher : MonoBehaviour
{
    public Reaktion.Reaktor reaktor;
    public Gradient gradient;

    void Update()
    {
        var c = gradient.Evaluate(reaktor.Output);
        Camera.main.backgroundColor = c;
        RenderSettings.fogColor = c;
    }
}
