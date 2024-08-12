Shader "Unlit/Uvwmap"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _WarpScaleX ("Warp Scale X", Float) = 1.0
        _WarpScaleY ("Warp Scale Y", Float) = 1.0
        _WarpFrequencyX ("Warp Frequency X", Float) = 1.0
        _WarpFrequencyY ("Warp Frequency Y", Float) = 1.0
        _WarpAmplitude ("Warp Amplitude", Float) = 1.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "RenderPipeline"="UniversalPipeline" }
        LOD 100

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/CommonMaterial.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/SurfaceInput.hlsl"
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/ParallaxMapping.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DBuffer.hlsl"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            CBUFFER_START(PerMaterial)
            float4 _MainTex_ST;
            float _WarpScaleX;
            float _WarpScaleY;
            float _WarpFrequencyX;
            float _WarpFrequencyY;
            float _WarpAmplitude;
            CBUFFER_END
            TEXTURE2D(_MainTex);        SAMPLER(sampler_MainTex);
            

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = TransformObjectToHClip(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.uv.x += sin(o.uv.x * _WarpFrequencyX + _Time.y * _WarpScaleX) * _WarpAmplitude;
                o.uv.y += cos(o.uv.y * _WarpFrequencyY + _Time.y * _WarpScaleY) * _WarpAmplitude;
                return o;
            }

            float4 frag (v2f i) : SV_Target
            {
        
                float4 col = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.uv);
         
                return col;
            }
            ENDHLSL
        }
    }
}
