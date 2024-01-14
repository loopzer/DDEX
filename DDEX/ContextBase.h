#pragma once
#define NOMINMAX
#include <Windows.h>
#include "Render\RenderDeclares.h"
#include "Render\IImageFactory.h"
#include "Render\IPSManager.h"
#include "Render\IRenderPrimitive.h"
#include "Render\IImageManager.h"
#include "Fonts\IFontFactory.h"
#include "Layers\ILayer.h"
#include "Layers\ILayerFactory.h"
#include "UI\IHDCFactory.h"
#include "IScreenShotManager.h"
#include "ContextBase.h"
namespace DDEX {
	class ContextBase
	{

	public:

		virtual __int32 Init(HWND window, char * grafPath, Render::Configuration * cfg) = 0;

		virtual void InitFrame() = 0;
		virtual void EndFrame(Layers::ILayer *layer) = 0;
		virtual void EndFrame(Layers::ILayer *layer, HWND window, RECT * source, RECT * dest) = 0;

		virtual Render::IImageFactory * GetImageFactory() = 0;
		virtual Render::IPSManager * GetPSManager() = 0;
		virtual IFontFactory * GetFontFactory() = 0;
		virtual Layers::ILayerFactory * GetLayerFactory() = 0;
		virtual IScreenShotManager * GetScreenShotManager() = 0;
		virtual Render::IRenderPrimitive * GetRenderPrimitive() = 0;
		virtual IHDCFactory * GetHdcFactory(Render::IImageManager * imageManager) = 0;
		virtual ~ContextBase() {
		}
	};
	typedef ContextBase *(__stdcall * CreateContextFunc)();
}