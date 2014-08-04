Shader "Custom/VJ02 Standard"
{
    Properties
    {
        _Color      ("Albedo",               Color) = (1, 1, 1, 1)
        _DiffEnvTex ("Diffuse Envmap",       Cube)  = "gray"{}
        _DiffRef    ("Diffuse Reflectance",  Float) = 1
        _SpecEnvTex ("Specular Envmap",      Cube)  = "gray"{}
        _SpecRef    ("Specular Reflectance", Float) = 1
        _LodLevel   ("Specular Roughness",   Float) = 1
        _Fresnel    ("Fresnel Coefficient",  Float) = 5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        
        CGPROGRAM

        #pragma surface surf VJ02 noforwardadd noambient
        #pragma glsl

        // Global property.
        float4x4 _VJ02_EnvMapMatrix;
        float _VJ02_Exposure;

        // Material properties.
        float4 _Color;
        samplerCUBE _DiffEnvTex;
        float _DiffRef;
        samplerCUBE _SpecEnvTex;
        float _SpecRef;
        float _LodLevel;
        float _Fresnel;

        float3 SampleRGBM(float4 c)
        {
            float e = c.a * 8 * _VJ02_Exposure;
            float e2 = e * e;
            float lin_e = dot(float2(0.7532, 0.2468), float2(e2, e2 * 2));
            return c.rgb * lin_e;
        }

        half4 LightingVJ02(SurfaceOutput s, half3 lightDir, half3 viewDir, half atten)
        {
            float3 n = normalize(s.Normal);
            float3 v = normalize(viewDir);

            float3x3 env_mtx = _VJ02_EnvMapMatrix;

            float3 diff = SampleRGBM(texCUBE(_DiffEnvTex, mul(env_mtx, s.Normal))) * _DiffRef;

            float4 r_dir = float4(mul(env_mtx, reflect(-v, n)), _LodLevel);
            float3 spec = SampleRGBM(texCUBElod(_SpecEnvTex, r_dir)) * _SpecRef;
            
            float fr = pow(1 - dot(v, n), _Fresnel);

            half4 c;
            c.rgb = s.Albedo * diff + spec * atten * fr;
            c.a = s.Alpha;

            return c;
        }

        struct Input
        {
            float dummy;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            o.Albedo = _Color.rgb;
            o.Alpha = _Color.a;
        }

        ENDCG
    } 
    FallBack "Diffuse"
}
