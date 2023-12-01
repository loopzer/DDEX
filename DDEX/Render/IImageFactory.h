#pragma once
#ifndef _IIMAGEFACTORY_H
#define _IIMAGEFACTORY_H

#include <Windows.h>
#include "RenderDeclares.h"
namespace DDEX {
	namespace Render {
		class IImageFactory
		{
		public:
			virtual void * Make(char * file) = 0;
			virtual void * Make(void * buffer, __int32 size) = 0;
			virtual void Free(void * image) = 0;
		};
	};
};
#endif