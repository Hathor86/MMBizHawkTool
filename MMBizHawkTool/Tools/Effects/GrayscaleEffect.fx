/*
MMBizHawkTool, a BizHawk plugin specific to The Legend of Zelda: Majora's Mask
Copyright (C) 2015  François Guiot

This program is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 2 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License along
with this program; if not, write to the Free Software Foundation, Inc.,
51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
*/
sampler2D implicitInput : register(s0);
float factor : register(c0);

float4 main(float2 uv : TEXCOORD) : COLOR
{
	float4 color = tex2D(implicitInput, uv);
	float gray = color.r * 0.3 + color.g * 0.59 + color.b *0.11;

	float4 result;
	result.r = (color.r - gray) * factor + gray;
	result.g = (color.g - gray) * factor + gray;
	result.b = (color.b - gray) * factor + gray;
	result.a = color.a;

	return result;
}