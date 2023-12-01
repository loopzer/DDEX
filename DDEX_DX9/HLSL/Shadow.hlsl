sampler2D implicitInputSampler : register(S0);
float4 main(float2 uv : TEXCOORD) : COLOR
{
	float3 tmpA = float3(0.0, 0.0, 0.0);
	float4 tcolor = tex2D(implicitInputSampler, uv);
	float4 color = tcolor;

	float cc = color.r + color.g + color.b;
	color.rgb = 0.0;
	if (cc == 0.0)
		color.a = 0;
	else
		color.a = 0.16;

	return color;
}