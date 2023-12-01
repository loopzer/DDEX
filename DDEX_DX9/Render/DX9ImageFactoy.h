#pragma once

#include "..\DX9\Dx9Def.h"
#include <d3d9.h>
#include <d3dx9.h>
#include <DxErr.h>
#pragma comment(lib, "dxerr.lib")

#include <string.h>
#include <stdio.h>
#include <Render\IImageFactory.h>
#include <Render\RenderDeclares.h>
#include <string>
#include <windows.h>

using namespace DDEX;

class DX9ImageFactoy : public Render::IImageFactory
{

protected:

	LPDIRECT3DDEVICE9 dev;
	D3DPOOL memoryMode;
public:

	DX9ImageFactoy(LPDIRECT3DDEVICE9 dev, int memoryMode) {
		this->dev = dev;
		this->memoryMode = D3DPOOL_DEFAULT;

	}

	virtual void * Make(char * file) {
		LPDIRECT3DTEXTURE9 t = NULL;
		WCHAR message[0xFFF];

		HRESULT r;
		__int32 width = 0;
		__int32 height = 0;
		int type;
		type = this->GetImageSizeFromFile(file, &width, &height);
		r = D3DXCreateTextureFromFileExA(this->dev,
			file,
			width,
			height,
			0,
			D3DUSAGE_DYNAMIC,
			D3DFMT_A8R8G8B8,
			this->memoryMode,
			D3DX_FILTER_NONE,
			D3DX_DEFAULT,
			(type == 0) ? D3DCOLOR_COLORVALUE(0.0f, 0.0f, 0.0f, 1.0f) : NULL,
			NULL,
			NULL,
			&t);

		if (r == S_OK) {
			return (void*)t;
		}
		else
		{
//			wsprintf(message, L"%s %s", DXGetErrorString(r), DXGetErrorDescription(r));
			return NULL;
		}
	}
	virtual void * Make(void * buffer, __int32 size) {
		LPDIRECT3DTEXTURE9 t = NULL;
		HRESULT r;
		__int32 width = 0;
		__int32 height = 0;
		WCHAR message[0xFFF];

		int type;
		type = this->GetImageSizeFromMemory((char *)buffer, &width, &height);

		r = D3DXCreateTextureFromFileInMemoryEx(this->dev,
			buffer,
			(UINT)size,
			width,
			height,
			0,
			D3DUSAGE_DYNAMIC,
			D3DFMT_A8R8G8B8,
			this->memoryMode,
			D3DX_FILTER_NONE,
			D3DX_DEFAULT,
			(type == 0) ? D3DCOLOR_COLORVALUE(0.0f, 0.0f, 0.0f, 1.0f) : NULL,
			NULL,
			NULL,
			&t);

		if (r == S_OK) {
			return (void*)t;
		}
		else
		{
			FILE * f = NULL;
			fopen_s(&f, "aaaa.bmp", "wb");

			fwrite(buffer, size, 1, f);

			fclose(f);
			//wsprintf(message, L"%s %s", DXGetErrorString(r), DXGetErrorDescription(r));
			return NULL;
		}
	}

	int GetImageSizeFromMemory(char * buffer, __int32 * width, __int32 * height) {
		BITMAPINFOHEADER * bmfHeader;
		__int16 fileType = 0;

		memcpy_s(&fileType, 2, buffer, 2);

		switch (fileType)
		{
		case 0x424d:
		case 0x4d42:
			bmfHeader = (BITMAPINFOHEADER *)(buffer + sizeof(BITMAPFILEHEADER));
			*width = bmfHeader->biWidth;
			*height = bmfHeader->biHeight;
			return 0;
		case 0x5089:
		case 0x8950:
			memcpy_s(&width, 4, buffer + 16, 2);
			memcpy_s(&height, 4, buffer + 16 + 4, 2);
			*width = _byteswap_ulong(*width);
			*height = _byteswap_ulong(*height);
			return 1;
		default:
			break;
		}

		return 0;
	}

	int GetImageSizeFromFile(char * file, __int32 * width, __int32 * height) {
		FILE *f;
		__int8 buffer[200];
		
		fopen_s(&f, file, "rb");
		if (f == NULL)	return -1;
		int type = -1;
		fread(buffer, 200, 1, f);
		fclose(f);
		type = this->GetImageSizeFromMemory(buffer, width, height);
		return type;
	}

	void Free(void * image) {
		((LPDIRECT3DTEXTURE9)image)->Release();
	}

	~DX9ImageFactoy(void) {
	}
};

