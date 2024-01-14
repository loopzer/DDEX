#pragma once
#ifndef _RENDERDECLARES_H
#define _RENDERDECLARES_H

#define NOMINMAX

#include <Windows.h>
#include <math.h>
namespace DDEX {
	namespace Render {
#if !ISXP 
		enum class PSEffects {
#else
		enum PSEffects {
#endif
			DEFAULT,
			INVERTCOLOR,
			GREY,
			RED,
			GREEN,
			BLUE,
			INVERTTEXTURE,
			RELIEF,
			SWINGING,
			WAVE,
			BLUR,
			CUSTOM,
			LIGHT,
			NEGATIVELIGHT,
			SWAP,
			ENUMSIZE
		};

		struct sConfiguration
		{
			__int8 vsync;
			__int8 holder;
			__int8 modo;
			__int8 modo2;
			__int8 memoryMode;
			__int8 isDefferal;
		};

		typedef struct sConfiguration Configuration;

		struct sRenderColor {
			unsigned __int8 b;
			unsigned __int8 g;
			unsigned __int8 r;
			unsigned __int8 a;

			sRenderColor() {
			}
			sRenderColor(unsigned __int8 all)
				:a(all), r(all), g(all), b(all) {

			}
			sRenderColor(unsigned __int8 _r, unsigned __int8 _g, unsigned __int8 _b)
				:a(255), r(_r), g(_g), b(_b) {
			}

			sRenderColor(int _r, int _g, int _b)
				:a(255), r((unsigned __int8)_r), g((unsigned __int8)_g), b((unsigned __int8)_b) {

			}

			sRenderColor(unsigned __int8 _a, unsigned __int8 _r, unsigned __int8 _g, unsigned __int8 _b)
				:a(_a), r(_r), g(_g), b(_b) {

			}

			sRenderColor(float _r, float _g, float _b)
				:a(255), r((unsigned __int8)(_r * 255)), g((unsigned __int8)(_g * 255)), b((unsigned __int8)(_b * 255)) {

			}
		};

		typedef struct sRenderColor RenderColor;

		struct sLightDraw {
			__int32 texture;
			__int8 type;
			RECT rect;
			RenderColor color;
		};

		typedef struct sLightDraw LightDraw;

		struct sPresentEffect {
			bool enabled;
			float data[4];
		};

		typedef struct sPresentEffect PresentEffect;

		struct  sFileData {
			__int32 fileNum;
			__int8 * bytes;
			__int32 size;
			__int32 fileType; // PNG BMP etc;
		};

		typedef struct sFileData FileData;

		typedef void(__stdcall * FuncGetFileBytes)(FileData * data);


		union uEffectParameters {
			float f[4];
			__int8 b[4];
			__int32 int32;
		};

		typedef uEffectParameters EffectParameters;

		struct Vector2Type {

			float x;
			float y;

			Vector2Type(float _x = 0.0f, float _y = 0.0f)
				:x(_x), y(_y) {

			}


			Vector2Type& operator*=(const float& a)
			{
				x *= a;
				y *= a;
				return *this;
			}

			Vector2Type operator+(const float& a)
			{
				return Vector2Type(this->x + a, this->y + a);
			}

			Vector2Type operator+(const Vector2Type& a)
			{
				return Vector2Type(this->x + a.x, this->y + a.y);
			}

			Vector2Type operator*(const float& a)
			{
				return Vector2Type(this->x * a, this->y * a);
			}

			void Set(float xValue, float yValue) {
				this->x = xValue; this->y = yValue;
			};

			Vector2Type& Normal() {

				float len = Length(); Set(x / len, y / len); return *this;
			}

			float Length() const { return sqrtf(x * x + y * y); }

			float LengthSquared() const { return x * x + y * y; }

			Vector2Type& Normalize()
			{
				if (Length() != 0)
				{
					float len = Length();
					x /= len; y /= len;
					return *this;
				}

				x = y = 0;
				return *this;

			}

			float Distance() {
				return sqrt(x * x + y * y);
			}
		};

		typedef struct Vector2Type Vector2;
#define MAX_LIGHTS 0xFFF
	};
};
#endif