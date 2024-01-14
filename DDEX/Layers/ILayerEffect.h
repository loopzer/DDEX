#pragma once
#ifndef _ILAYEREFFECT_H
#define _ILAYEREFFECT_H
#define NOMINMAX

#include <Windows.h>
#include "LayerManager.h"
#include "ILayer.h"
#include "..\Render\IPSManager.h"
namespace DDEX {
	namespace Layers {
		class ILayerEffect
		{

		public:
			ILayerEffect(LayerManager * lm, Render::IPSManager * ps, RECT layerSize) {
				this->lm = lm;
				this->ps = ps;
				this->layerSize = layerSize;
				this->layer = lm->Create();
			}

			ILayer * GetLayer() {
				return this->layer;
			}

			void Process(ILayer * baseLayer) {
				this->Process(baseLayer, NULL);
			}

			void Process(ILayer * baseLayer, Render::EffectParameters *data) {
				this->Process(baseLayer->Get(), data);
			}

			void Process(void * resource) {
				this->Process(resource, NULL);
			}

			virtual void Process(void * resource, Render::EffectParameters * data) = 0;

			virtual ~ILayerEffect() {
			}

		protected:

			ILayer * layer;
			RECT layerSize;
			LayerManager * lm;
			Render::IPSManager * ps;
		};
	};
};
#endif