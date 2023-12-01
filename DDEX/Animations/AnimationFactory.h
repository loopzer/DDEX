#pragma once
#ifndef _ANIMATIONFACTORY_H
#define _ANIMATIONFACTORY_H

#include <Windows.h>
#include "AnimationDeclares.h"
#include "IAnimation.h"
#include "IAnimationFactory.h"
#include "LightBoltAnimation.h"
#include "LightBoltAutomaticAnimation.h"
namespace DDEX {
	namespace Animations {
		class AnimationFactory : public IAnimationFactory
		{

		public:

			virtual IAnimation * MakeLigthBolt(AnimationLightBoltData * data) {
				return new LightBoltAnimation(data);
			}

			virtual IAnimation * MakeLigthBoltAutomatic(AnimationLightBoltData * data) {
				return new LightBoltAutomaticAnimation(data);
			}

			virtual ~AnimationFactory() {
			}
		protected:

		};
	};
};
#endif