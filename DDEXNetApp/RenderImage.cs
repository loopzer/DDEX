using DDEXNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDEXNetApp
{
    class RenderImage : RenderObject
    {
        private int image;

        private DDEXNet.DDEX.RECT rect;

        public RenderImage(int image, DDEXNet.DDEX.RECT rect, DDEX ddex)
            : base(ddex)
        {
            this.image = image;
            this.rect = rect;
        }

        public override void DrawAsSolid()
        {
            this.ddex.Draw(this.image, rect, this.X, this.Y, this.color);
        }

        public override void DrawAsLight()
        {
            DDEXNet.DDEX.LightDraw ld;
            ld.type = this.LightType;
            ld.image = this.image;

            if (this.LightRadius > 0)
            {
                ld.rect = new DDEXNet.DDEX.RECT(this.X - this.LightRadius, this.Y - this.LightRadius, this.X + this.LightRadius, this.Y + this.LightRadius);
            }
            else
            {
                ld.rect = new DDEXNet.DDEX.RECT(this.X, this.Y, this.X + this.rect.Width, this.Y + this.rect.Height);
            }
            
            ld.color = this.color;

            this.ddex.SetLight(ld);
        }

        public override string ToString()
        {
            return "Image " + this.image.ToString();
        }
    }
}
