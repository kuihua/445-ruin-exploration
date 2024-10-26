Shader "Custom/Leaf"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="TransparentCutout" }
        Cull Off
        CGPROGRAM
        #pragma surface surf Lambert addshadow
        #pragma target 3.0
        
        sampler2D _MainTex;
        fixed4 _Color;

        struct Input
        {
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            o.Alpha = c.a;
            clip(o.Alpha - 0.5);
        }
        ENDCG
    }
    Fallback "Diffuse"
}
