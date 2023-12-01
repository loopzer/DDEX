#pragma once
#include <Windows.h>

#include "..\DX9\Dx9Def.h"
#include <d3d9.h>
#include <d3dx9.h>
#include <DxErr.h>
#pragma comment(lib, "dxerr.lib")

#include <Render\RenderDeclares.h>
#include <Render\IRenderPrimitive.h>

using namespace DDEX;
class DX9RenderPrimitive : public Render::IRenderPrimitive
{

public:

	DX9RenderPrimitive(LPDIRECT3DDEVICE9 dev, LPD3DXSPRITE sprite) {
		this->sprite = sprite;
		this->dev = dev;

		this->static_vertex[0].Rhw = 1.0f;
		this->static_vertex[1].Rhw = 1.0f;
		this->static_vertex[2].Rhw = 1.0f;
		this->static_vertex[3].Rhw = 1.0f;
		this->static_vertex[4].Rhw = 1.0f;
		this->static_vertex[0].z = 0.0f;
		this->static_vertex[1].z = 0.0f;
		this->static_vertex[2].z = 0.0f;
		this->static_vertex[3].z = 0.0f;
		this->static_vertex[4].z = 0.0f;
	}

	void DrawFillBox(RECT * rect, Render::RenderColor * color) {
		D3DCOLOR dxColor = *((D3DCOLOR *)color);

		static_vertex[0].c = dxColor;
		static_vertex[1].c = dxColor;
		static_vertex[2].c = dxColor;
		static_vertex[3].c = dxColor;

		static_vertex[0].x = (float)rect->left;
		static_vertex[0].y = (float)rect->top;

		static_vertex[1].x = (float)rect->right;
		static_vertex[1].y = (float)rect->top;

		static_vertex[2].x = (float)rect->right;
		static_vertex[2].y = (float)rect->bottom;

		static_vertex[3].x = (float)rect->left;
		static_vertex[3].y = (float)rect->bottom;

		this->sprite->End();

		this->dev->SetFVF(D3DFVF_XYZRHW | D3DFVF_DIFFUSE);

		this->dev->DrawPrimitiveUP(D3DPRIMITIVETYPE::D3DPT_TRIANGLESTRIP, 2, &this->static_vertex[0], sizeof(struct LVertice));

		this->dev->SetFVF(LVerticeTex::FVF_Flags);
		this->sprite->Begin(D3DXSPRITE_ALPHABLEND);
	}

	void DrawLine(RECT * rect, Render::RenderColor * color) {
		D3DCOLOR dxColor = *((D3DCOLOR *)color);

		static_vertex[0].c = dxColor;
		static_vertex[1].c = dxColor;

		static_vertex[0].x = (float)rect->left;
		static_vertex[0].y = (float)rect->top;

		static_vertex[1].x = (float)rect->right;
		static_vertex[1].y = (float)rect->bottom;

		this->sprite->End();

		this->dev->SetFVF(D3DFVF_XYZRHW | D3DFVF_DIFFUSE);

		this->dev->DrawPrimitiveUP(D3DPRIMITIVETYPE::D3DPT_LINESTRIP, 1, &this->static_vertex[0], sizeof(struct LVertice));

		this->dev->SetFVF(LVerticeTex::FVF_Flags);
		this->sprite->Begin(D3DXSPRITE_ALPHABLEND);
	}
	void DrawBox(RECT * rect, Render::RenderColor * color) {
		D3DCOLOR dxColor = *((D3DCOLOR *)color);

		static_vertex[0].c = dxColor;
		static_vertex[1].c = dxColor;
		static_vertex[2].c = dxColor;
		static_vertex[3].c = dxColor;
		static_vertex[4].c = dxColor;

		static_vertex[0].x = (float)rect->left;
		static_vertex[0].y = (float)rect->top;

		static_vertex[1].x = (float)rect->right;
		static_vertex[1].y = (float)rect->top;

		static_vertex[2].x = (float)rect->right;
		static_vertex[2].y = (float)rect->bottom;

		static_vertex[3].x = (float)rect->left;
		static_vertex[3].y = (float)rect->bottom;

		static_vertex[4].x = (float)rect->left;
		static_vertex[4].y = (float)rect->top;

		this->sprite->End();

		this->dev->SetFVF(D3DFVF_XYZRHW | D3DFVF_DIFFUSE);

		this->dev->DrawPrimitiveUP(D3DPRIMITIVETYPE::D3DPT_LINESTRIP, 4, &this->static_vertex[0], sizeof(struct LVertice));

		this->dev->SetFVF(LVerticeTex::FVF_Flags);
		this->sprite->Begin(D3DXSPRITE_ALPHABLEND);
	}

	~DX9RenderPrimitive() {

	}
protected:
	LPD3DXSPRITE sprite;
	LPDIRECT3DDEVICE9 dev;
	LVertice static_vertex[5];

};

