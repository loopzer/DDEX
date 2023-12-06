// dllmain.cpp : Defines the entry point for the DLL application.
#include <Windows.h>
#include <stdio.h>
#include <time.h>
#include "Render\RenderDeclares.h"
#include "Render\Render.h"
#include "ColorAnimation.h"
#include "ContextBase.h"
#include "Render\Colors.h"
#include "Resource\IIndexResourceFactory.h"
#include "Resource\IndexResourceManager.h"
#define COLORREF2RGB(Color) (Color & 0xff00) | ((Color >> 16) & 0xff) \
                 | ((Color << 16) & 0xff0000)
using namespace DDEX;

void __stdcall DDEXMensajeDebugW(wchar_t* texto) {
	wchar_t dateStr[19];
	wchar_t timeStr[19];
	_wstrdate_s(dateStr);
	_wstrtime_s(timeStr);

	FILE* f;
	wchar_t out[0xFFFF];
	f = fopen("DDEXGeneral.log", "a");

	if (f == NULL) return;

	wsprintf(out, L"%s %s->%s\n", dateStr, timeStr, texto);
	fputws(out, f);

	fclose(f);

}

void __stdcall DDEXMensajeDebug(char * texto) {
	char dateStr[19];
	char timeStr[19];
	_strdate_s(dateStr);
	_strtime_s(timeStr);

	FILE * f;
	char out[0xFFFF];
	f = fopen("DDEXGeneral.log", "a");

	if (f == NULL) return;

	sprintf(out, "%s %s->%s\n", dateStr, timeStr, texto);
	fputs(out, f);

	fclose(f);

}

void __stdcall Test(wchar_t * data) {
	DDEXMensajeDebugW(data);
}

ContextBase * DDEXContextFromPlugin(char * plugin) {
	HINSTANCE hGetProcIDDLL = LoadLibraryA(plugin);

	if (!hGetProcIDDLL) {
		return NULL;
	}

	CreateContextFunc func = (CreateContextFunc)GetProcAddress(hGetProcIDDLL, "DDEX_Context");

	if (!func) {
		return NULL;
	}

	return func();
}
//Render::Render* __stdcall Render_Create(wchar_t* plugin, HWND v, wchar_t* imageFolder, Render::Configuration* cfg) {
Render::Render * __stdcall Render_Create(char * plugin, HWND v, char * imageFolder, Render::Configuration * cfg) {
	
	Render::Render * render = NULL;
	
	ContextBase * context;
	DDEXMensajeDebug("->Plugin");
	DDEXMensajeDebug(plugin);
	DDEXMensajeDebug("<-Plugin");
	DDEXMensajeDebug("->image folder");
	DDEXMensajeDebug(imageFolder);
	DDEXMensajeDebug("<-image folder");

	DDEXMensajeDebug("<-NotDefferal");

	context = DDEXContextFromPlugin(plugin);
	if (context == NULL) {
		DDEXMensajeDebug("Context is null");
	}
	else
	{
		context->Init(v, imageFolder, cfg);

		render = new Render::Render(context, v, imageFolder, cfg);

		DDEXMensajeDebug("Iniciar Motor");
	}

	
	return render;
}

void __stdcall Render_Clean(Render::Render * render) {
	render->CleanScreen();
}

void __stdcall Render_DrawImage(Render::Render * render, int imageNum, int x, int y, RECT * r, Render::RenderColor * color) {
	render->Draw(imageNum, x, y, r, color);
}
void __stdcall Render_DrawScaleImage(Render::Render * render, int imageNum, int x, int y, RECT * r, RECT * scale, Render::RenderColor * color) {
	render->Draw(imageNum, x, y, r, scale, color);
}
void __stdcall Render_Present(Render::Render * render) {
	render->Present();
}
void __stdcall Render_PresentWindow(Render::Render* render, HWND hwnd) {
	RECT windowRect;
	GetWindowRect(hwnd, &windowRect);

	windowRect.right = windowRect.right - windowRect.left;
	windowRect.bottom = windowRect.bottom - windowRect.top;
	windowRect.left = 0;
	windowRect.top = 0;

	render->Present(hwnd, &windowRect, &windowRect);
}
void __stdcall Render_FlushScreen(Render::Render * render) {
	render->FlushScreen();
}
void __stdcall Render_FlushBackground(Render::Render * render) {
	render->FlushBackground();
}

void __stdcall Render_Destroy(Render::Render * render) {
	delete render;
}

void __stdcall Render_CleanLight(Render::Render * render) {
	render->CleanLights();
}

void __stdcall Render_SetLight(Render::Render * render, Render::LightDraw *d) {
	render->SetLight(d);
}

void __stdcall Render_SetMasterLight(Render::Render * render, __int32 redLight, __int32 greenLight, __int32 blueLight) {
	render->SetMastherLight(redLight, greenLight, blueLight);
}

void __stdcall Render_SetRenderEffect(Render::Render * render, __int32 effect, Render::EffectParameters * data) {
	render->SetRenderEffect(effect, data);
}

void __stdcall Render_ClearPresentEffect(Render::Render * render, __int32 effect) {
	render->ClearPresentEffect(effect);
}

void __stdcall Render_SetPresentEffect(Render::Render * render, __int32 effect, Render::EffectParameters * data) {
	render->SetPresentEffect(effect, data);
}
__int32 __stdcall Render_MakeFont(Render::Render * render, char * fontName, __int32 size, bool bold, bool italic, __int32 forcedId) {
	return render->MakeFont(fontName, size, bold, italic, forcedId);
}
void __stdcall Render_DrawFont(Render::Render * render, char * text, int font, int x, int y, Render::RenderColor * color) {
	render->Draw(text, font, x, y, color);
}
void __stdcall Render_DrawImageWithRotation(Render::Render * render, int imageNum, int x, int y, RECT * r, Render::RenderColor * color, int angle) {
	render->Draw(imageNum, x, y, r, color, angle);
}

HDC __stdcall Render_GetFontHDC(Render::Render * render, int font) {
	return render->GetFontDC(font);
}

void __stdcall Render_SetImageProxy(Render::Render * render, Render::FuncGetFileBytes func) {
	render->ImageManager_SetGetFileBytes(func);
}


bool APIENTRY DllMain(HMODULE hModule, DWORD dwReason, LPVOID lpvReserved) {

	if (dwReason == DLL_PROCESS_ATTACH) {
		//	Particulas::InitParticles();
		remove("DDEXGeneral.log");
		remove("DDExDx9.log");
		Render::Colors::Init();
		DDEXMensajeDebug("DDEX Cargada");
		//	PM = new ParticleManager();
		//		PM->InitParticles();
	}
	if (dwReason == DLL_PROCESS_DETACH) {
		DDEXMensajeDebug("DDEX Descargada");
		//aca poner salida total :P
		//		PM->FreeParticles();
	}

	return true;
}
