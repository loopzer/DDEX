float4 values : register(c0);
sampler s0;
float4 main(float2 coords: TEXCOORD0) : COLOR0
{
	float4 Color = tex2D(s0, coords.xy);

	Color.r = Color.r * values.r;
	Color.g = Color.g * values.g;
	Color.b = Color.b * values.b;

	return Color;
}