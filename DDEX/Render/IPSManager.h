#pragma once
#ifndef _IPSMANAGER_H
#define _IPSMANAGER_H

#include <Windows.h>
#include "RenderDeclares.h"
#include "ISprite.h"
namespace DDEX {
	namespace Render {
		class IPSManager
		{
		public:
			virtual ISprite * BeginLight() = 0;

			virtual ISprite * Begin(PSEffects effect, EffectParameters * data) = 0;

			virtual ISprite * Begin(void * resource, PSEffects effect, EffectParameters * data) = 0;

			virtual ISprite * Begin() {
				return this->Begin(PSEffects::DEFAULT);
			}
			virtual ISprite * Begin(PSEffects effect) {
				return this->Begin(effect, 0);
			}

			virtual void SwapLight(void * base, void * light, RECT * layerSize) = 0;

			virtual ~IPSManager() {
			}
		};
	};
};
#endif