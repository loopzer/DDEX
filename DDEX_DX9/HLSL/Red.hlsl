// (C) 2011 Jan-Willem Krans (janwillem32 <at> hotmail.com)
// This file is part of Video pixel shader pack.
// This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, version 2.
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
// You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.

// nightvision
// This shader can be run as a screen space pixel shader.
// This shader requires compiling with ps_2_0, but higher is better, see http://en.wikipedia.org/wiki/Pixel_shader to look up what PS version your video card supports.
// If possible, avoid compiling with the software emulation modes (ps_?_sw). Pixel shaders require a lot of processing power to run in real-time software mode.
// Use this shader to apply an effect that looks like the view from nightvision goggles to an image.

sampler s0;

float4 main(float2 tex : TEXCOORD0) : COLOR
{
	float4 color = float4(dot(tex2D(s0, tex), float4(.375, .5, .125, 0)), 0, 0, tex2D(s0, tex).a);

	return color;
}