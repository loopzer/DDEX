#pragma once

#ifndef _LAYERMANAGER_H
#define _LAYERMANAGER_H

#include <Windows.h>
#include <functional>
#include "LayerDeclares.h"
#include "ILayer.h"
#include "ILayerFactory.h"

namespace DDEX{
	namespace Layers {

	class LayerManager {
	public:
		LayerManager(ILayerFactory * factory) {
			this->factory = factory;
			for (size_t i = 0; i < MAX_CUSTOM_LAYERS; i++)
			{
				this->customLayers[i] = NULL;
			}
			this->MakeLayers();
		}

		void MakeLayers() {
			this->layers[(int)LAYERTYPE::BACKGROUND] = this->factory->Make(LAYERTYPE::BACKGROUND);
			this->layers[(int)LAYERTYPE::MIDDLE] = this->factory->Make(LAYERTYPE::MIDDLE);
			this->layers[(int)LAYERTYPE::LIGHT] = this->factory->Make(LAYERTYPE::LIGHT);
			this->layers[(int)LAYERTYPE::EFFECT1] = this->factory->Make(LAYERTYPE::EFFECT1);
			this->layers[(int)LAYERTYPE::EFFECT2] = this->factory->Make(LAYERTYPE::EFFECT2);
			this->layers[(int)LAYERTYPE::TOP] = this->factory->Make(LAYERTYPE::TOP);
		}

		ILayer * Get(LAYERTYPE layerType) {
			return this->layers[(int)layerType];
		}

		ILayer * Create() {
			for (size_t i = 0; i < MAX_CUSTOM_LAYERS; i++)
			{
				if (this->customLayers[i] == NULL) {
					this->customLayers[i] = this->factory->Make(LAYERTYPE::BACKGROUND);
					return this->customLayers[i];
				}
			}

			return NULL;
		}

		void Free(ILayer * layer) {
			for (size_t i = 0; i < MAX_CUSTOM_LAYERS; i++)
			{
				if (this->customLayers[i] == layer) {
					delete layer;
					this->customLayers[i] = NULL;
				}
			}
		}

		~LayerManager() {
			for (size_t i = 0; i < (int)LAYERTYPE::LAYERTYPE_ENUMSIZE; i++)
			{
				delete this->layers[i];
			}
			for (size_t i = 0; i < MAX_CUSTOM_LAYERS; i++)
			{
				if (this->customLayers[i] != NULL) {
					delete this->customLayers[i];
				}
			}
		}

	protected:
		RECT layerSize;
		ILayerFactory * factory;
		ILayer * layers[(int)LAYERTYPE::LAYERTYPE_ENUMSIZE];
		ILayer * customLayers[MAX_CUSTOM_LAYERS];

		void Init() {
			for (size_t i = 0; i < MAX_CUSTOM_LAYERS; i++)
			{
				this->customLayers[i] = NULL;
			}
		}

	};

	};
};
#endif