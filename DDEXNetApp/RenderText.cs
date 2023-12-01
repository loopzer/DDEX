using DDEXNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDEXNetApp
{
    class RenderText : RenderObject
    {
        private string text;

        private int font;

        public RenderText(string text, int font, DDEX ddex)
            : base(ddex)
        {
            this.text = text;
            this.font = font;
        }

        public override void DrawAsSolid()
        {
            this.ddex.Draw(this.text, this.X, this.Y, this.color, this.font);
        }

        public override string ToString()
        {
            return "Text " + this.text;
        }
    }
}
