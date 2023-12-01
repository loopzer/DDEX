//#include "OldDDexAdapter.h"
//
//__int32 OldDDexAdapter::Primitive_Lines(RECT * r, __int32 linesCount, DDEXARGB * c)
//{
//	return 0;
//}
//
//void OldDDexAdapter::DrawImage(__int32 image, __int32 x, __int32 y, DDEXARGB * c)
//{
//
//}
//
//void OldDDexAdapter::DrawBox(RECT * r, DDEXARGB * c)
//{
//	this->primitive->DrawBox(r, (DDEX::Render::RenderColor*)c);
//}
//
//HDC OldDDexAdapter::GetImageHDC(__int32 image)
//{
//	return this->uiComponentManager->Get(image)->hdc;
//}
//
//__int32 OldDDexAdapter::DDExIniciar(HWND ventana, char * dir_grafico, Configuracion * cfg)
//{
//	if (cfg->api != 3) {
//		this->context = this->DDEXContextFromPlugin(L"DDEXv5_DX9.dll");
//	}
//	else
//	{
//		this->context = this->DDEXContextFromPlugin(L"DDEXv5_DX8.dll");
//	}
//
//	wchar_t tmp[0x1FF];
//	memset(tmp, 0, 0x1FF * 2);
//	mbstowcs(tmp, dir_grafico, strlen(dir_grafico));
//
//	this->context->Init(ventana, tmp, (DDEX::Render::Configuration*)cfg);
//
//	this->render = new DDEX::Render::Render(context, ventana, tmp, (DDEX::Render::Configuration*)cfg);
//
//	this->uiComponentManager = new DDEX::UIComponentManager(render->GetHdcFactory());
//	this->uiCursorManager = new DDEX::UICursorManager(this->uiComponentManager);
//	this->primitive = this->context->GetRenderPrimitive();
//	return 0;
//}
//
//__int32 OldDDexAdapter::DDExCargarFuenteX(__int8 * nombre, __int32 tam, __int32 negrita, __int32 cursiva, __int32 id)
//{
//	wchar_t tmp[0x1FF];
//	memset(tmp, 0, 0x1FF * 2);
//	mbstowcs(tmp, nombre, strlen(nombre));
//	return this->render->MakeFont(tmp, tam, negrita, cursiva, id);
//}
//
//__int32 OldDDexAdapter::DDExSaveImage(HWND hwnd, char * filename, __int32 imageType)
//{
//	wchar_t tmp[0x1FF];
//	memset(tmp, 0, 0x1FF * 2);
//	mbstowcs(tmp, filename, strlen(filename));
//	this->context->GetScreenShotManager()->ScreenShot(hwnd, tmp, imageType);
//	return 0;
//}
//
//__int32 OldDDexAdapter::DDExDibujarPantalla()
//{
//
//	this->render->ClearPresentEffect(-1);
//	for (size_t i = 0; i < MAX_PRESENTEFFECTS; i++)
//	{
//		if (this->presentEffects[i].enabled == true) {
//			switch (i)
//			{
//			case 1:
//				this->render->SetPresentEffect((int)DDEX::Layers::LayerEffects::SHAKE, (DDEX::Render::EffectParameters*)this->presentEffects[i].data);
//				break;
//			case 2:
//				this->render->SetPresentEffect((int)DDEX::Layers::LayerEffects::GREY, (DDEX::Render::EffectParameters*)this->presentEffects[i].data);
//				break;
//
//
//			default:
//				break;
//			}
//		}
//	}
//
//
//	this->render->Present();
//	return 0;
//}
//
//__int32 OldDDexAdapter::DDExSetRenderEffect(__int32 effect, void * data)
//{
//	this->render->SetRenderEffect(effect, (DDEX::Render::EffectParameters*)data);
//	return 0;
//}
//
//__int32 OldDDexAdapter::DDExFlushScreen()
//{
//	this->render->FlushScreen();
//	return 0;
//}
//
//__int32 OldDDexAdapter::DDExFlushBackground()
//{
//	this->render->FlushBackground();
//	return 0;
//}
//
//__int32 OldDDexAdapter::DDExDibujarTexto(char * texto, __int32 x, __int32 y, DDEXARGB * c, __int32 f)
//{
//	wchar_t tmp[0x1FF];
//	memset(tmp, 0, 0x1FF * 2);
//	mbstowcs(tmp, texto, strlen(texto));
//	this->render->Draw(tmp, f, x, y, (DDEX::Render::RenderColor*)c);
//	return 0;
//}
//
//__int32 OldDDexAdapter::DDExDibujarPantallaEx(RECT * entrada, RECT * salida, HWND ventana)
//{
//	this->render->Present(ventana, entrada, salida);
//	return 0;
//}
//
//__int32 OldDDexAdapter::DDExLimpiarPantalla()
//{
//	this->render->CleanScreen();
//	return 0;
//}
//
//__int32 OldDDexAdapter::DDExDibujarCaja(RECT * r, DDEXARGB * c, __int32 angulo)
//{
//	this->primitive->DrawBox(r, (DDEX::Render::RenderColor*)c);
//	return 0;
//}
//
//void OldDDexAdapter::SetGetFileBytes(FuncGetFileBytes func)
//{
//	this->render->ImageManager_SetGetFileBytes((DDEX::Render::FuncGetFileBytes) func);
//}
//
//__int32 OldDDexAdapter::GetHDCFont(__int32 font)
//{
//	return (__int32)this->render->GetFontDC(font);
//}
//
//__int32 OldDDexAdapter::DDExTerminar()
//{
//	return 0;
//}
//
//__int32 OldDDexAdapter::DDExDibujarRGraficoAlphaPos(__int32 archivo, RECT * r, __int32 x, __int32 y, DDEXARGB * c)
//{
//	return 0;
//}
//
//__int32 OldDDexAdapter::DDExDibujarGrafico(__int32 archivo, RECT * r, __int32 x, __int32 y, DDEXARGB * c, __int32 angulo)
//{
//	this->render->Draw(archivo, x, y, r, (DDEX::Render::RenderColor*)c, angulo);
//	return 0;
//}
//
//void OldDDexAdapter::DDEXCleanLights()
//{
//	this->render->CleanLights();
//}
//
//void OldDDexAdapter::DDEXSetLight(DDEXLIGHTDRAW * d)
//{
//	this->render->SetLight((DDEX::Render::LightDraw*)d);
//}
//
//void OldDDexAdapter::SetMastherLight(__int32 redLight, __int32 greenLight, __int32 blueLight)
//{
//	this->render->SetMastherLight(redLight, greenLight, blueLight);
//
//}
//
//
//void * __stdcall DDEX_Create() {
//
//	return new OldDDexAdapter();
//}


void * __stdcall DDEX_Create() {

	return nullptr;
}