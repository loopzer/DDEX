sampler2D implicitInputSampler : register(S0);
float4 main(float2 uv : TEXCOORD) : COLOR
{	
	float3 tmpA = float3(0.0, 0.0, 0.0);
	float4 color = tex2D(implicitInputSampler, uv);
	float4 invertedColor = float4(color.a - color.rgb, color.a);

	invertedColor.a = color.a;
	
	return invertedColor;
}