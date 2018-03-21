Shader "DayRim/EdgeCutoutPaper"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_TexColor ("Texture Color", Color) = (1.0,1.0,1.0,1.0)
		//_Ramp ("Ramp", 2D) = "white" {}
		_SliceGuide ("Slice Guide (RGB)", 2D) = "white" {}
		_SliceAmount ("Slice Amount", Range(0.0, 1.0)) = 0.5

		//Normal Map
		_BumpMap ("Normal Texture", 2D) = "bump" {}
		_BumpDepth ("Bump Depth", Range(0.0,20.0)) = 1

		_SpecColor ("Specular Color", Color) = (1.0,1.0,1.0,1.0)
		_Shininess ("Shininess", float) = 10
		_RimColor ("Rim Color", Color) = (1.0,1.0,1.0,1.0)
		_RimPower ("Rim Power", Range(0.1,10.0)) = 3.0
	}
	SubShader
	{
		Tags{ "RenderType" = "Opaque" }
		//Blend SrcAlpha OneMinusSrcAlpha
		LOD 100

		Pass
		{
			Tags { "LightMode"="ForwardBase" }
			Cull Off
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			
			#include "UnityCG.cginc"

			uniform sampler2D _MainTex;
			uniform float4 _MainTex_ST;
			uniform fixed4 _TexColor;

			//uniform sampler2D _Ramp;
			uniform sampler2D _SliceGuide;
			uniform fixed _SliceAmount;

			uniform sampler2D _BumpMap;
			uniform half4 _BumpMap_ST;
			uniform half _BumpDepth;
			uniform half4 _SpecColor;
			uniform half4 _RimColor;
			uniform half _Shininess;
			uniform half _RimPower;

			//unity defined variables
			uniform half4 _LightColor0;


			struct VertexInput
			{
				half4 vertex : POSITION;
				half3 normal : NORMAL;
				half2 uv : TEXCOORD0;
				half2 alpha : TEXCOORD1;
				half4 tangent : TANGENT;

			};

			struct v2f
			{
				half2 uv : TEXCOORD0;
				half4 pos : SV_POSITION;
				half2 alpha : TEXCOORD1;
				half4 posWorld : TEXCOORD2;
				half3 normalWorld : TEXCOORD3;
				half3 tangentWorld : TEXCOORD4;
				half3 binormalWorld : TEXCOORD5;

			};

			v2f vert (VertexInput v)
			{
				v2f o;

				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				//o.uv = v.texcoord;
				o.normalWorld = normalize( mul( half4( v.normal, 0.0 ), unity_WorldToObject ).xyz );
				o.tangentWorld = normalize( mul( unity_ObjectToWorld, v.tangent ).xyz );
				o.binormalWorld = normalize( cross(o.normalWorld, o.tangentWorld) * v.tangent.w );
				

				o.posWorld = mul(unity_ObjectToWorld, v.vertex);
				o.pos = UnityObjectToClipPos(v.vertex);

				o.alpha = v.uv;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				//cutout texture
				clip(tex2D(_SliceGuide, i.uv).rgb - _SliceAmount);

				//normalize Direcitons
				half3 viewDirection = normalize( _WorldSpaceCameraPos.xyz - i.posWorld.xyz );
				half3 lightDirection;
				half atten;
				
				if(_WorldSpaceLightPos0.w == 0.0)
				{ 
					//directional light
					atten = 1.0;
					lightDirection = normalize(_WorldSpaceLightPos0.xyz);
				}

				else{
					half3 fragmentToLightSource = _WorldSpaceLightPos0.xyz - i.posWorld.xyz;
					half distance = length(fragmentToLightSource);
					atten = 1.0/distance;
					lightDirection = normalize(fragmentToLightSource);
				}

				//Texture Maps
				half4 tex = tex2D(_MainTex, i.uv.xy * _MainTex_ST.xy + _MainTex_ST.zw);
				half4 texN = tex2D(_BumpMap, i.uv.xy * _BumpMap_ST.xy + _BumpMap_ST.zw);

				//unpackNormal function
				half3 localCoords = half3(2.0 * texN.ag - half2(1.0, 1.0), 0.0);
				localCoords.z = (_BumpDepth/10);

				//normal transpose matrix
				half3x3 local2WorldTranspose = half3x3(
					i.tangentWorld,
					i.binormalWorld,
					i.normalWorld
				);

				//calculate normal direction
				half3 normalDirection = normalize( mul( localCoords, local2WorldTranspose ) );

				//Lighting
				half3 diffuseReflection = atten * _LightColor0.xyz * saturate(dot(normalDirection, lightDirection));
				half3 specularReflection = diffuseReflection * _SpecColor.xyz * pow(saturate(dot(reflect(-lightDirection, normalDirection), viewDirection)) , _Shininess);

				half3 lightFinal = UNITY_LIGHTMODEL_AMBIENT.xyz + diffuseReflection;
				
				half4 col = half4(tex.xyz * lightFinal * _TexColor.xyz, 1.0);

				return col;
			}
			ENDCG
		}
	}

	//Fallback "Diffuse"
}
