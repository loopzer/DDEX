#pragma once
#ifndef _ANIMATIONMANAGER_H
#define _ANIMATIONMANAGER_H

#define NOMINMAX

#include <Windows.h>
#include "../Render/RenderDeclares.h"
#include "../Render/IPSManager.h"
#include "../Render/ISprite.h"
#include "../Render/ImageManager.h"
#include "IAnimation.h"

#include <list>

namespace DDEX {
	namespace Animations {
		class AnimationManager {
		public:

			AnimationManager() {

			}

			void Add(IAnimation * animation) {
				animation->Start(GetTickCount());
				this->animations.push_back(animation);
			}

			void Remove(IAnimation * animation) {
				delete animation;
			}

			void DrawAll(Render::IPSManager * ps, Render::ImageManager * im) {
				for each (IAnimation * var in this->animations)
				{
					var->Draw(ps, im);
				}
			}

			void UpdateAll() {
				int ticks = GetTickCount();

				std::list<IAnimation*> toRemove;

				for each (IAnimation * var in this->animations)
				{
					var->Update(ticks);
					if (!var->IsValid()) {
						toRemove.push_back(var);
					}
				}

				for each (IAnimation * var in toRemove)
				{
					this->animations.remove(var);
				}
			}

			~AnimationManager() {
				for each (IAnimation * var in this->animations)
				{
					delete var;
				}
			}
		protected:
			std::list<IAnimation*> animations;
		};
	};
};
#endif
