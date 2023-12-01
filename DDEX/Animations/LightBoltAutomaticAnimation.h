#pragma once
#ifndef _LIGHTBOLTAUTOMATICANIMATION_H
#define _LIGHTBOLTAUTOMATICANIMATION_H

#include <Windows.h>
#include "../Render/RenderDeclares.h"
#include "../Render/Colors.h"
#include "../Render/IPSManager.h"
#include "../Render/ISprite.h"
#include "../Render/ImageManager.h"
#include <math.h>
#include "AnimationDeclares.h"
#include "IAnimation.h"
#include "LightBoltAnimation.h"

namespace DDEX {
	namespace Animations {
		class LightBoltAutomaticAnimation :public LightBoltAnimation
		{

		public:
			void bubble_sort(float * list, long n)
			{
				long c, d;
				float t;
				for (c = 0; c < (n - 1); c++)
				{
					for (d = 0; d < n - c - 1; d++)
					{
						if (list[d] > list[d + 1])
						{
							/* Swapping */

							t = list[d];
							list[d] = list[d + 1];
							list[d + 1] = t;
						}
					}
				}
			}

			LightBoltAutomaticAnimation(AnimationLightBoltData * data) {

				this->count = 0;

				for (size_t i = 1; i < data->positionsCount; i++)
				{
					this->Create(&data->positions[i - 1], &data->positions[i]);
				}

				this->color = data->color;
				this->duration = data->duration;
				this->MakeSegments();
			}

			virtual ~LightBoltAutomaticAnimation() {
			}

		protected:

			void Create(PositionXY *from, PositionXY * to) {
				Render::Vector2 startPosition((float)from->x, (float)from->y - 64.0f);
				Render::Vector2 tangent;
				Render::Vector2 endPosition((float)to->x, (float)to->y - 64.0f);

				float height = 0.1f;

				tangent.x = endPosition.x - startPosition.x;
				tangent.y = endPosition.y - startPosition.y;

				float distance = tangent.Distance();

				int segmentlength = distance / 4;

				float randPositions[0xFF];
				randPositions[0] = 0;
				Render::Vector2 normal = Render::Vector2(tangent.y, -tangent.x).Normalize();
				for (size_t i = 1; i < segmentlength; i++)
				{
					randPositions[i] = static_cast <float> ((float)rand()) / static_cast <float> ((float)RAND_MAX);
				}

				bubble_sort(randPositions, segmentlength);

				const float Sway = 80.0f;
				const float Jaggedness = 1 / Sway;
				float prevDisplacement = 0;
				Render::Vector2 prevPoint = startPosition;

				this->positions[this->count++] = PositionXY(startPosition.x, startPosition.y);

				for (size_t i = 1; i < segmentlength; i++)
				{
					float pos = randPositions[i];

					float scale = (distance * Jaggedness) * (pos - randPositions[i - 1]);

					float envelope = pos > 0.95f ? 20 * (1 - pos) : 1;

					float displacement = -Sway + static_cast <float> (rand()) / (static_cast <float> (RAND_MAX / (Sway - -Sway)));
					displacement -= (displacement - prevDisplacement) * (1 - scale);
					displacement *= envelope;

					Render::Vector2 point = startPosition + (tangent* pos) + ((normal * displacement));

					this->positions[this->count - 1] = PositionXY(prevPoint.x, prevPoint.y);
					this->positions[this->count++] = PositionXY(point.x, point.y);
					prevPoint = point;
					prevDisplacement = displacement;
				}

				this->positions[this->count - 1] = PositionXY(prevPoint.x, prevPoint.y);
			}
		};
	};
};
#endif
