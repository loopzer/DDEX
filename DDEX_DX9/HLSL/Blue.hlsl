sampler s0;

float4 main(float2 tex : TEXCOORD0) : COLOR
{
	float4 color = float4(0.0, 0, dot(tex2D(s0, tex), float4(.375, .5, .125, 0)), tex2D(s0, tex).a);
	//color.a = (color.b == 0.0) ? 0.0 : 1.0;

	return color;
}