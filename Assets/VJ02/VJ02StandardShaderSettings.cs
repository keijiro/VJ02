using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class VJ02StandardShaderSettings : MonoBehaviour
{
    public Texture diffuseEnvMap;
    public Texture specularEnvMap;

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
        Shader.SetGlobalTexture("_VJ02_DiffEnvTex", diffuseEnvMap);
        Shader.SetGlobalTexture("_VJ02_SpecEnvTex", specularEnvMap);
    }
}
