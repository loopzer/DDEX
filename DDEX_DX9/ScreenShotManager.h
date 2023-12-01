#pragma once
#ifndef _DDEXDX9SCREENSHOTMANAGER_H
#define _DDEXDX9SCREENSHOTMANAGER_H

#include <cstdlib>
#include <stdlib.h>
#include <exception>
#include <IScreenShotManager.h>
#include <time.h>
#include <d3d9.h>
#include <d3dx9.h>
#include <DxErr.h>
#include <math.h>
#pragma comment(lib, "dxerr.lib")
#include "DX9\Dx9Def.h"
#include <stack>
using namespace DDEX;

struct sSCREENSHOTVALUES {
	LPDIRECT3DTEXTURE9 texture;

	LPDIRECT3DSURFACE9 surface;

	RECT rect;

	wchar_t * fileName;

	__int8 fileType;

	bool isDestroy;
};

typedef struct sSCREENSHOTVALUES SCREENSHOTVALUES;

class DDExDx9ScreenShotManager :public IScreenShotManager {

protected:
	LPDIRECT3DDEVICE9 D3DDev;

	std::stack<SCREENSHOTVALUES *> screens;
	HANDLE semaphore;
	HANDLE commandSemaphore;
	HANDLE mutex;
	HANDLE thread;
	CRITICAL_SECTION cs;


	void Add(SCREENSHOTVALUES * p) {
		EnterCriticalSection(&this->cs);
		this->screens.push(p);
		LeaveCriticalSection(&this->cs);
		SetEvent(this->semaphore);
	}

	void Save(SCREENSHOTVALUES * v) {

		D3DXIMAGE_FILEFORMAT imageFormat;

		switch (v->fileType)
		{
		case 0://JPG
			imageFormat = D3DXIFF_JPG;
			break;
		case 1://PNG
			imageFormat = D3DXIFF_PNG;
			break;
		case 2://BMP
			imageFormat = D3DXIFF_BMP;
			break;
		default:
			imageFormat = D3DXIFF_JPG;
			break;
		}

		D3DXSaveSurfaceToFile(v->fileName, imageFormat, v->surface, 0, 0);

		v->surface->Release();
		v->texture->Release();

		delete v->fileName;
	}

public:
	DDExDx9ScreenShotManager(LPDIRECT3DDEVICE9 D3DDev) {
		this->D3DDev = D3DDev;

		this->semaphore = CreateEvent(0, TRUE, FALSE, 0);

		InitializeCriticalSection(&this->cs);

		this->thread = CreateThread(
			NULL,                   // default security attributes
			0,                      // use default stack size
			DDExDx9ScreenShotManager::ThreadProc,       // thread function name
			this,          // argument to thread function
			0,                      // use default creation flags
			0);   // returns the thread identifier

	};

	void ScreenShot(HWND hwnd, wchar_t * filename, __int32 imageType) {
		SCREENSHOTVALUES * v = new SCREENSHOTVALUES;
		RECT mR;
		GetClientRect(hwnd, &mR);

		v->isDestroy = false;

		v->rect = mR;
		v->fileType = imageType;

		v->fileName = Clone(filename);

		D3DXCreateTexture(this->D3DDev, v->rect.right, v->rect.bottom, D3DX_DEFAULT, D3DUSAGE_DYNAMIC,
			D3DFMT_X8R8G8B8, D3DPOOL_DEFAULT, &v->texture);

		v->texture->GetSurfaceLevel(0, &v->surface);

		HDC hDCS;

		HDC hDC = GetDC(hwnd);

		v->surface->GetDC(&hDCS);

		BitBlt(hDCS, 0, 0, v->rect.right, v->rect.bottom, hDC, 0, 0, SRCCOPY);
		v->surface->ReleaseDC(hDCS);

		this->Add(v);
	}

	wchar_t *Clone(wchar_t *c)
	{
		const size_t cSize = wcslen(c) + 1;
		wchar_t* wc = new wchar_t[cSize];
		wcscpy_s(wc, cSize, c);
		return wc;
	}

	~DDExDx9ScreenShotManager(void) {
		SCREENSHOTVALUES * v = new SCREENSHOTVALUES;
		v->isDestroy = true;
		this->Add(v);
		WaitForSingleObject(thread, INFINITE);
	}

	static DWORD WINAPI ThreadProc(LPVOID lpParameter) {
		DDExDx9ScreenShotManager * tp = (DDExDx9ScreenShotManager *)lpParameter;
		SCREENSHOTVALUES * screen = NULL;

		for (;;)
		{
			EnterCriticalSection(&tp->cs);
			if (!tp->screens.empty()) {
				screen = tp->screens.top();
				tp->screens.pop();
			}
			LeaveCriticalSection(&tp->cs);
			if (screen != NULL) {
				if (screen->isDestroy) {
					delete screen;

					DeleteCriticalSection(&tp->cs);

					CloseHandle(tp->thread);
					return 0;
				}
				tp->Save(screen);
				delete screen;
				screen = NULL;
			}
			else
			{
				WaitForSingleObject(tp->semaphore, 10);
				ResetEvent(tp->semaphore);
			}
		}
	}
};

#endif