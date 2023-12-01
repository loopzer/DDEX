#pragma once
#ifndef _ILAYER_H
#define _ILAYER_H

#include <Windows.h>
#include "LayerDeclares.h"

namespace DDEX {
	namespace Layers {
		class ILayer
		{

		public:
			void * Get() {
				return this->resource;
			}
			void Bind() {
				this->Bind(0.0f, 0.0f, 0.0f, 0.0f);
			}

			virtual void Bind(float red, float green, float blue, float alpha) = 0;

			virtual ~ILayer() {
			}

			virtual void SaveToFile(wchar_t * filename) = 0;

		protected:

			void * resource;

			RECT layerSize;
			LAYERTYPE layerType;
		};
	};
};
#endif

