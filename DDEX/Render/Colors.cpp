#pragma once
#include "Colors.h"

namespace DDEX {
	namespace Render {
		RenderColor Colors::White = RenderColor(0xFF, 0xFF, 0xFF, 0xFF);
		RenderColor Colors::Black = RenderColor(0x00, 0x00, 0x00, 0x00);
		RenderColor Colors::Red = RenderColor(0xFF, 0xFF, 0x00, 0x00);
		RenderColor Colors::Blue = RenderColor(0xFF, 0x00, 0x00, 0xFF);
	}
}
