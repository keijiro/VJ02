Shader "Hidden/VJ02 Composite"
{
    Properties
    {
        _MainTex    ("Base",     2D) = "white" {}
        _ThruKeyTex ("Thru Key", 2D) = "black" {}
        _OverlayTex ("Overlay",  2D) = "black" {}
    }

    CGINCLUDE

    #include "UnityCG.cginc"

    sampler2D _MainTex;
    sampler2D _ThruKeyTex;
    sampler2D _OverlayTex;
    
    half4 frag(v2f_img i) : COLOR
    {
        half4 source  = tex2D(_MainTex, i.uv);
        half4 key     = tex2D(_ThruKeyTex, i.uv);
        half4 overlay = tex2D(_OverlayTex, i.uv);
        return lerp(source, overlay, (1 - key.a) * overlay.a);
    }

    ENDCG

    SubShader
    {
        ZTest Always Cull Off ZWrite Off
        Fog { Mode off }  
        Pass
        {
            CGPROGRAM
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma vertex vert_img
            #pragma fragment frag
            ENDCG
        }
    } 
    FallBack off
}
