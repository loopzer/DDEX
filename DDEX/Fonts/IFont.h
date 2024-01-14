#pragma once
#define NOMINMAX
#include <Windows.h>
#include "../Render/RenderDeclares.h"

namespace DDEX {
	class IFont
	{

	public:

		virtual void Draw(char * text, int x, int y, Render::RenderColor * color) = 0;
		virtual HDC GetHDC() = 0;
		virtual ~IFont() {
		}
	};

}