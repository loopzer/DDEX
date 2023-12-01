#pragma once
#include <Windows.h>
#include "UI.h"
#include "IHDCFactory.h"
#include "../Resource/IIndexResourceFactory.h"
#include "../Resource/IndexResourceManager.h"
#pragma comment(lib, "gdiplus.lib")

#include <gdiplus.h>

namespace DDEX {
	class UIComponentManager : public IIndexResourceFactory<UIComponent>
	{
	private:
		IHDCFactory * hdcFactory;
		IndexResourceManager<UIComponent> * resourceManager;

		HICON  HICONFromHBITMAP(HBITMAP bitmap)
		{
			BITMAP bmp;
			HBITMAP hbmMask = ::CreateCompatibleBitmap(GetDC(NULL), 32, 32);
			ICONINFO ii = { 0 };
			
			ii.fIcon = TRUE;
			ii.hbmColor = bitmap;
			ii.hbmMask = hbmMask;
			
			HICON hIcon = ::CreateIconIndirect(&ii);
			::DeleteObject(hbmMask);

			return hIcon;
		}

		void SetRed(UIComponent * uic) {

			BITMAP bmp = { 0 };
			BITMAPINFO info = { 0 };
			char * pixels;
			char * pixelCursor;
			int lines;

			GetObject(uic->bitmap, sizeof(bmp), &bmp);

			info.bmiHeader.biSize = sizeof(BITMAPINFOHEADER);
			info.bmiHeader.biWidth = bmp.bmWidth;
			info.bmiHeader.biHeight = bmp.bmHeight;
			info.bmiHeader.biPlanes = 1;
			info.bmiHeader.biBitCount = bmp.bmBitsPixel;
			info.bmiHeader.biCompression = BI_RGB;
			info.bmiHeader.biSizeImage = ((bmp.bmWidth * bmp.bmBitsPixel + 31) / 32) * 4 * bmp.bmHeight;

			pixels = new char[info.bmiHeader.biSizeImage];

			lines = GetDIBits(uic->hdc, uic->bitmap, 0, bmp.bmHeight, (void*)pixels, &info, DIB_RGB_COLORS);

			HDC hdc = CreateCompatibleDC(uic->hdc);

			HBITMAP newBMP = CreateDIBSection(hdc, &info, DIB_RGB_COLORS, NULL, NULL, 0);

			pixelCursor = pixels;

			for (size_t i = 0; i < info.bmiHeader.biSizeImage / 4; i++)
			{
				pixelCursor[0] = 0;
				pixelCursor[1] = 0;
				pixelCursor += 4;
			}

			SelectObject(hdc, newBMP);
			SetDIBits(hdc, newBMP, 0, lines, (const void *)pixels, &info, DIB_RGB_COLORS);

			delete[] pixels;

			uic->hdcRed = hdc;
			uic->bitmapRed = newBMP;
		}




	public:

		UIComponentManager(IHDCFactory * _factory) {
			this->hdcFactory = _factory;
			this->resourceManager = new IndexResourceManager<UIComponent>(this, 0xFFFF, 1500);
		}

		UIComponent * Get(unsigned __int32 imageIndex) {
			return this->resourceManager->Get(imageIndex);
		};

		~UIComponentManager() {
			delete this->resourceManager;
		}

		virtual UIComponent * Make(unsigned __int32 resourceIndex) {

			UIComponent *  component = new UIComponent;

			HDC hdc = this->hdcFactory->Make(resourceIndex);
			component->hdc = hdc;
			component->bitmap = (HBITMAP)GetCurrentObject(hdc, OBJ_BITMAP);
			component->icon = HICONFromHBITMAP(component->bitmap);
			component->cursor = component->icon;
			this->SetRed(component);
			component->imageIndex = resourceIndex;
			return component;
		}

		virtual void Destroy(UIComponent * resource) {
			DeleteObject(resource->icon);
			DeleteObject(resource->bitmap);
			DeleteObject(resource->bitmapRed);
			DeleteDC(resource->hdc);
			DeleteDC(resource->hdcRed);
			delete resource;
		};
	};
}
