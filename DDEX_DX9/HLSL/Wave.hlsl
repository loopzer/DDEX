float4 values : register(c0);

sampler input;
float4 main(float2 uv: TEXCOORD0) : COLOR0
{
	float4 Color;
	float pv = 0.1f;

float2 p = uv;
p.x = p.x + sin(p.y*(((values.g) * 80.) - 80.) + (values.r)*6.)*pv;
Color = tex2D(input, p);

return Color;
}
