Shader "Bubble" 
{
	Properties 
	{
		_ColorMain ("Main Color", Color) = (1.0, 1.0, 1.0, 1.0)
		_ColorRim ("Rim Color", Color) = (1.0, 1.0, 1.0, 1.0)
		_ColorRimIntensity("Rim Intensity", Range(1.0, 10.0)) = 3.0
		_NormalManipulation ("NormalManipulation", Range(0.0, 1.0)) = 0.0
	}
    SubShader 
	{
		Tags { "RenderType" = "Transparent"}
 
		CGPROGRAM 
		#pragma surface surf Lambert
 
		float4 _ColorMain;
		float4 _ColorRim;
		float _ColorRimIntensity;
		float _NormalManipulation;

		struct Input 
		{
		  float4 color : Color;
		  float3 viewDir;
		};
 
		void surf (Input IN, inout SurfaceOutput o) 
		{
			IN.color = _ColorMain;

			o.Albedo = IN.color;
			half rim = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal * _NormalManipulation));
			o.Emission = _ColorRim.rgb * pow(rim, _ColorRimIntensity);
		}
		ENDCG
	 } 
}