#pragma once
#ifndef _LAYEREFFECTFACTORY_H
#define _LAYEREFFECTFACTORY_H

#include <Windows.h>
#include <functional>
#include "LayerManager.h"
#include "Ilayer.h"
#include "ILayerEffect.h"
#include "..\Render\RenderDeclares.h"
#include "..\Render\IPSManager.h"
#include "ShakeLayerEffect.h"
#include "SimpleShaderLayerEffect.h"
#include "VibrationLayerEffect.h"
namespace DDEX {
	namespace Layers {
		class LayerEffectFactory {
		public:

			LayerEffectFactory(LayerManager * lm, Render::IPSManager * ps, RECT layerSize) {
				this->layerSize = layerSize;
				this->lm = lm;
				this->ps = ps;
			}

			ILayerEffect * Make(LayerEffects layerEffect) {
				VibrationData data[20];

				switch (layerEffect)
				{
				case LayerEffects::DEFAULT:
					return this->MakeSimpleShader(Render::PSEffects::DEFAULT);
				case LayerEffects::INVERTCOLOR:
					return this->MakeSimpleShader(Render::PSEffects::INVERTCOLOR);
				case LayerEffects::GREY:
					return this->MakeSimpleShader(Render::PSEffects::GREY);
				case LayerEffects::RED:
					return this->MakeSimpleShader(Render::PSEffects::RED);
				case LayerEffects::GREEN:
					return this->MakeSimpleShader(Render::PSEffects::GREEN);
				case LayerEffects::BLUE:
					return this->MakeSimpleShader(Render::PSEffects::BLUE);
				case LayerEffects::INVERTTEXTURE:
					return this->MakeSimpleShader(Render::PSEffects::INVERTTEXTURE);
				case LayerEffects::RELIEF:
					return this->MakeSimpleShader(Render::PSEffects::RELIEF);
				case LayerEffects::VIBRATIONFULL:

					data[0].xoffset = -1;
					data[0].yoffset = -1;
					data[0].alpha = 150;

					data[1].xoffset = -1;
					data[1].yoffset = +1;
					data[1].alpha = 150;

					data[2].xoffset = +1;
					data[2].yoffset = +1;
					data[2].alpha = 150;

					data[3].xoffset = +1;
					data[3].yoffset = -1;
					data[3].alpha = 150;

					return this->MakeVibration(data, 4);
					break;
				case LayerEffects::VIBRATIONSIMPLE:

					data[0].xoffset = -1;
					data[0].yoffset = -1;
					data[0].alpha = 150;
					return this->MakeVibration(data, 1);
					break;
				case LayerEffects::SHAKE:
					return this->MakeShake();
				case LayerEffects::DRUNK:
					break;
				case LayerEffects::FLASH:
					break;
				case LayerEffects::RELIEFCOLOR:
					break;
				case LayerEffects::BLUR:
					return this->MakeSimpleShader(Render::PSEffects::BLUR);
				case LayerEffects::LAYEREFFECTS_ENUMSIZE:
					break;
				default:
					break;
				}

				return this->MakeSimpleShader(Render::PSEffects::DEFAULT);
			}

			~LayerEffectFactory() {

			}
		protected:
			RECT layerSize;
			LayerManager * lm;
			Render::IPSManager * ps;


			SimpleShaderLayerEffect * MakeSimpleShader(Render::PSEffects effect) {
				return new SimpleShaderLayerEffect(this->lm, this->ps, this->layerSize, effect);
			}

			ShakeLayerEffect * MakeShake() {
				return new ShakeLayerEffect(this->lm, this->ps, this->layerSize);
			}

			VibrationLayerEffect * MakeVibration(VibrationData * vibrationData, int vibrationDataSize) {
				return new VibrationLayerEffect(this->lm, this->ps, this->layerSize, vibrationData, vibrationDataSize);
			}

		};

	};
};
#endif