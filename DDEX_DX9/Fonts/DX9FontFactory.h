#pragma once
#include <Windows.h>
#include <Fonts\IFontFactory.h>
#include <Fonts\IFont.h>

#include <cstdlib>
#include <stdlib.h>
#include <exception>
#include <Render\RenderDeclares.h>
#include <time.h>
#include <d3d9.h>
#include <d3dx9.h>
#include <DxErr.h>
#pragma comment(lib, "dxerr.lib")
#include <math.h>
#include "DX9Font.h"

using namespace DDEX;

class DX9FontFactory : public IFontFactory
{

public:

	DX9FontFactory(LPDIRECT3DDEVICE9 dev, LPD3DXSPRITE sprite) {
		this->dev = dev;
		this->sprite = sprite;
	}

	DDEX::IFont * Make(char * fontName, int size, bool bold, bool italic) {

		HRESULT hr;
		HDC hDC;
		int nHeight;
		LPD3DXFONT font = NULL;

		__int32 boldValue=0;
		hDC = GetDC(NULL);

		// :S
		nHeight = -(MulDiv(size, GetDeviceCaps(hDC, LOGPIXELSY), 72));

		ReleaseDC(NULL, hDC);
		if (bold){
			boldValue = FW_BOLD;
		}

		hr = D3DXCreateFontA(this->dev, nHeight, 0, boldValue, 1, italic,
			DEFAULT_CHARSET, OUT_DEFAULT_PRECIS, ANTIALIASED_QUALITY,
			DEFAULT_PITCH | FF_DONTCARE, fontName,
			&font);

		if (FAILED(hr)) {
			return NULL;
		}

		return new DX9Font(this->dev, this->sprite, font, size);
	}

protected:
	LPDIRECT3DDEVICE9 dev;
	LPD3DXSPRITE sprite;
};

