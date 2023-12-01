float4 values : register(c0);

sampler input;
float4 main(float2 uv: TEXCOORD0) : COLOR0
{
	float4 Color;
	float pv = (1 - uv.y / 1.0f) / 10;

	float2 p = uv;
		p.x = p.x + sin(p.y*(((values.g) * 80.) - 80.) + (values.r)*1.)*pv;
	Color = tex2D(input, p);

	return Color * (1.0f + ((pv)* (values.b*10.0f)));
}
