using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDEXNet
{
    public static class Extensions
    {
            public static DDEX.RenderColor ToDDEXRGBA(this System.Drawing.Color color)
            {
                DDEX.RenderColor m;

                m.a = color.A;
                m.r = color.R;
                m.g = color.G;
                m.b = color.B;
                return m;
            }
    }
}
