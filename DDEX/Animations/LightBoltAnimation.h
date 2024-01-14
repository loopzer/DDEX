#pragma once
#ifndef _LIGHTBOLTANIMATION_H
#define _LIGHTBOLTANIMATION_H

#define NOMINMAX

#include <Windows.h>
#include "../Render/RenderDeclares.h"
#include "../Render/Colors.h"
#include "../Render/IPSManager.h"
#include "../Render/ISprite.h"
#include "../Render/ImageManager.h"
#include <math.h>
#include "AnimationDeclares.h"
#include "IAnimation.h"
#include "../ColorAnimation.h"

namespace DDEX {
	namespace Animations {
		class LightBoltAnimation :public IAnimation
		{

		public:
			LightBoltAnimation(AnimationLightBoltData * data) {
				this->count = data->positionsCount;
				memcpy(this->positions, data->positions, sizeof(PositionXY)*count);

				this->color = data->color;
				this->duration = data->duration;

				this->MakeSegments();
			}

			virtual void Start(int ticks) {
				this->colorAimation = new ColorAnimation(this->color, Render::RenderColor(0, 0, 0), this->duration, false);
				this->colorAimation->Start(ticks);
			}

			virtual	void Draw(Render::IPSManager * ps, Render::ImageManager * im) {
				this->imageManager = im;

				this->sprite = ps->BeginLight();

				for (size_t i = 0; i < this->segmentsCount; i++)
				{
					this->DrawSegment(this->segments[i]);
				}

				this->sprite->End();

			}

			virtual	void Update(int ticks) {
				if (this->colorAimation != NULL) {
					this->colorAimation->Tick(ticks);
					this->lightColor = this->colorAimation->GetColor();
				}
			}

			virtual bool IsValid() {
				if (this->colorAimation == NULL) {
					return false;
				}

				if (this->colorAimation->IsComplete()) {
					return false;
				}

				return true;
			}

			virtual ~LightBoltAnimation() {
				delete this->colorAimation;
			}

		protected:
			LightBoltAnimation() {
			}

			Render::RenderColor color;
			__int32 duration;

			ColorAnimation * colorAimation;

			typedef struct {
				Render::Vector2 startPosition;
				Render::Vector2 endPosition;
				float theta;

				Render::Vector2 startScaling;
				Render::Vector2 startCenterScaling;
				Render::Vector2 startCenter;

				Render::Vector2 middleScaling;
				Render::Vector2 middleCenterScaling;
				Render::Vector2 middleCenter;

				Render::Vector2 endScaling;
				Render::Vector2 endCenterScaling;
				Render::Vector2 endCenter;

				float startAngle;
				float middleAngle;
				float endAngle;

			} Segment;

			Segment segments[0xFFF];
			int segmentsCount;

			Render::RenderColor lightColor;

			PositionXY positions[0xFFF];
			Render::ISprite * sprite;
			Render::ImageManager * imageManager;
			int count;

			void MakeSegments() {

				this->segmentsCount = 0;
				for (size_t i = 1; i < this->count; i++)
				{
					this->MakeSegment((float)this->positions[i - 1].x, (float)this->positions[i - 1].y, (float)this->positions[i].x, (float)this->positions[i].y, this->segments[this->segmentsCount]);
					this->segmentsCount++;
				}
			}

			void MakeSegment(float x1, float y1, float x2, float y2, Segment& segment) {
				Render::Vector2 startPosition;
				Render::Vector2 tangent;
				Render::Vector2 endPosition;

				float height = 0.2f;

				startPosition.x = x1;
				startPosition.y = y1;

				endPosition.x = x2;
				endPosition.y = y2;

				tangent.x = endPosition.x - startPosition.x;
				tangent.y = endPosition.y - startPosition.y;

				Render::Vector2 middleScaling;
				middleScaling.x = tangent.Distance();
				middleScaling.y = 1.0f *height;

				Render::Vector2 middleCenterScaling;
				middleCenterScaling.x = 0.0f;
				middleCenterScaling.y = 64.0f;

				Render::Vector2 middleCenter;
				middleCenter.x = 0.0f;
				middleCenter.y = 64.0f;

				Render::Vector2 startScaling;
				startScaling.x = 1.0f;
				startScaling.y = 1.0f;

				Render::Vector2 startCenterScaling;
				startCenterScaling.x = 0.0f;
				startCenterScaling.y = 64.0f;

				Render::Vector2 startCenter;
				startCenter.x = 0.0f;
				startCenter.y = 64.0f;

				Render::Vector2 endScaling;
				endScaling.x = 1.0f;
				endScaling.y = 1.0f;

				Render::Vector2 endCenterScaling;
				endCenterScaling.x = 0.0f;
				endCenterScaling.y = 64.0f;

				Render::Vector2 endCenter;
				endCenter.x = 0.0f;
				endCenter.y = 64.0f;

				float theta = (float)atan2((double)tangent.y, (double)tangent.x);

				startScaling *= height;
				endScaling *= height;

				segment.startPosition = startPosition;
				segment.endPosition = endPosition;

				segment.startCenter = startCenter;
				segment.startCenterScaling = startCenterScaling;
				segment.startScaling = startScaling;

				segment.middleCenter = middleCenter;
				segment.middleCenterScaling = middleCenterScaling;
				segment.middleScaling = middleScaling;

				segment.endCenter = endCenter;
				segment.endCenterScaling = endCenterScaling;
				segment.endScaling = endScaling;

				segment.theta = theta;

				segment.startAngle = (theta + 3.1416) * 1000;
				segment.middleAngle = theta * 1000;
				segment.endAngle = theta * 1000;

			}

			void DrawSegment(Segment& segment) {
				this->sprite->Draw(this->imageManager->GetImage(5556), &segment.startPosition, &segment.middleScaling, &segment.middleCenter, &segment.middleCenterScaling, &this->lightColor, segment.middleAngle);
				this->sprite->Draw(this->imageManager->GetImage(5557), &segment.startPosition, &segment.startScaling, &segment.startCenter, &segment.startCenterScaling, &this->lightColor, segment.startAngle);
				this->sprite->Draw(this->imageManager->GetImage(5557), &segment.endPosition, &segment.endScaling, &segment.endCenter, &segment.endCenterScaling, &this->lightColor, segment.endAngle);
			}

			void DrawSegment(float x1, float y1, float x2, float y2) {
				Render::Vector2 startPosition;
				Render::Vector2 tangent;
				Render::Vector2 endPosition;

				float height = 0.1f;

				startPosition.x = x1;
				startPosition.y = y1;

				endPosition.x = x2;
				endPosition.y = y2;

				tangent.x = endPosition.x - startPosition.x;
				tangent.y = endPosition.y - startPosition.y;

				Render::Vector2 middleScaling;
				middleScaling.x = tangent.Distance();
				middleScaling.y = 1.0f *height;

				Render::Vector2 middleCenterScaling;
				middleCenterScaling.x = 0.0f;
				middleCenterScaling.y = 64.0f;

				Render::Vector2 middleCenter;
				middleCenter.x = 0.0f;
				middleCenter.y = 64.0f;

				Render::Vector2 startScaling;
				startScaling.x = 1.0f;
				startScaling.y = 1.0f;

				Render::Vector2 startCenterScaling;
				startCenterScaling.x = 0.0f;
				startCenterScaling.y = 64.0f;

				Render::Vector2 startCenter;
				startCenter.x = 0.0f;
				startCenter.y = 64.0f;

				Render::Vector2 endScaling;
				endScaling.x = 1.0f;
				endScaling.y = 1.0f;

				Render::Vector2 endCenterScaling;
				endCenterScaling.x = 0.0f;
				endCenterScaling.y = 64.0f;

				Render::Vector2 endCenter;
				endCenter.x = 0.0f;
				endCenter.y = 64.0f;

				float theta = (float)atan2((double)tangent.y, (double)tangent.x);

				startScaling *= height;
				endScaling *= height;

				Render::RenderColor color(255, 0, 255);

				color.a = 255;

				this->sprite->Draw(this->imageManager->GetImage(5556), &startPosition, &middleScaling, &middleCenter, &middleCenterScaling, &color, theta * 1000);
				this->sprite->Draw(this->imageManager->GetImage(5557), &startPosition, &startScaling, &startCenter, &startCenterScaling, &color, (theta + 3.1416) * 1000);
				this->sprite->Draw(this->imageManager->GetImage(5557), &endPosition, &endScaling, &endCenter, &endCenterScaling, &color, (theta) * 1000);

				color = Render::Colors::White;

				color.a = 50;

				this->sprite->Draw(this->imageManager->GetImage(5556), &startPosition, &middleScaling, &middleCenter, &middleCenterScaling, &color, theta * 1000);
				this->sprite->Draw(this->imageManager->GetImage(5557), &startPosition, &startScaling, &startCenter, &startCenterScaling, &color, (theta + 3.1416) * 1000);
				this->sprite->Draw(this->imageManager->GetImage(5557), &endPosition, &endScaling, &endCenter, &endCenterScaling, &color, (theta) * 1000);

			}
		};
	};
};
#endif