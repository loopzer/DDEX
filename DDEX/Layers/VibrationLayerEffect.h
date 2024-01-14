#pragma once
#ifndef _VIBRATIONLAYEREFFECT_H
#define _VIBRATIONLAYEREFFECT_H
#define NOMINMAX

#include <Windows.h>
#include <functional>
#include "..\Render\Colors.h"
#include "LayerManager.h"
#include "ILayerEffect.h"
#include "..\Render\RenderDeclares.h"
#include "..\Render\IPSManager.h"
#include "..\Render\ISprite.h"

namespace DDEX {
	namespace Layers
	{

		struct sVibrationData
		{
			int xoffset;
			int yoffset;
			int alpha;
		};

		typedef struct sVibrationData VibrationData;

		class VibrationLayerEffect :public ILayerEffect
		{

		public:

			VibrationLayerEffect(LayerManager * lm, Render::IPSManager * ps, RECT layerSize, VibrationData * vibrationData, int vibrationDataSize)
				: ILayerEffect(lm, ps, layerSize)
			{
				this->vibrationDataSize = vibrationDataSize;

				for (int i = 0; i < vibrationDataSize; i++)
				{
					this->data[i] = vibrationData[i];
				}
			}


			virtual void Process(void * resource, Render::EffectParameters * data) {

				VibrationData current;

				this->layer->Bind();

				Render::ISprite * sprite = this->ps->Begin(Render::PSEffects::DEFAULT);

				int x;
				int y;

				x = 0;
				y = 0;

				sprite->Draw(resource, x, y, &this->layerSize, &Render::Colors::White, 0);

				for (int i = 0; i < vibrationDataSize; i++)
				{
					current = this->data[i];

					x = current.yoffset;
					y = current.yoffset;

					Render::RenderColor c;

					c.a = current.alpha;
					c.r = current.alpha;
					c.g = current.alpha;
					c.b = current.alpha;

					sprite->Draw(resource, x, y, &this->layerSize, &c, 0);

				}

				sprite->End();
			}

			~VibrationLayerEffect() {

			}

		protected:

			VibrationData data[0x0F];
			int vibrationDataSize;
		};
	};
};
#endif