//
// VJ02 standard shader
//

Shader "Custom/VJ02 Standard"
{
    Properties
    {
        _Color    ("Albedo",               Color)  = (1, 1, 1, 1)
        _DiffRef  ("Diffuse Reflectance",  Float)  = 1
        _SpecRef  ("Specular Reflectance", Float)  = 1
        _LodLevel ("Specular Roughness",   Float)  = 1
        _Fresnel  ("Fresnel Coefficient",  Float)  = 5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        
        CGPROGRAM

        #pragma surface surf VJ02 noforwardadd noambient
        #pragma target 3.0
        #pragma glsl

        // Global property.
        samplerCUBE _VJ02_DiffEnvTex;
        samplerCUBE _VJ02_SpecEnvTex;
        float4x4 _VJ02_EnvMapMatrix;
        float _VJ02_Exposure;

        // Diffuse lighting parameters.
        float4 _Color;
        float _DiffRef;

        // Specular lighting parameters.
        float _SpecRef;
        float _LodLevel;
        float _Fresnel;

        // Sampling function for RGBM encoded texels.
        float3 SampleRGBM(float4 c)
        {
            float e = c.a * 8 * _VJ02_Exposure;
            float e2 = e * e;
            float lin_e = dot(float2(0.7532, 0.2468), float2(e2, e2 * 2));
            return c.rgb * lin_e;
        }

        // Lighting model function.
        half4 LightingVJ02(SurfaceOutput s, half3 lightDir, half3 viewDir, half atten)
        {
            // Variables.
            float3 v_n = normalize(s.Normal);
            float3x3 m_env = (float3x3)_VJ02_EnvMapMatrix;

            // Diffuse lighting.
            float3 diff = SampleRGBM(texCUBE(_VJ02_DiffEnvTex, mul(m_env, v_n))) * _DiffRef;

            // Specular lighting.
            float4 v_r = float4(mul(m_env, reflect(-viewDir, v_n)), _LodLevel);
            float3 spec = SampleRGBM(texCUBElod(_VJ02_SpecEnvTex, v_r)) * _SpecRef;

            // Fresnel factor.
            float fr = pow(1 - dot(viewDir, v_n), _Fresnel);

            return half4(_Color.rgb * diff + spec * atten * fr, _Color.a);
        }

        // Nothing to do with the surface function.
        struct Input { float2 uv_MainTex; };
        void surf(Input IN, inout SurfaceOutput o) { }

        ENDCG
    } 
    FallBack "Diffuse"
}
