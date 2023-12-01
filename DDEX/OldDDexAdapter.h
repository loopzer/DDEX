#include <Windows.h>
//#include <DDEXRenderBase.h>
#include "Render\Render.h"
#include "ContextBase.h"
#include "UI\UIComponentManager.h"
#include "UI\UICursorManager.h"
//
//class OldDDexAdapter : public DDEXRenderBase
//{
//public:
//	OldDDexAdapter() {
//	}
//	~OldDDexAdapter() {
//		delete this->uiComponentManager;
//		delete this->uiCursorManager;
//		delete this->render;
//	}
//
//private:
//	DDEX::Render::Render *render;
//	DDEX::ContextBase *context;
//	DDEX::Render::IRenderPrimitive * primitive;
//	DDEX::UIComponentManager * uiComponentManager;
//	DDEX::UICursorManager * uiCursorManager;
//
//	DDEX::ContextBase * DDEXContextFromPlugin(wchar_t * plugin) {
//		HINSTANCE hGetProcIDDLL = LoadLibrary(plugin);
//
//		if (!hGetProcIDDLL) {
//			return NULL;
//		}
//
//		DDEX::CreateContextFunc func = (DDEX::CreateContextFunc)GetProcAddress(hGetProcIDDLL, "DDEX_Context");
//
//		if (!func) {
//			return NULL;
//		}
//
//		return func();
//	}
//
//	// Inherited via DDEXRenderBase
//	virtual __int32 Primitive_Lines(RECT * r, __int32 linesCount, DDEXARGB * c) override;
//	virtual void DrawImage(__int32 image, __int32 x, __int32 y, DDEXARGB * c) override;
//	virtual void DrawBox(RECT * r, DDEXARGB * c) override;
//	virtual HDC GetImageHDC(__int32 image) override;
//
//	// Inherited via DDEXRenderBase
//	virtual __int32 DDExIniciar(HWND ventana, char * dir_grafico, Configuracion * cfg) override;
//	virtual __int32 DDExCargarFuenteX(__int8 * nombre, __int32 tam, __int32 negrita, __int32 cursiva, __int32 id) override;
//	virtual __int32 DDExSaveImage(HWND hwnd, char * filename, __int32 imageType) override;
//	virtual __int32 DDExDibujarPantalla() override;
//	virtual __int32 DDExSetRenderEffect(__int32 effect, void * data) override;
//	virtual __int32 DDExFlushScreen() override;
//	virtual __int32 DDExFlushBackground() override;
//	virtual __int32 DDExDibujarTexto(char * texto, __int32 x, __int32 y, DDEXARGB * c, __int32 f) override;
//	virtual __int32 DDExDibujarPantallaEx(RECT * entrada, RECT * salida, HWND ventana) override;
//	virtual __int32 DDExLimpiarPantalla() override;
//	virtual __int32 DDExDibujarCaja(RECT * r, DDEXARGB * c, __int32 angulo) override;
//	virtual void SetGetFileBytes(FuncGetFileBytes func) override;
//	virtual __int32 GetHDCFont(__int32 font) override;
//
//	// Inherited via DDEXRenderBase
//	virtual __int32 DDExTerminar() override;
//
//
//	// Inherited via DDEXRenderBase
//	virtual __int32 DDExDibujarRGraficoAlphaPos(__int32 archivo, RECT * r, __int32 x, __int32 y, DDEXARGB * c) override;
//
//	virtual __int32 DDExDibujarGrafico(__int32 archivo, RECT * r, __int32 x, __int32 y, DDEXARGB * c, __int32 angulo) override;
//
//
//	virtual void DDEXCleanLights();
//
//	virtual void DDEXSetLight(struct DDEXLIGHTDRAW * d);
//
//	virtual void SetMastherLight(__int32 redLight, __int32 greenLight, __int32 blueLight);
//
//};
