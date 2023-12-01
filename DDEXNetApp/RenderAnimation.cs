using DDEXNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDEXNetApp
{
    class RenderAnimation : RenderObject
    {
        private Animation animation;

        public RenderAnimation(Animation animation, DDEX ddex)
            : base(ddex)
        {
            this.animation = animation;
        }

        public override void Tick()
        {
            this.animation.Tick();
        }

        public override string ToString()
        {
            return "Animation";
        }

        public override void DrawAsSolid()
        {
            var frame = this.animation.GetFrame();
            this.ddex.Draw(frame.Image, frame.Rect, this.X, this.Y, this.color);
        }

        public override void DrawAsLight()
        {
            var frame = this.animation.GetFrame();
            DDEXNet.DDEX.LightDraw ld;

            ld.image = frame.Image;
            ld.rect = new DDEXNet.DDEX.RECT(this.X - this.LightRadius, this.Y - this.LightRadius, this.X + this.LightRadius, this.Y + this.LightRadius);
            ld.type = this.LightType;
            ld.color = this.color;

            this.ddex.SetLight(ld);
        }
    }
}
