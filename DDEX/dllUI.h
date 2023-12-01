#include <Windows.h>
#include <stdio.h>
#include <time.h>
#include "Render\RenderDeclares.h"
#include "Render\Render.h"
#include "UI\UI.h"
#include "UI\IHDCFactory.h"
#include "UI\UIComponentManager.h"
#include "UI\UICursorManager.h"
using namespace DDEX;

UIComponentManager * __stdcall 	UI_CreateUIComponentManager(Render::Render * render);

void __stdcall UI_DestroyUIComponentManager(UIComponentManager * manager);

UIComponent __stdcall UI_GetUIComponent(UIComponentManager * manager, unsigned __int32 imageIndex);

UICursorManager * __stdcall 	UI_CreateUICursorManager(UIComponentManager * manager);

void __stdcall UI_DestroyUICursorManager(UICursorManager * manager);

HICON __stdcall UI_GetUICursor(UICursorManager * manager, __int32 grhindex, __int32 file, RECT * rect);
