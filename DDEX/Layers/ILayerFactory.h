#pragma once
#ifndef _ILAYERFACTORY_H
#define _ILAYERFACTORY_H
#define NOMINMAX

#include <Windows.h>
#include <functional>
#include "LayerDeclares.h"
#include "ILayer.h"
namespace DDEX {
	namespace Layers {
		class ILayerFactory
		{

		public:

			virtual ILayer * Make(LAYERTYPE layerType) = 0;
			virtual ~ILayerFactory() {
			}
		protected:

			RECT layerSize;

		};
	};
};
#endif