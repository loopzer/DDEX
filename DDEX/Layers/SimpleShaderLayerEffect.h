#pragma once
#ifndef _SIMPLESHADERLAYEREFFECT_H
#define _SIMPLESHADERLAYEREFFECT_H
#define NOMINMAX

#include <Windows.h>
#include "LayerManager.h"
#include "ILayerEffect.h"
#include "..\Render\RenderDeclares.h"
#include "..\Render\IPSManager.h"
#include "..\Render\Colors.h"
#include "..\Render\ISprite.h"

namespace DDEX {
	namespace Layers {
		class SimpleShaderLayerEffect :public ILayerEffect
		{

		public:
			SimpleShaderLayerEffect(LayerManager * lm, Render::IPSManager * ps, RECT layerSize, Render::PSEffects effect)
				: ILayerEffect(lm, ps, layerSize)
			{
				this->effect = effect;
			}

			virtual void Process(void * resource, Render::EffectParameters * data) {
				this->layer->Bind();

				Render::ISprite * sprite = this->ps->Begin(this->effect, data);

				sprite->Draw(resource, 0, 0, &this->layerSize, &Render::Colors::White, 0);

				sprite->End();

			}

			~SimpleShaderLayerEffect() {

			}

		protected:
			Render::PSEffects effect;
		};
	};
};
#endif