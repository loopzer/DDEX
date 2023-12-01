#pragma once

#ifndef _RENDERBASE_H
#define _RENDERBASE_H

#include <Windows.h>
#include <math.h>
#include "RenderDeclares.h"

#include "IImageFactory.h"
#include "ImageManager.h"

#include "IPSManager.h"
#include "ISprite.h"
#include "IRenderPrimitive.h"

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


#include "../ContextBase.h"
#include "../Animations/AnimationDeclares.h"
#include "../Animations/IAnimation.h"
#include "../Animations/AnimationManager.h"
#include "../Animations/IAnimationFactory.h"
#include "../Animations/AnimationFactory.h"

#include "../UI/UI.h"
#include "../UI/IHDCFactory.h"

namespace DDEX {
	namespace Render {
		class RenderBase
		{
		protected:

			ContextBase * context;
			IPSManager * psManager;
			ISprite * sprite;
			ImageManager * imageManager;

			FontManager * fontManager;
			Layers::LayerManager* layerManager;
			Layers::LayerEffectFactory * layerEffectFactory;
			Layers::LayerEffectManager * layerEffectManager;
			Layers::LayerEffectOrchestrator * layerEffectOrchestrator;
			IScreenShotManager * screenShotManager;
			IRenderPrimitive * renderPrimitive;
			IHDCFactory * hdcFactory;
			Animations::IAnimationFactory * animationFactory;
			Animations::AnimationManager * animationManager;

			PresentEffect presentEffects[(int)Layers::LayerEffects::LAYEREFFECTS_ENUMSIZE];
			float masterRedLight;
			float masterGreenLight;
			float masterBlueLight;

			LightDraw lights[MAX_LIGHTS];
			int currentLights;

			HWND window;
			RECT layerSize;

			void DrawLights() {
				this->layerManager->Get(Layers::LAYERTYPE::LIGHT)->Bind(this->masterRedLight / 255.0f, this->masterGreenLight / 255.0f, this->masterBlueLight / 255.0f, 1.0f);
				this->sprite = this->psManager->BeginLight();

				for (int i = 0; i < this->currentLights; i++) {
					if (this->lights[i].type == 0) {
						this->DrawLight(&this->lights[i]);
					}
				}

				this->sprite->End();
				EffectParameters m;
				float f[3];
				f[0] = this->masterRedLight / 255.0f;
				f[1] = this->masterGreenLight / 255.0f;
				f[2] = this->masterBlueLight / 255.0f;

				memcpy(&m, f, sizeof(float) * 3);

				this->sprite = this->psManager->Begin(PSEffects::NEGATIVELIGHT, &m);

				for (int i = 0; i < this->currentLights; i++) {
					if (this->lights[i].type == 1) {
						this->DrawNegativeLight(&this->lights[i]);
					}
				}

				this->sprite->End();
			}

			void DrawNegativeLight(LightDraw * l) {
				void * resource = this->imageManager->GetImage(l->texture);
				if (resource != NULL) {
					this->sprite->DrawLight(resource, l->rect.left, l->rect.top, &l->rect, &l->color, 0);
				}
			}

			void DrawLight(LightDraw * l) {
				void * resource = this->imageManager->GetImage(l->texture);
				if (resource != NULL) {
					this->sprite->DrawLight(resource, l->rect.left, l->rect.top, &l->rect, &l->color, 0);
				}
			}

			Layers::ILayer * MakeFrame() {
				Layers::ILayer * outLayer;

				this->sprite->End();


				//this->layerManager->Get(Layers::LAYERTYPE::TOP)->SaveToFile(L"TOP.bmp");
				this->DrawLights();

				this->layerManager->Get(Layers::LAYERTYPE::EFFECT1)->Bind();
				this->sprite = this->psManager->Begin(PSEffects::SWAP);

				//this->sprite->Draw(this->layerManager->Get(Layers::LAYERTYPE::BACKGROUND)->Get(), 0, 0, &this->layerSize, &Colors::White, 0);
				this->sprite->Draw(this->layerManager->Get(Layers::LAYERTYPE::MIDDLE)->Get(), 0, 0, &this->layerSize, &Colors::White, 0);
				this->sprite->End();
				/*
				static int mm = 0;
				WCHAR outp[0xFF];
				wsprintf(outp, L"Back %d.bmp", mm);
				this->layerManager->Get(Layers::LAYERTYPE::BACKGROUND)->SaveToFile(outp);
				wsprintf(outp, L"Mmiddle %d.bmp", mm);
				this->layerManager->Get(Layers::LAYERTYPE::MIDDLE)->SaveToFile(outp);
				wsprintf(outp, L"Effect1 %d.bmp", mm);
				this->layerManager->Get(Layers::LAYERTYPE::EFFECT1)->SaveToFile(outp);
				mm++;
				*/
				//this->layerManager->Get(Layers::LAYERTYPE::EFFECT1)->SaveToFile(L"EFFECT1.bmp");

				this->layerManager->Get(Layers::LAYERTYPE::EFFECT2)->Bind();
				this->psManager->SwapLight(
					this->layerManager->Get(Layers::LAYERTYPE::EFFECT1)->Get(),
					this->layerManager->Get(Layers::LAYERTYPE::LIGHT)->Get(),
					&this->layerSize
				);

				this->animationManager->UpdateAll();

				this->animationManager->DrawAll(this->psManager, this->imageManager);

				this->layerEffectOrchestrator->DisableAll();
				for (size_t i = 0; i < (int)Layers::LayerEffects::LAYEREFFECTS_ENUMSIZE; i++)
				{
					if (this->presentEffects[i].enabled) {
						this->layerEffectOrchestrator->Enable((Layers::LayerEffects)i, this->presentEffects[i].data);
					}
				}

				outLayer = this->layerEffectOrchestrator->Process(this->layerManager->Get(Layers::LAYERTYPE::EFFECT2));

				this->layerManager->Get(Layers::LAYERTYPE::EFFECT1)->Bind();
				this->sprite = this->psManager->Begin(PSEffects::SWAP);
				this->sprite->Draw(outLayer->Get(), 0, 0, &this->layerSize, &Colors::White, 0);
				this->sprite->Draw(this->layerManager->Get(Layers::LAYERTYPE::TOP)->Get(), 0, 0, &this->layerSize, &Colors::White, 0);
				this->sprite->End();
				/*
				static int mm = 0;
				WCHAR outp[0xFF];
				wsprintf(outp, L"%d.bmp", mm++);
				outLayer->SaveToFile(outp);
				*/
				this->imageManager->Tick();

				return this->layerManager->Get(Layers::LAYERTYPE::EFFECT1);
			}
		public:

			void SetRenderEffect(__int32 effect, EffectParameters * data) {
				this->sprite->End();
				this->sprite = this->psManager->Begin((PSEffects)effect, data);
			}

			void SetPresentEffect(__int32 effect, EffectParameters * data) {
				if (effect < (int)Layers::LayerEffects::LAYEREFFECTS_ENUMSIZE) {
					this->presentEffects[effect].enabled = true;
					memcpy(this->presentEffects[effect].data, data, sizeof(EffectParameters));
				}
			};
			void ClearPresentEffect(__int32 effect) {
				if (effect == -1) {
					for (int i = 0; i < (int)Layers::LayerEffects::LAYEREFFECTS_ENUMSIZE; i++)
					{
						this->presentEffects[i].enabled = false;
						ZeroMemory(this->presentEffects[i].data, sizeof(EffectParameters));
					}
				}
				else
				{
					this->presentEffects[effect].enabled = false;
					ZeroMemory(this->presentEffects[effect].data, sizeof(EffectParameters));
				}

			};

			void CleanLights() {
				this->currentLights = 0;
			}
			void SetLight(LightDraw * d) {
				if (this->currentLights >= MAX_LIGHTS) {
					return;
				}

				this->lights[this->currentLights] = *d;
				this->currentLights++;
			}

			void SetMastherLight(float redLight, float greenLight, float blueLight) {
				this->masterRedLight = redLight;
				this->masterGreenLight = greenLight;
				this->masterBlueLight = blueLight;
			}

			RenderBase(ContextBase * context, HWND window, char * imageFolder, Configuration * cfg) {
				this->context = context;
				this->window = window;

				RECT mainRect;

				GetWindowRect(window, &mainRect);

				int width = abs(mainRect.right - mainRect.left);
				int heigth = abs(mainRect.top - mainRect.bottom);

				this->layerSize.top = 0;
				this->layerSize.left = 0;
				this->layerSize.right = width;
				this->layerSize.bottom = heigth;

				/*Construct abstract objects*/
				this->imageManager = new ImageManager(context->GetImageFactory(), imageFolder);

				this->fontManager = new FontManager(context->GetFontFactory());

				this->layerManager = new Layers::LayerManager(context->GetLayerFactory());

				this->screenShotManager = context->GetScreenShotManager();

				this->psManager = context->GetPSManager();

				this->layerEffectFactory = new Layers::LayerEffectFactory(this->layerManager, this->psManager, this->layerSize);

				this->layerEffectManager = new Layers::LayerEffectManager(this->layerEffectFactory);

				this->layerEffectOrchestrator = new Layers::LayerEffectOrchestrator(this->layerEffectManager);

				for (int i = 0; i < (int)Layers::LayerEffects::LAYEREFFECTS_ENUMSIZE; i++)
				{
					this->presentEffects[i].enabled = false;
				}

				this->animationFactory = new Animations::AnimationFactory();

				this->animationManager = new Animations::AnimationManager();

				this->renderPrimitive = context->GetRenderPrimitive();

				this->hdcFactory = context->GetHdcFactory(this->imageManager);
			}

			void CleanScreen() {
				
				this->context->InitFrame();
				this->layerManager->Get(Layers::LAYERTYPE::BACKGROUND)->Bind();
				this->sprite = this->psManager->Begin();
			}

			void FlushBackground() {
				this->sprite->End();
				//this->layerManager->Get(Layers::LAYERTYPE::BACKGROUND)->SaveToFile(L"Back.bmp");
				this->layerManager->Get(Layers::LAYERTYPE::MIDDLE)->Bind();
				this->sprite = this->psManager->Begin();
				
				this->sprite->Draw(this->layerManager->Get(Layers::LAYERTYPE::BACKGROUND)->Get(), 0, 0, &this->layerSize, &Colors::White, 0);
				
				this->sprite->End();
				this->sprite = this->psManager->Begin();
			}

			void FlushScreen() {
				this->sprite->End();
				//this->layerManager->Get(Layers::LAYERTYPE::MIDDLE)->SaveToFile(L"MIDDLE.bmp");
				this->layerManager->Get(Layers::LAYERTYPE::TOP)->Bind();
				this->sprite = this->psManager->Begin();
			}

			void Present() {
				this->context->EndFrame(this->MakeFrame());
			}

			void Present(HWND window, RECT * source, RECT * dest) {
				this->context->EndFrame(this->MakeFrame(), window, source, dest);
			}

			void Draw(int imageNum, int x, int y, RECT * r, RenderColor * color) {
				void * resource = this->imageManager->GetImage(imageNum);
				if (resource != NULL) {
					this->sprite->Draw(resource, x, y, r, color, 0);
				}
			}

			void Draw(int imageNum, int x, int y, RECT * r, RenderColor * color, int angle) {
				void * resource = this->imageManager->GetImage(imageNum);
				if (resource != NULL) {
					this->sprite->Draw(resource, x, y, r, color, angle);
				}
			}

			void Draw(int imageNum, int x, int y, RECT * r, RECT * scale, RenderColor * color) {
				void * resource = this->imageManager->GetImage(imageNum);
				if (resource != NULL) {
					//this->sprite->Draw(resource, x, y, r, scale, color, 0);
				}
			}

			void Draw(char * text, int font, int x, int y, RenderColor * color) {
				IFont * rfont = this->fontManager->Get(font);

				if (rfont != NULL) {
					rfont->Draw(text, x, y, color);
				}
			}

			IHDCFactory * GetHdcFactory() {
				return this->hdcFactory;
			}

			HDC GetFontDC(int fontId) {
				IFont * font = this->fontManager->Get(fontId);

				if (font != NULL) {
					return font->GetHDC();
				}
				else
				{
					return 0;
				}
			}

			void ImageManager_SetGetFileBytes(FuncGetFileBytes func) {
				this->imageManager->SetGetFileBytes(func);
			}

			__int32 MakeFont(char * fontName, __int32 size, bool bold, bool italic, __int32 forcedId) {
				return this->fontManager->Make(fontName, size, bold, italic, forcedId);
			}

			Animations::IAnimation * MakeAnimation(__int32 type, void * data, __int32 dataCount) {
				Animations::AnimationType animationType;
				Animations::IAnimation *animation = NULL;
				if (type >= (__int32)Animations::AnimationType::ENUMSIZE) {
					return NULL;
				}

				animationType = (Animations::AnimationType)type;

				switch (animationType)
				{
				case DDEX::Animations::LIGTHBOLT:
					animation = this->animationFactory->MakeLigthBolt((Animations::AnimationLightBoltData*)data);
					break;

				case DDEX::Animations::LIGTHBOLTAUTOMATIC:
					animation = this->animationFactory->MakeLigthBoltAutomatic((Animations::AnimationLightBoltData*)data);
					break;

				default:
					break;
				}

				if (animation != NULL) {
					this->animationManager->Add(animation);
				}

				return animation;
			}

			void DeleteAnimation(Animations::IAnimation *animation) {
				if (animation != NULL) {
					this->animationManager->Remove(animation);
				}
			}

			ContextBase * GetContext() {
				return this->context;
			}

			virtual ~RenderBase() {
				delete this->imageManager;
				delete this->fontManager;
				delete this->layerManager;
				delete this->animationFactory;
				delete this->animationManager;
				delete this->context;
			}
		};
	};
};
#endif