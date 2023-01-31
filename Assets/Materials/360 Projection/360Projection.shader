Shader "Unlit/360Projection"
{
    Properties
    {
        _MainTex ("Texture", Cube) = "" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            Cull Front
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float3 texDir : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            uniform samplerCUBE _MainTex;
            uniform float4x4 _panoramaOrigin;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                float3 worldPos = mul(unity_ObjectToWorld, v.vertex);
                float3 panoPos = mul(_panoramaOrigin, float4(worldPos, 1)).xyz;
                o.texDir = normalize(panoPos);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return texCUBE(_MainTex, i.texDir);
            }
            ENDCG
        }
    }
}