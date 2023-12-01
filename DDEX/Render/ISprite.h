#pragma once
#ifndef _ISPRITE_H
#define _ISPRITE_H

#include <Windows.h>
#include "RenderDeclares.h"
#include "IPSManager.h"
namespace DDEX {
	namespace Render {
		class ISprite
		{

		public:

			virtual void Draw(void * resource, int x, int y, RECT * rect, RenderColor * color, int angle) = 0;
			virtual void DrawRaw(void * resource, RECT * rect, RenderColor * color) = 0;
			virtual void DrawRaw(void * resource, RECT * rect, RenderColor * color, void * extra) = 0;
			virtual void Draw(void * resource, Vector2 * position, Vector2 * scaling, Vector2 * center, Vector2 * centerScaling, RenderColor * color, int angle) = 0;
			virtual void DrawLight(void * resource, int x, int y, RECT * rect, RenderColor * color, int angle) = 0;
			virtual void End() = 0;
			virtual ~ISprite() {
			}
		};
	};
};
#endif
