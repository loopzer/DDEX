#pragma once
#ifndef _LAYERDECLARES_H
#define _LAYERDECLARES_H

#include "..\Render\RenderDeclares.h"
namespace DDEX {
	namespace Layers {
#if !ISXP 
		enum class LayerEffects {
#else
		enum LayerEffects {
#endif
			DEFAULT,
			INVERTCOLOR,
			GREY,
			RED,
			GREEN,
			BLUE,
			INVERTTEXTURE,
			RELIEF,
			VIBRATIONFULL,
			VIBRATIONSIMPLE,
			SHAKE,
			DRUNK,
			FLASH,
			RELIEFCOLOR,
			BLUR,
			LAYEREFFECTS_ENUMSIZE
		};
#define MAX_LAYERSEFFECT 0xFF
#define MAX_CUSTOM_LAYERS 0xFF
#if !ISXP 
		enum class LAYERTYPE {
#else
		enum LAYERTYPE {
#endif
			BACKGROUND, MIDDLE, LIGHT, EFFECT1, EFFECT2, TOP, LAYERTYPE_ENUMSIZE
		};

		struct sLayerEffectState {
			bool isActive;
			Render::EffectParameters params;
		};

		typedef struct sLayerEffectState LayerEffectState;
	};
};
#endif