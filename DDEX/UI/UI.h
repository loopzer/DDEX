#pragma once

#define NOMINMAX

#include <Windows.h>
namespace DDEX {
	typedef struct {
		HICON icon;
		HDC hdc;
		HDC hdcRed;
		HBITMAP bitmap;
		HBITMAP bitmapRed;
		HCURSOR cursor;
		unsigned __int32 imageIndex;
	} UIComponent;
}