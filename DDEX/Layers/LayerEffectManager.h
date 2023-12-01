#pragma once
#ifndef _LAYEREFFECTMANAGER_H
#define _LAYEREFFECTMANAGER_H

#include <Windows.h>
#include "LayerDeclares.h"
#include "LayerManager.h"
#include "LayerEffectFactory.h"
namespace DDEX {
	namespace Layers {

		class LayerEffectManager {
		public:

			LayerEffectManager(LayerEffectFactory *factory) {
				this->factory = factory;
				this->MakeDefaultEffects();
			}

			void MakeDefaultEffects() {
				this->layerEffects[(int)LayerEffects::DEFAULT] = this->factory->Make(LayerEffects::DEFAULT);
				this->layerEffects[(int)LayerEffects::INVERTCOLOR] = this->factory->Make(LayerEffects::INVERTCOLOR);
				this->layerEffects[(int)LayerEffects::GREY] = this->factory->Make(LayerEffects::GREY);
				this->layerEffects[(int)LayerEffects::RED] = this->factory->Make(LayerEffects::RED);
				this->layerEffects[(int)LayerEffects::GREEN] = this->factory->Make(LayerEffects::GREEN);
				this->layerEffects[(int)LayerEffects::BLUE] = this->factory->Make(LayerEffects::BLUE);
				this->layerEffects[(int)LayerEffects::INVERTTEXTURE] = this->factory->Make(LayerEffects::INVERTTEXTURE);
				this->layerEffects[(int)LayerEffects::RELIEF] = this->factory->Make(LayerEffects::RELIEF);
				this->layerEffects[(int)LayerEffects::VIBRATIONFULL] = this->factory->Make(LayerEffects::VIBRATIONFULL);
				this->layerEffects[(int)LayerEffects::VIBRATIONSIMPLE] = this->factory->Make(LayerEffects::VIBRATIONSIMPLE);
				this->layerEffects[(int)LayerEffects::SHAKE] = this->factory->Make(LayerEffects::SHAKE);
				this->layerEffects[(int)LayerEffects::DRUNK] = this->factory->Make(LayerEffects::DRUNK);
				this->layerEffects[(int)LayerEffects::FLASH] = this->factory->Make(LayerEffects::FLASH);
				this->layerEffects[(int)LayerEffects::RELIEFCOLOR] = this->factory->Make(LayerEffects::RELIEFCOLOR);
				this->layerEffects[(int)LayerEffects::BLUR] = this->factory->Make(LayerEffects::BLUR);
			}

			ILayerEffect * MakeLayerEffect(LayerEffects effect) {
				for (size_t i = 0; i < MAX_LAYERSEFFECT; i++)
				{
					if (this->layerEffects[i] == NULL) {
						this->layerEffects[i] = this->factory->Make(effect);
						return this->layerEffects[i];
					}
				}
				return NULL;
			}

			ILayerEffect * Get(LayerEffects layerEffect) {
				return this->layerEffects[(int)layerEffect];
			}

		protected:
			LayerEffectFactory *factory;
			ILayerEffect * layerEffects[MAX_LAYERSEFFECT];
		};
	};
};
#endif
