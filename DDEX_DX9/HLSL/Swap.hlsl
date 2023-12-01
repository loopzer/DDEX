
sampler s0;
float4 main(float2 coords: TEXCOORD0) : COLOR0
{
	float4 color = tex2D(s0, coords.xy);
	
	//color.a = (color.r + color.g + color.b ) ==0.0f ? 0.0 : 1.0;
	return color;
}