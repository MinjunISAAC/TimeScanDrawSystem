Shader "OutLine"
{
    Properties
    {
        _MainColor   ("Main Color", Color)              = (0,0,0,1)

        _MainTex     ("Albedo (RGB)",  2D)              = "white" {}
        _PaintTex    ("Main Texture",  2D)              = "white" {}
        _OutLineColor("OutLine Color", Color)           = (0,0,0,0)
        _OutLineWidth("OutLine Width", Range(0.000, 1)) = 0.1
    }
    SubShader
    {
        Tags
        {
            "RenderType" = "Transparent"
            "Queue"      = "Transparent"
        }

        // ---------- Pass 1 (Origin)

        cull   back
        zwrite on

        Stencil
        {
            Ref 1
            Pass Replace
        }

        CGPROGRAM
        #pragma surface surf Lambert Fullforwardshadows alpha:blend 
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _PaintTex;
        float4    _MainColor;

        struct Input
        {
            float2 uv_MainTex;
        };

        UNITY_INSTANCING_BUFFER_START(Props)

        UNITY_INSTANCING_BUFFER_END(Props)

        void surf(Input IN, inout SurfaceOutput o)
        {
            fixed4 mainTex = tex2D(_MainTex,  IN.uv_MainTex);
            fixed4 painted = tex2D(_PaintTex, IN.uv_MainTex);

            o.Emission = lerp(mainTex.rgb, painted.rgb, painted.a);
            o.Alpha    = painted.a * _MainColor.a;
        }
        ENDCG

        // ---------- Pass 2 (OutLine)

        cull   front
        zwrite off

        Stencil
        {
            Ref 1
            Comp NotEqual
        }

        CGPROGRAM
        #pragma surface surf NoLight vertex:vert noshadow noambient 
        #pragma target 3.0

        float4 _OutLineColor;
        float  _OutLineWidth;

        void vert(inout appdata_full v)
        {
            v.vertex.xyz += v.normal.xyz * _OutLineWidth;
        }

        struct Input
        {
            float4 color;
        };


        void surf (Input IN, inout SurfaceOutput o)
        {

        }

        float4 LightingNoLight(SurfaceOutput s, float3 lightDir, float atten)
        {
            return float4(_OutLineColor.rgb, _OutLineColor.a);
        }
        ENDCG

    }
    FallBack "Diffuse"
}