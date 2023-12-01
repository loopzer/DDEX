#include "ColorAnimation.h"
using namespace DDEX;
ColorAnimation::ColorAnimation(Render::RenderColor from, Render::RenderColor to, int duration, bool isLoop)
{
	this->Configure(from, to, duration, isLoop);
}

void ColorAnimation::Configure(Render::RenderColor from, Render::RenderColor to, int duration, bool isLoop) {

	this->isLoop = isLoop;
	this->isComplete = false;
	this->duration = duration;
	this->Configure(from, to);
}
void ColorAnimation::Configure(Render::RenderColor from, Render::RenderColor to) {
	ColorStep toS;
	ColorStep fromS;

	this->from = from;
	this->to = to;
	this->current.FromColor(this->from);

	fromS.FromColor(this->from);
	toS.FromColor(this->to);

	this->fromStep.FromColor(this->from);

	this->step.a = fabs(fromS.a - toS.a) / ((this->duration));
	this->step.r = fabs(fromS.r - toS.r) / ((this->duration));
	this->step.g = fabs(fromS.g - toS.g) / ((this->duration));
	this->step.b = fabs(fromS.b - toS.b) / ((this->duration));

	if (fromS.r > toS.r)
	{
		this->step.r = -this->step.r;
	}

	if (fromS.g > toS.g)
	{
		this->step.g = -this->step.g;
	}

	if (fromS.b > toS.b)
	{
		this->step.b = -this->step.b;
	}

	if (fromS.a > toS.a)
	{
		this->step.a = -this->step.a;
	}
}

void ColorAnimation::Start() {
	this->Start(GetTickCount());
}
void ColorAnimation::Start(int ticks) {
	this->startTicks = ticks;
}
void ColorAnimation::Tick() {
	this->Tick(GetTickCount());
}
void ColorAnimation::Tick(int ticks) {

	if (ticks >= (this->startTicks + this->duration))
	{
		this->current.a = this->to.a;
		this->current.b = this->to.b;
		this->current.g = this->to.g;
		this->current.r = this->to.r;

		if (this->isLoop)
		{
			this->Configure(this->to, this->from);
			this->Start(ticks);
		}
		else
		{
			this->isComplete = true;
		}
	}
	else
	{
		double steps = ticks - this->startTicks;

		this->current.a = this->fromStep.a + (this->step.a * steps);
		this->current.r = this->fromStep.r + (this->step.r * steps);
		this->current.g = this->fromStep.g + (this->step.g * steps);
		this->current.b = this->fromStep.b + (this->step.b * steps);

	}
}
bool ColorAnimation::IsComplete() {
	return this->isComplete;
}
Render::RenderColor ColorAnimation::GetColor() {
	Render::RenderColor c;

	c.a = (byte)this->current.a;
	c.r = (byte)this->current.r;
	c.g = (byte)this->current.g;
	c.b = (byte)this->current.b;

	return c;
}
