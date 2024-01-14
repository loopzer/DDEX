#define NOMINMAX

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
using namespace DDEX;

void __stdcall Primitive_DrawBox(Render::Render * render, RECT * r, Render::RenderColor * color) {
	render->GetContext()->GetRenderPrimitive()->DrawBox(r, color);
}

void __stdcall Primitive_DrawLine(Render::Render * render, RECT * r, Render::RenderColor * color) {
	render->GetContext()->GetRenderPrimitive()->DrawLine(r, color);
}

void __stdcall Primitive_DrawFillBox(Render::Render * render, RECT * r, Render::RenderColor * color) {
	render->GetContext()->GetRenderPrimitive()->DrawFillBox(r, color);
}

Render::IRenderPrimitive * __stdcall Primitive_Get(Render::Render * render) {
	return render->GetContext()->GetRenderPrimitive();
}
