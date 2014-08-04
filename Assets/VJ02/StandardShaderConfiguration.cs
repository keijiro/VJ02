using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class StandardShaderConfiguration : MonoBehaviour
{
    [SerializeField] float _exposure = 1;

    public float exposure {
        get { return _exposure; }
        set { _exposure = value; }
    }

    void Awake()
    {
        Update();
    }

    void Update()
    {
        Shader.SetGlobalFloat("_VJ02_Exposure", _exposure);
        Shader.SetGlobalMatrix("_VJ02_EnvMapMatrix", transform.worldToLocalMatrix);
    }
}
