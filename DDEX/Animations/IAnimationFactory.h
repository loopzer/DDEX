#pragma once
#ifndef _IANIMATIONFACTORY_H
#define _IANIMATIONFACTORY_H

#define NOMINMAX

#include <Windows.h>
#include "AnimationDeclares.h"
#include "IAnimation.h"
namespace DDEX {
	namespace Animations {
		class IAnimationFactory
		{

		public:

			virtual IAnimation * MakeLigthBolt(AnimationLightBoltData * data) = 0;
			virtual IAnimation * MakeLigthBoltAutomatic(AnimationLightBoltData * data) = 0;
			virtual ~IAnimationFactory() {
			}
		protected:

		};
	};
};
#endif