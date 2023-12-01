using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace DDEXNet
{
    public class Animation : IDisposable
    {

        [DllImport("DDEX")]
        private static extern void Animation_Delete(IntPtr pointerDdex, IntPtr pointerAnimation);

        private IntPtr pointerAnimation;

        private IntPtr pointerDdex;

        public Animation(IntPtr pointerDdex, IntPtr pointerAnimation)
        {
            this.pointerDdex = pointerDdex;
            this.pointerAnimation = pointerAnimation;
        }

        public void Dispose()
        {
            Animation_Delete(this.pointerDdex, this.pointerAnimation);
        }
    }
}
