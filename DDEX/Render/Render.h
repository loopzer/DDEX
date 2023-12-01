#pragma once
#ifndef _RENDER_H
#define _RENDER_H

#include <Windows.h>
#include "RenderDeclares.h"

#include "IImageFactory.h"
#include "ImageManager.h"

#include "IPSManager.h"
#include "ISprite.h"

#include "..\Layers\LayerDeclares.h"

#include "..\Layers\ILayer.h"
#include "..\Layers\ILayerFactory.h"
#include "..\Layers\LayerEffectManager.h"
#include "..\Layers\LayerEffectOrchestrator.h"

#include "..\Fonts\FontDeclares.h"
#include "..\Fonts\FontManager.h"
#include "..\Fonts\IFontFactory.h"
#include "..\Fonts\IFont.h"
#include "..\IScreenShotManager.h"

#include "RenderBase.h"
#include "../ContextBase.h"
namespace DDEX {
	namespace Render {
		class Render :public RenderBase
		{
		protected:


		public:

			Render(ContextBase * context, HWND window, char * imageFolder, Configuration * cfg) :
				RenderBase(context, window, imageFolder, cfg) {

			}

			~Render() {

			}
		};
	};
};
#endif