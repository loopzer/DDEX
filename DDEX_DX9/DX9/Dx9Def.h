#pragma once

#ifndef _DX9DEF_H
#define _DX9DEF_H

#include <d3d9.h>
#include <d3dx9.h>

#include <string.h>
#include <stdio.h>

//lo tipos de inicio
#define DX9_HARD 0
#define DX9_REF 1
#define DX9_SOFT 2

#define DX9_HV 0
#define DX9_SV 1


#define DX9_MEM_D 0 //por default
#define DX9_MEM_A 1 //administrada
#define DX9_MEM_S 2 //memoria de sistema

struct PointVertex
{
    D3DXVECTOR3 posit;
    D3DCOLOR    color;

	enum FVF
	{
		FVF_Flags = D3DFVF_XYZ | D3DFVF_DIFFUSE
	};
};
struct LVertice{
	FLOAT    x, y, z,Rhw;
	D3DCOLOR c;
};
struct LVerticeTex{
	FLOAT    x, y, z,Rhw;
	D3DCOLOR c;
	FLOAT    tx, ty;
	enum FVF
	{
		FVF_Flags = D3DFVF_XYZRHW | D3DFVF_DIFFUSE | D3DFVF_TEX1
	};
};

#endif