#define NOMINMAX

#include <Windows.h>
#include <stdio.h>
#include <time.h>
#include "Render\RenderDeclares.h"
#include "Animations\IAnimation.h"
#include "Render\Render.h"
#include "ColorAnimation.h"
using namespace DDEX;

Animations::IAnimation * __stdcall 	Animation_Make(Render::Render * render, __int32 type, void * data, __int32 dataCount) {
	return render->MakeAnimation(type, data, dataCount);
}

void __stdcall 	Animation_Delete(Render::Render * render, Animations::IAnimation * animation) {
	return render->DeleteAnimation(animation);
}
