#pragma once

#define NOMINMAX

#include <Windows.h>
#include "UI.h"
#include "../Resource/IIndexResourceFactory.h"
#include "../Resource/IndexResourceManager.h"
#include "UIComponentManager.h"
#pragma comment(lib, "gdiplus.lib")

#include <gdiplus.h>

namespace DDEX {
	class UICursorManager : public IIndexResourceFactory<HICON>
	{
	private:
		IndexResourceManager<HICON> * resourceManager;
		UIComponentManager * componentManager;
		RECT currentRect;
		int currentFile;

		HICON  MakeCursor(UIComponent * uic)
		{
			HDC hNew = CreateCompatibleDC(uic->hdc);
			HBITMAP hBmp = CreateCompatibleBitmap(uic->hdc, 32, 32);
			HBITMAP hOld = (HBITMAP)SelectObject(hNew, hBmp);

			bool retVal = (BitBlt(hNew, 0, 0, 32, 32, uic->hdc, this->currentRect.left, this->currentRect.top, SRCCOPY)) ? true : false;
			
			SelectObject(hNew, hOld);

			DeleteDC(hNew);

			HBITMAP hbmMask = ::CreateCompatibleBitmap(GetDC(NULL),
				32, 32);

			ICONINFO ii = { 0 };
			ii.fIcon = TRUE;
			ii.hbmColor = hBmp;
			ii.hbmMask = hbmMask;

			HICON hIcon = ::CreateIconIndirect(&ii);

			::DeleteObject(hbmMask);
			return hIcon;
		}

	public:

		UICursorManager(UIComponentManager * componentManager) {
			this->resourceManager = new IndexResourceManager<HICON>(this, 0xFFFF, 1500);
		}

		HICON * Get(unsigned __int32 grhIndex, int _file, RECT * _rect) {
			this->currentRect = *_rect;
			this->currentFile = _file;
			return this->resourceManager->Get(grhIndex);
		};

		~UICursorManager() {
			delete this->resourceManager;
		}

		virtual HICON * Make(unsigned __int32 grhIndex) {

			UIComponent *  component;
			HICON * hicon  = new HICON();
			component = this->componentManager->Get(this->currentFile);

			*hicon = this->MakeCursor(component);

			return hicon;
		}

		virtual void Destroy(HICON * resource) {
			DeleteObject(*resource);
			delete resource;
		};
	};
}
