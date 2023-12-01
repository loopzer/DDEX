sampler s0;
sampler s1;

float4 main(float2 coords: TEXCOORD0) : COLOR0
{
	float4 color = tex2D(s0, coords);
	float4 lightColor = tex2D(s1, coords);
	return color * (lightColor*1.5);
}