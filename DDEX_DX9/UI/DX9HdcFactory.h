#pragma once
#include <Windows.h>
#include <d3d9.h>
#include <d3dx9.h>
#include <DxErr.h>
#include <math.h>

#include <Render\RenderDeclares.h>
#include <Render\ImageManager.h>
#include <UI\IHDCFactory.h>


using namespace DDEX;

class DX9HdcFactory : public IHDCFactory
{

public:

	DX9HdcFactory(Render::IImageManager * _imageManager) {
		this->imageManager = _imageManager;
	}

	~DX9HdcFactory() {
	}

protected:

	Render::IImageManager * imageManager;

	virtual HDC Make(unsigned __int32 imageIndex) {
		LPDIRECT3DTEXTURE9 texture;
		HDC hdc = 0;
		D3DSURFACE_DESC surfaceDesc;
		LPDIRECT3DSURFACE9 surface = NULL;
		D3DLOCKED_RECT locked;
		RECT surfaceRect;
		BYTE * bmpData = NULL;
		int pixelsSize = 0;
		int bmpSize = 0;

		texture = (LPDIRECT3DTEXTURE9)this->imageManager->GetImage(imageIndex);

		if (texture != NULL) {
			texture->GetSurfaceLevel(0, &surface);
			surface->GetDesc(&surfaceDesc);
			surfaceRect.left = 0;
			surfaceRect.top = 0;
			surfaceRect.bottom = surfaceDesc.Height;
			surfaceRect.right = surfaceDesc.Width;

			if (SUCCEEDED(surface->LockRect(&locked, NULL, D3DLOCK_READONLY))) {

				bmpSize = MakeBMP(surfaceDesc.Width, surfaceDesc.Height, &bmpData);

				pixelsSize = bmpSize - (sizeof(BITMAPINFO) + 14);

				BYTE *pixels = (BYTE*)((bmpData)+(sizeof(BITMAPINFO) + 14));
				BYTE c = 0;

				switch (surfaceDesc.Format)
				{
				case D3DFORMAT::D3DFMT_R8G8B8:
					c = 0xFF;
					for (int i = 0; i < pixelsSize; i++)
					{
						*(pixels + i) = c;
					}
					break;
				case D3DFORMAT::D3DFMT_A8R8G8B8:
					c = 0xAA;

					for (UINT y = 0; y < surfaceDesc.Height; y++)
					{
						for (UINT x = 0; x < surfaceDesc.Width; x++)
						{
							int index = (x * 4 + ((((surfaceDesc.Height) - y))*(locked.Pitch)));
							int pindex = (x * 4 + (y*((surfaceDesc.Width) * 4)));
							index -= locked.Pitch;
							//index += 4;
							pixels[pindex] = ((BYTE*)locked.pBits)[index];
							pixels[pindex + 1] = ((BYTE*)locked.pBits)[index + 1];
							pixels[pindex + 2] = ((BYTE*)locked.pBits)[index + 2];
							pixels[pindex + 3] = ((BYTE*)locked.pBits)[index + 3];
						}
					}

					break;
				default:
					c = 0x00;

					for (int i = 0; i < pixelsSize; i++)
					{
						*(pixels + i) = c;
					}

					break;
				}

				surface->UnlockRect();

				BITMAPINFO * bmi = (BITMAPINFO*)(bmpData + 14);

				BITMAPINFOHEADER * bmih = &bmi->bmiHeader;

				hdc = CreateCompatibleDC(GetDC(NULL));

				HBITMAP mm = CreateDIBSection(hdc, bmi, DIB_RGB_COLORS, NULL, NULL, 0);

				(HBITMAP)SelectObject(hdc, mm);

				//TODO LOG!
				if (SetDIBits(hdc, mm, 0, bmih->biHeight, (void*)pixels, bmi, DIB_RGB_COLORS) <= 0) {
				}

				free(bmpData);
			}
		}

		return hdc;
	}

	int MakeBMP(int width, int height, BYTE ** bmp) {
		unsigned char file[14] = {
			'B','M', // magic
			0,0,0,0, // size in bytes
			0,0, // app data
			0,0, // app data
			40 + 14,0,0,0 // start of data offset
		};

		int size;
		//create
		int bitCount = 32;

		int bytes_per_pixel = bitCount / 8;
		size = (bytes_per_pixel * width * height) + sizeof(BITMAPINFO) + 14;

		BYTE *data = (BYTE*)malloc(size);

		memcpy_s(data, size, file, 14);

		BITMAPINFO * bmi = (BITMAPINFO*)(data + 14);

		ZeroMemory(bmi, sizeof(BITMAPINFO));
		BITMAPINFOHEADER * bmih = &bmi->bmiHeader;

		bmih->biSize = sizeof(BITMAPINFOHEADER);
		bmih->biPlanes = 1;
		bmih->biBitCount = bitCount;
		bmih->biWidth = width;
		bmih->biHeight = height;
		bmih->biCompression = BI_RGB;
		bmih->biSizeImage = 0;

		*bmp = data;
		return size;
	}


};

