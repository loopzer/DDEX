#include "dllUI.h"
using namespace DDEX;


UIComponentManager * __stdcall 	UI_CreateUIComponentManager(Render::Render * render) {
	return new UIComponentManager(render->GetHdcFactory());
}

void __stdcall UI_DestroyUIComponentManager(UIComponentManager * manager) {
	delete manager;
}

UIComponent __stdcall UI_GetUIComponent(UIComponentManager * manager, unsigned __int32 imageIndex) {
	return *manager->Get(imageIndex);
}

UICursorManager * __stdcall 	UI_CreateUICursorManager(UIComponentManager * manager) {
	return new UICursorManager(manager);
}

void __stdcall UI_DestroyUICursorManager(UICursorManager * manager) {
	delete manager;
}

HICON __stdcall UI_GetUICursor(UICursorManager * manager, __int32 grhindex, __int32 file, RECT * rect) {
	return *manager->Get(grhindex, file, rect);
}

