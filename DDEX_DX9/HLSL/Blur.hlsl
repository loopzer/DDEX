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

/*

float4 Color;
Color = shaderTexture.Sample(SampleType, texCoord);

float4 sum = 0;
int weightSum = 0;
//the weights of the neighbouring pixels
int weights[15] = { 1, 2, 3, 4, 5, 6, 7, 8, 7, 6, 5, 4, 3, 2, 1 };
//we are taking 15 samples
for (int i = 0; i < 15; i++)
{
//7 to the left, self and 7 to the right
float2 cord = float2(texCoord.x + values.x * (i - 7), texCoord.y);

float2 cord2 = float2(texCoord.x, texCoord.y + values.y * (i - 7));
//the samples are weighed according to their relation to the current pixel
sum += shaderTexture.Sample(SampleType, cord) * weights[i];
sum += shaderTexture.Sample(SampleType, cord2) * weights[i];
//while going through the loop we are summing up the weights
weightSum += weights[i];
}
sum /= weightSum;

sum.a = (Color.r + Color.b + Color.g) == 0.0f ? 0 : color.a;
return sum * color;
*/