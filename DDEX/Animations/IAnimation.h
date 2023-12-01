#pragma once
#ifndef _IANIMATION_H
#define _IANIMATION_H

#include <Windows.h>

#include "../Render/RenderDeclares.h"
#include "../Render/IPSManager.h"
#include "../Render/ISprite.h"
#include "../Render/ImageManager.h"
namespace DDEX {
	namespace Animations {
		class IAnimation
		{

		public:
			virtual void Update(int ticks) = 0;

			virtual void Draw(Render::IPSManager * ps, Render::ImageManager * im) = 0;

			virtual void Start(int ticks) = 0;

			virtual bool IsValid() = 0;

			virtual ~IAnimation() {
			}

		protected:

		};
	};
};
#endif
