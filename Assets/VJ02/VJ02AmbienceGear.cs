using UnityEngine;
using System.Collections;

public class VJ02AmbienceGear : MonoBehaviour
{
    public Reaktion.ReaktorLink reaktor;
    public Gradient gradient;

    void Start()
    {
        reaktor.Initialize(this);
    }

    void Update()
    {
        var c = gradient.Evaluate(reaktor.Output);
        Camera.main.backgroundColor = c;
        RenderSettings.fogColor = c;
    }
}
