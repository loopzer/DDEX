sampler input;
float4 main(float2 uv: TEXCOORD0) : COLOR0
{
	float4 Color;
	Color = tex2D(input, uv);

	Color -= tex2D(input, uv.xy - 0.003)*2.7f;
	Color += tex2D(input, uv.xy + 0.003)*2.7f;
	Color.rgb = (Color.r + Color.g + Color.b) / 3.0f;
	return Color;
}
