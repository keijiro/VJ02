using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class VJ02Composite : MonoBehaviour
{
    public Shader shader;
    public Texture2D overlay;

    Material material;

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (material == null)
        {
            material = new Material(shader);
            material.hideFlags = HideFlags.DontSave;
        }
        material.SetTexture("_OverlayTex", overlay);
        Graphics.Blit(source, destination, material);
    }
}
