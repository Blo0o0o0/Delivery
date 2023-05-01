Shader "Custom/Vignette" {
    Properties{
        _MainTex("Texture", 2D) = "white" {}
        _VignetteColor("Vignette Color", Color) = (0,0,0,1)
        _VignetteRadius("Vignette Radius", Range(0,1)) = 0.5
    }

        SubShader{
            Pass {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                struct appdata {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                };

                sampler2D _MainTex;
                float4 _MainTex_ST;
                float4 _VignetteColor;
                float _VignetteRadius;

                v2f vert(appdata v) {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = (v.uv - 0.5) * _MainTex_ST.zw + 0.5;
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target {
                    float4 vignette = 1 - smoothstep(0, _VignetteRadius, length(i.uv - 0.5));
                    return lerp(_VignetteColor, tex2D(_MainTex, i.uv), vignette);
                }
                ENDCG
            }
        }
            FallBack "Diffuse"
}
