#pragma once
#include <Windows.h>
namespace DDEX {
	class IHDCFactory
	{
	public:
		virtual HDC Make(unsigned __int32 imageIndex) = 0;
	};
}
