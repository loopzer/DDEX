#pragma once
#ifndef _COLORS_H
#define _COLORS_H

#include <Windows.h>
#include "RenderDeclares.h"
namespace DDEX {
	namespace Render {

		class Colors
		{
		public:

			static RenderColor White;
			static RenderColor Black;
			static RenderColor Red;
			static RenderColor Blue;

			static void  Init() {
				/*
				Colors::White = RenderColor(0xFF, 0xFF, 0xFF, 0xFF);
				Colors::Black = RenderColor(0x00, 0x00, 0x00, 0x00);
				Colors::Red = RenderColor(0xFF, 0xFF, 0x00, 0x00);
				Colors::Blue = RenderColor(0xFF, 0x00, 0x00, 0xFF);
				*/
			}

			static RenderColor MakeWhite(__int8 alpha) {
				RenderColor c;
				c.r = 0xFF;
				c.g = 0xFF;
				c.b = 0xFF;
				c.a = alpha;
				return c;
			}

		};
	};
};
#endif