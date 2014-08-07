using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EdgeDetectEffectNormals))]
public class EdgeDetectEffectGear : MonoBehaviour
{
    public Reaktion.ReaktorLink reaktor;

    EdgeDetectEffectNormals edge;
    DepthOfFieldScatter dof;

    void Awake()
    {
        edge = GetComponent<EdgeDetectEffectNormals>();
        dof = GetComponent<DepthOfFieldScatter>();
    }

    void Update()
    {
        if (reaktor.Output > 0.1f)
        {
            edge.enabled = true;
            edge.edgesOnly = reaktor.Output;
            if (dof) dof.enabled = false;
        }
        else
        {
            edge.enabled = false;
            if (dof) dof.enabled = true;
        }
    }
}
