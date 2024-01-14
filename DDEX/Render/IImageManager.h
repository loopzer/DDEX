#pragma once
#ifndef _IIMAGEMANAGER_H
#define _IIMAGEMANAGER_H
#define NOMINMAX

#include <Windows.h>
#include "RenderDeclares.h"

namespace DDEX {
	namespace Render {


		class IImageManager
		{
		public:
			virtual void SetGetFileBytes(FuncGetFileBytes func) = 0;

			virtual void * GetImage(__int32 imageNum) = 0;
		};
	};
};
#endif
