#pragma once
#ifndef _LAYEREFFECTORCHESTRATOR_H
#define _LAYEREFFECTORCHESTRATOR_H

#include <Windows.h>
#include <functional>
#include "LayerDeclares.h"
#include "ILayerEffect.h"
#include "LayerManager.h"
#include "LayerEffectManager.h"
namespace DDEX {
	namespace Layers {

		class LayerEffectOrchestrator {
		public:

			LayerEffectOrchestrator(LayerEffectManager * manager) {
				this->manager = manager;
				for (int i = 0; i < (int)LayerEffects::LAYEREFFECTS_ENUMSIZE; i++)
				{
					this->layersEffects[i].isActive = false;
				}
			}

			ILayer * Process(ILayer * layer) {
				ILayer * returnLayer = layer;
				ILayerEffect * layerEffect;
				for (int i = 0; i < (int)LayerEffects::LAYEREFFECTS_ENUMSIZE; i++)
				{
					if (this->layersEffects[i].isActive) {
						layerEffect = this->manager->Get((LayerEffects)i);
						if (layerEffect != NULL) {
							layerEffect->Process(returnLayer, &this->layersEffects[i].params);
							returnLayer = layerEffect->GetLayer();
						}
					}
				}

				return returnLayer;
			}

			void Enable(LayerEffects effect) {
				this->layersEffects[(int)effect].isActive = true;
			}

			void Enable(LayerEffects effect, void * data) {
				this->layersEffects[(int)effect].isActive = true;
				if (data == NULL) {
					ZeroMemory(&this->layersEffects[(int)effect].params, sizeof(Render::EffectParameters));
				}
				else
				{
					memcpy(&this->layersEffects[(int)effect].params, data, sizeof(Render::EffectParameters));
				}
			}

			void Disable(LayerEffects effect) {
				this->layersEffects[(int)effect].isActive = false;
			}

			void DisableAll() {
				for (int i = 0; i < (int)LayerEffects::LAYEREFFECTS_ENUMSIZE; i++)
				{
					this->layersEffects[i].isActive = false;
				}
			}

		protected:
			LayerEffectManager * manager;
			LayerEffectState layersEffects[(int)LayerEffects::LAYEREFFECTS_ENUMSIZE];
		};
	};
};
#endif