#pragma once
#include <Windows.h>
#include <Render\RenderDeclares.h>
#include <Fonts\IFont.h>

#include <d3d9.h>
#include <d3dx9.h>
#include <DxErr.h>
#include <math.h>
#pragma comment(lib, "dxerr.lib")

using namespace DDEX;
class DX9Font :public DDEX::IFont
{

public:

	DX9Font(LPDIRECT3DDEVICE9 dev, LPD3DXSPRITE sprite, LPD3DXFONT font, int size) {
		this->dev = dev;
		this->sprite = sprite;
		this->font = font;
		this->size = size;
	}

	void Draw(char *text, int x, int y, Render::RenderColor * color) {
		RECT d;
		SetRect(&d, x, y, 0, 0);

		this->font->DrawTextA(this->sprite, text, -1, &d, DT_NOCLIP, D3DCOLOR_ARGB(color->a, color->r, color->g, color->b));
	}

	HDC GetHDC() {
		return this->font->GetDC();
	}

	~DX9Font() {
		this->font->Release();
	}

protected:
	LPDIRECT3DDEVICE9 dev;
	LPD3DXFONT  font;
	LPD3DXSPRITE  sprite;
	int size;

};