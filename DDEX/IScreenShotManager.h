#pragma once
#define NOMINMAX
#include <Windows.h>
namespace DDEX {
	class IScreenShotManager
	{

	public:

		virtual void ScreenShot(HWND hwnd, wchar_t * filename, __int32 imageType) = 0;
		virtual ~IScreenShotManager()
		{
		}
	};

}