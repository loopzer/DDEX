#pragma once
#ifndef _IRENDERPRIMITIVE_H
#define _IRENDERPRIMITIVE_H

#include <Windows.h>
#include "RenderDeclares.h"
namespace DDEX {
	namespace Render {
		class IRenderPrimitive
		{
		public:
			virtual void DrawBox(RECT * rect, RenderColor * color) = 0;
			virtual void DrawFillBox(RECT * rect, RenderColor * color) = 0;
			virtual void DrawLine(RECT * rect, RenderColor * color) = 0;
		};
	};
};
#endif
