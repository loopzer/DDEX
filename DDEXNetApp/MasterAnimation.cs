using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace DDEXNetApp
{

    struct ColorStep
    {
        public double r, g, b;

        public void FromColor(Color c)
        {
            r = c.R;
            g = c.G;
            b = c.B;
        }
    }

    struct MasterAnimate
    {
        public Color from;
        public Color To;
        public ColorStep Step;
        public ColorStep Current;
        public ColorStep fromStep;
    }


    class MasterAnimation
    {
        MasterAnimate ma;

        int duration;

        int startTicks;

        public bool IsComplete { get; set; }

        private bool isLoop = false;

        public MasterAnimation(Color from, Color to, int duration, bool isLoop = false)
        {
            this.isLoop = isLoop;
            this.IsComplete = false;
            this.duration = duration;
            this.Configure(from, to);
        }

        private void Configure(Color from, Color to)
        {
            ColorStep toS = new ColorStep();
            ColorStep fromS = new ColorStep();

            ma.from = from;
            ma.To = to;
            ma.Current.FromColor(ma.from);
            ma.fromStep.FromColor(ma.from);
            toS.FromColor(ma.To);
            fromS.FromColor(ma.from);

            ma.Step.r = Math.Abs(fromS.r - toS.r) / ((this.duration));
            ma.Step.g = Math.Abs(fromS.g - toS.g) / ((this.duration));
            ma.Step.b = Math.Abs(fromS.b - toS.b) / ((this.duration));

            if (fromS.r > toS.r)
            {
                ma.Step.r = -ma.Step.r;
            }

            if (fromS.g > toS.g)
            {
                ma.Step.g = -ma.Step.g;
            }

            if (fromS.b > toS.b)
            {
                ma.Step.b = -ma.Step.b;
            }
        }

        public void Start()
        {
            this.startTicks = Environment.TickCount;
        }

        public void Start(int ticks)
        {
            this.startTicks = ticks;
        }

        public void Tick()
        {
            int ticks = Environment.TickCount;
            if (ticks >= (this.startTicks + this.duration))
            {
                this.ma.Current.r = this.ma.fromStep.r + (this.ma.Step.r * this.duration);
                this.ma.Current.g = this.ma.fromStep.g + (this.ma.Step.g * this.duration);
                this.ma.Current.b = this.ma.fromStep.b + (this.ma.Step.b * this.duration);
                if (this.isLoop)
                {
                    this.Configure(this.ma.To, this.ma.from);
                    this.Start();
                }
                else
                {
                    this.IsComplete = true;
                }
            }
            else
            {
                int steps = ticks - this.startTicks;

                this.ma.Current.r = this.ma.fromStep.r + (this.ma.Step.r * steps);
                this.ma.Current.g = this.ma.fromStep.g + (this.ma.Step.g * steps);
                this.ma.Current.b = this.ma.fromStep.b + (this.ma.Step.b * steps);
            }
        }

        public ColorStep GetColor()
        {
            return this.ma.Current;
        }
    }
}
