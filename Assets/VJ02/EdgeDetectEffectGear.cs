using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EdgeDetectEffectNormals))]
public class EdgeDetectEffectGear : MonoBehaviour
{
    public Reaktion.ReaktorLink reaktor;

    EdgeDetectEffectNormals edge;

    void Awake()
    {
        edge = GetComponent<EdgeDetectEffectNormals>();
    }

    void Update()
    {
        if (reaktor.Output > 0.1f)
        {
            edge.enabled = true;
            edge.edgesOnly = reaktor.Output;
        }
        else
        {
            edge.enabled = false;
        }
    }
}
