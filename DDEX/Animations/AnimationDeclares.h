#pragma once
#ifndef _ANIMATIONDECLARES_H
#define _ANIMATIONDECLARES_H
#include "..\Render\RenderDeclares.h"
namespace DDEX {
	namespace Animations {

#define MAX_ANIMATIONS 0xFF

		struct PositionXYType {
			__int32 x;
			__int32 y;

			PositionXYType(__int32 _x, __int32 _y)
				:x(_x), y(_y) {
			}

			PositionXYType() {

			}
		};

		typedef struct PositionXYType PositionXY;

		typedef struct {
			Render::RenderColor color;
			__int32 duration;
			__int32 positionsCount;
			PositionXY * positions;
		} AnimationLightBoltData;

		enum AnimationType
		{
			LIGTHBOLT = 0,
			LIGTHBOLTAUTOMATIC,
			ENUMSIZE
		};
	};
};
#endif