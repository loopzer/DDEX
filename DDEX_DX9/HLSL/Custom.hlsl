
sampler s0;

float4 main(float2 coords: TEXCOORD0) : COLOR0
{
float4 color = tex2D(s0, coords);
return color;
}