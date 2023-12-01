#pragma once

#ifndef _SHAKELAYEREFFECT_H
#define _SHAKELAYEREFFECT_H

#include <Windows.h>
#include <functional>
#include "LayerManager.h"
#include "ILayerEffect.h"
#include "..\Render\RenderDeclares.h"
#include "..\Render\Colors.h"
#include "..\Render\IPSManager.h"
#include "..\Render\ISprite.h"

namespace DDEX {
	namespace Layers {


		class ShakeLayerEffect :public ILayerEffect
		{

		public:
			ShakeLayerEffect(LayerManager * lm, Render::IPSManager * ps, RECT layerSize)
				: ILayerEffect(lm, ps, layerSize)
			{
			}

			void Process(void * resource, Render::EffectParameters * data) {
				int x;
				int y;

				x = (rand() % 10) - 5;
				y = (rand() % 10) - 5;

				this->layer->Bind();

				Render::ISprite * sprite = this->ps->Begin(Render::PSEffects::SWAP);

				sprite->Draw(resource, x, y, &this->layerSize, &Render::Colors::White, 0);

				sprite->End();

			}

			~ShakeLayerEffect() {

			}

		protected:

		};
	};
};
#endif