using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace DDEXNet
{
    public class ColorAnimation : IDisposable
    {

        [DllImport("DDEX")]
        public static extern void ColorAnimation_Delete(IntPtr p);

        [DllImport("DDEX")]
        public static extern void ColorAnimation_Start( IntPtr p);

        [DllImport("DDEX")]
        public static extern void ColorAnimation_StartWithTicks(IntPtr p, int ticks);

        [DllImport("DDEX")]
        public static extern void ColorAnimation_Tick(IntPtr p);

        [DllImport("DDEX")]
        public static extern void ColorAnimation_TickWithTicks(IntPtr p, int ticks);

        [DllImport("DDEX")]
        public static extern DDEX.RenderColor ColorAnimation_GetColor(IntPtr p);

        [DllImport("DDEX")]
        public static extern bool ColorAnimation_GetColorAndIsComplete(IntPtr p, ref DDEX.RenderColor color);

        [DllImport("DDEX")]
        public static extern bool ColorAnimation_IsComplete(IntPtr p);

        [DllImport("DDEX")]
        public static extern IntPtr ColorAnimation_Create(ref DDEX.RenderColor from,ref DDEX.RenderColor to, int duration, bool isLoop);


        private IntPtr pointer;

        public ColorAnimation(DDEX.RenderColor from, DDEX.RenderColor to, int duration, bool isLoop)
        {
            this.pointer = ColorAnimation_Create(ref from, ref to, duration, isLoop);
        }

        public void Start()
        {
            ColorAnimation_Start(this.pointer);
        }

        public void Start(int ticks)
        {
            ColorAnimation_StartWithTicks(this.pointer, ticks);
        }
        public void Tick()
        {
            ColorAnimation_Tick(this.pointer);
        }

        public void Tick(int ticks)
        {
            ColorAnimation_TickWithTicks(this.pointer, ticks);
        }

        public bool IsComplete()
        {
            return ColorAnimation_IsComplete(this.pointer);
        }

        public bool GetColor(ref DDEX.RenderColor c)
        {
            var bb = ColorAnimation_GetColorAndIsComplete(this.pointer, ref c);

            return bb;
        }

        public DDEX.RenderColor GetColor()
        {
            return ColorAnimation_GetColor(this.pointer);
        }

        public void Dispose()
        {
            ColorAnimation_Delete(this.pointer);
        }
    }
}
