using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EdgeDetectEffectNormals))]
public class EdgeDetectEffectGear : MonoBehaviour
{
    public Reaktion.Reaktor reaktor;

    EdgeDetectEffectNormals fx;

    void Awake()
    {
        fx = GetComponent<EdgeDetectEffectNormals>();
    }

    void Update()
    {
        if (reaktor.Output > 0.1f)
        {
            fx.enabled = true;
            fx.edgesOnly = reaktor.Output;
        }
        else
        {
            fx.enabled = false;
        }
    }
}
