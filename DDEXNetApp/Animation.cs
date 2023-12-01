using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDEXNet;
namespace DDEXNetApp
{

    public class AnimationFrame
    {
        public DDEXNet.DDEX.RECT Rect { get; set; }

        public int Image { get; set; }

        public AnimationFrame(int image, DDEXNet.DDEX.RECT rect)
        {
            this.Image = image;
            this.Rect = rect;
        }
    }

    public class Animation
    {
        private List<AnimationFrame> frames;

        private int FPM;

        private int loops;

        private int maxFrames;

        private int currentFrame = 0;

        private DateTime lastTime;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="frames"></param>
        /// <param name="FPM">cada cuantos milisegundos debe cambiar de frame</param>
        /// <param name="loops">cantidad de repeticiones, si es -1 es infinito</param>
        public Animation(int image, List<DDEXNet.DDEX.RECT> frames, int FPM, int loops)
        {
            this.frames = new List<AnimationFrame>();

            foreach (var item in frames)
            {
                this.frames.Add(new AnimationFrame(image, item));
            }

            this.FPM = FPM;
            this.loops = loops;
            this.maxFrames = frames.Count;
            this.lastTime = DateTime.Now;
        }

        public Animation(List<AnimationFrame> frames, int FPM, int loops)
        {
            this.frames = frames;
            this.FPM = FPM;
            this.loops = loops;
            this.maxFrames = frames.Count;
            this.lastTime = DateTime.Now;
        }

        public void Reset()
        {
            this.lastTime = DateTime.Now;
            this.currentFrame = 0;
        }

        public AnimationFrame GetFrame()
        {
            return frames[currentFrame];
        }

        public void Draw(DDEX ddex, int x, int y)
        {
            ddex.Draw(frames[currentFrame].Image, frames[currentFrame].Rect, x, y);
            DDEX.LightDraw m;

            m.color.a = 255;
            m.color.r = 255;
            m.color.g = 255;
            m.color.b = 255;

            m.image = frames[currentFrame].Image;

            m.rect.Left = x;
            m.rect.Top = y;
            m.rect.Right = x + frames[currentFrame].Rect.Width;
            m.rect.Bottom = y + frames[currentFrame].Rect.Height;

            m.rect.Left -= 50;
            m.rect.Top -= 50;
            m.rect.Right += 50;
            m.rect.Bottom += 50;

            //ddex.SetLight(m);
        }

        public void Tick(DateTime actualTime)
        {
            var diff = actualTime - lastTime;

            if (diff.TotalMilliseconds >= this.FPM)
            {
                this.currentFrame++;

                if (this.currentFrame == this.maxFrames)
                {
                    this.currentFrame = 0;
                }

                lastTime = actualTime;
            }
        }

        public void Tick()
        {
            this.Tick(DateTime.Now);
        }
    }
}
