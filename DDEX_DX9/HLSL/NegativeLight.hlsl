sampler s0;
float4 values : register(c0);

float4 main(float2 coords: TEXCOORD0) : COLOR0
{
	float4 Color = tex2D(s0, coords);

	float4 masterColor = float4(values.r, values.g, values.b, 1.0f);

	masterColor.a = (Color.r + Color.b + Color.g) == 0.0f ? 0 : masterColor.a;
	masterColor.r = (Color.r + Color.b + Color.g) == 0.0f ? 0 : masterColor.r;
	masterColor.g = (Color.r + Color.b + Color.g) == 0.0f ? 0 : masterColor.g;
	masterColor.b = (Color.r + Color.b + Color.g) == 0.0f ? 0 : masterColor.b;

	return masterColor;
}