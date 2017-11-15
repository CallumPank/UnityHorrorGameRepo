// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/SoundRipple" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Metallic("Metallic", Range(0,1)) = 0.0
		_TimeAmount("Scale Time", Range(1, 5)) = 1.0
		_StartAnimation("Start Animation", Int) = 0
		_Timer("Timer", Float) = 0

	}
		SubShader{

				ZWrite Off

			Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
			LOD 200

			CGPROGRAM
			#include "UnityCG.cginc"
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf NoLighting alpha:fade vertex:vert

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		half _TimeAmount;
		int _StartAnimation;
		float3 _BaseScale;
		float _Timer;

		void vert(inout appdata_full v) {
			if (_StartAnimation == 1) {
				
				v.vertex.xz += v.normal.xz * _Timer * 5;
			}
		}

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		half _Metallic;
		fixed4 _Color;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_CBUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_CBUFFER_END

		fixed4 LightingNoLighting(SurfaceOutput s, fixed3 lightDir, fixed atten) {
			fixed4 c;
			c.rgb = s.Albedo;
			c.a = s.Alpha;
			return c;
		}

		void surf(Input IN, inout SurfaceOutput o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = _Color;
			o.Albedo = c.rgb;
			c.a -= _Timer / 2;
			o.Alpha = c.a;
		}
		ENDCG
	}
		FallBack "Diffuse"
}
