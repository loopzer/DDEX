#pragma once

#include "Render\RenderDeclares.h"
#include <math.h>
namespace DDEX {

	class ColorAnimation
	{
	public:
		ColorAnimation(Render::RenderColor from, Render::RenderColor to, int duration, bool isLoop);
		void Start();
		void Start(int ticks);
		void Tick();
		void Tick(int ticks);
		bool IsComplete();
		Render::RenderColor GetColor();
		void Configure(Render::RenderColor from, Render::RenderColor to, int duration, bool isLoop);
	private:

		struct ColorStep
		{
			double a, r, g, b;

			void FromColor(Render::RenderColor color) {
				this->a = color.a;
				this->r = color.r;
				this->g = color.g;
				this->b = color.b;
			}
		};

		Render::RenderColor from;
		Render::RenderColor to;

		ColorStep step;
		ColorStep current;
		ColorStep fromStep;

		int duration;
		int startTicks;
		bool isLoop;
		bool isComplete;

		void Configure(Render::RenderColor from, Render::RenderColor to);
	};
}
