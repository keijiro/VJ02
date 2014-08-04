using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class StandardShaderConfiguration : MonoBehaviour
{
    void Awake()
    {
        Update();
    }

    void Update()
    {
        Shader.SetGlobalMatrix("_VJ02_EnvMapMatrix", transform.worldToLocalMatrix);
    }
}
