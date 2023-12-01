using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDEXNet;
namespace DDEXNetApp
{
    public abstract class RenderObject
    {
        protected DDEX ddex;

        public DDEXNet.DDEX.RENDER_EFFECTS? Effect { get; set; }

        public bool Visible { get; set; }

        public bool AsLight { get; set; }

        public byte LightType { get; set; }

        public int LightRadius { get; set; }

        protected DDEXNet.DDEX.DDEXFLOAT4 effectValues;

        protected DDEXNet.DDEX.RenderColor color;

        public DDEXNet.DDEX.DDEXFLOAT4 EffectValues
        {
            get
            {
                return this.effectValues;
            }
        }

        public DDEXNet.DDEX.RenderColor Color
        {
            get
            {
                return this.color;
            }
        }

        public int X { get; set; }

        public int Y { get; set; }

        protected int y;

        public RenderObject(DDEX ddex)
        {
            this.ddex = ddex;
            this.LightRadius = 100;
            this.AsLight = false;
            this.Effect = null;
            this.effectValues.a = 0.0f;
            this.effectValues.r = 0.0f;
            this.effectValues.g = 0.0f;
            this.effectValues.b = 0.0f;

            this.color = new DDEX.RenderColor()
            {
                r = 255,
                g = 255,
                b = 255,
                a = 255
            };

            this.Visible = true;
        }

        public void SetEffectValues(DDEXNet.DDEX.DDEXFLOAT4 values)
        {
            this.effectValues = values;
        }

        public void SetColor(DDEXNet.DDEX.RenderColor color)
        {
            this.color = color;
        }

        public abstract void DrawAsSolid();

        virtual public void DrawAsLight()
        {
        }

        public void Draw()
        {
            if(this.AsLight)
            {
                this.DrawAsLight();
            }
            else
            {
                this.DrawAsSolid();
            }
        }

        virtual public void Tick()
        {
        }

        public override string ToString()
        {
            return "Object";
        }
    }
}
