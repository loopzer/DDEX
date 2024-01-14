#define NOMINMAX

// dllmain.cpp : Defines the entry point for the DLL application.
#include <Windows.h>
#include <stdio.h>
#include <time.h>
#include "Render\RenderDeclares.h"
#include "ColorAnimation.h"
using namespace DDEX;

ColorAnimation * __stdcall ColorAnimation_Create(Render::RenderColor * from, Render::RenderColor * to, int duration, int isLoop){
	return new ColorAnimation(*from, *to, duration, (bool)isLoop);
}

void __stdcall ColorAnimation_Configure(ColorAnimation * c, Render::RenderColor * from, Render::RenderColor * to, int duration, int isLoop){
	c->Configure(*from, *to, duration, (bool)isLoop);
}
void __stdcall ColorAnimation_Start(ColorAnimation * c){
	c->Start();
}

void __stdcall ColorAnimation_StartWithTicks(ColorAnimation * c, int ticks){
	c->Start(ticks);
}

void __stdcall ColorAnimation_Tick(ColorAnimation * c){
	c->Tick();
}

void __stdcall ColorAnimation_TickWithTicks(ColorAnimation * c, int ticks){
	c->Tick(ticks);
}

Render::RenderColor __stdcall ColorAnimation_GetColor(ColorAnimation * c){
	return  c->GetColor();
}

void __stdcall ColorAnimation_GetColorRef(ColorAnimation * c, Render::RenderColor * rgb){
	*rgb = c->GetColor();
}
__int32 __stdcall ColorAnimation_IsComplete(ColorAnimation * c){
	return (__int32)c->IsComplete();
}

__int32 __stdcall ColorAnimation_GetColorAndIsComplete(ColorAnimation * c, Render::RenderColor * rgb){
	*rgb = c->GetColor();
	return (__int32)c->IsComplete();
}

void __stdcall ColorAnimation_Delete(ColorAnimation * c){
	if (c != NULL){
		delete c;
	}
}