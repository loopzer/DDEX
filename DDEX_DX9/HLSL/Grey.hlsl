sampler2D implicitInputSampler : register(S0);
float4 values : register(c0);
float4 main(float2 uv : TEXCOORD) : COLOR
{
	float3 tmpA = float3(0.0, 0.0, 0.0);
	float4 color = tex2D(implicitInputSampler, uv);
	float4 greyscale = dot(color.rgb, float3(0.30, 0.59, 0.11));
	//float4 greyscale = dot(color.rgb, float3(values.r, values.g, values.b));
	/*
	greyscale.a += (color.r == 0.0) ? 0.0 : 1.0;
	greyscale.a += (color.g == 0.0) ? 0.0 : 1.0;
	greyscale.a += (color.b == 0.0) ? 0.0 : 1.0;
	*/
	greyscale.a = color.a;
	return (color * values.r) + (greyscale*values.g);
}