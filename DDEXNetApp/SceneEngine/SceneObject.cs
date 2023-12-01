using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDEXNetApp.SceneEngine
{
    class SceneColorObject
    {
        public int R { get; set; }
        
        public int G { get; set; }

        public int B { get; set; }

        public int A { get; set; }
    }

    class SceneObject
    {
        public string RenderType { get; set; }
        
        public int X { get; set; }
        
        public int Y { get; set; }

        public int Image { get; set; }

        public SceneColorObject Color { get; set; }
    }
}
