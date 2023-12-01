using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace DDEXNet
{
    public class AnimationFactory
    {
        [DllImport("DDEX")]
        private static extern IntPtr Animation_Make(IntPtr pointerDdex, AnimationType type, IntPtr dataPointer, int dataCount);

        [DllImport("DDEX")]
        private static extern IntPtr Animation_Make(IntPtr pointerDdex, AnimationType type, ref _AnimationLightBoltData data, int dataCount);

        private enum AnimationType : Int32
        {
            LIGTHBOLT = 0,
            LIGTHBOLTAUTOMATIC
        }

        private IntPtr pointerDdex;

        public AnimationFactory(IntPtr pointerDdex)
        {
            this.pointerDdex = pointerDdex;
        }

        public Animation MakeLigthBolt(AnimationLightBoltData data)
        {
            _AnimationLightBoltData idata = new _AnimationLightBoltData();
            idata.color = data.color;
            idata.duration = data.duration;
            idata.positionsCount = data.positions.Length;

            GCHandle pinnedArray = GCHandle.Alloc(data.positions, GCHandleType.Pinned);
            IntPtr pointer = pinnedArray.AddrOfPinnedObject();
            idata.positions = pointer;

            var animation = new Animation(this.pointerDdex, Animation_Make(this.pointerDdex, AnimationType.LIGTHBOLT, ref idata, 1));

            pinnedArray.Free();

            return animation;
        }

        public Animation MakeLigthBoltAutomatic(AnimationLightBoltData data)
        {
            _AnimationLightBoltData idata = new _AnimationLightBoltData();
            idata.color = data.color;
            idata.duration = data.duration;
            idata.positionsCount = data.positions.Length;

            GCHandle pinnedArray = GCHandle.Alloc(data.positions, GCHandleType.Pinned);
            IntPtr pointer = Marshal.UnsafeAddrOfPinnedArrayElement(data.positions, 0);// pinnedArray.AddrOfPinnedObject();
            idata.positions = pointer;

            var animation = new Animation(this.pointerDdex, Animation_Make(this.pointerDdex, AnimationType.LIGTHBOLTAUTOMATIC, ref idata, 1));

            pinnedArray.Free();

            return animation;
        }

        public struct PositionXY
        {
            public Int32 X;

            public Int32 Y;

            public PositionXY(Int32 x, Int32 y)
            {
                this.X = x;
                this.Y = y;
            }
        }
        public struct AnimationLightBoltData
        {
            public DDEX.RenderColor color;
            public Int32 duration;
            public Int32 positionsCount;
            public PositionXY[] positions;
        }

        internal struct _AnimationLightBoltData
        {
            public DDEX.RenderColor color;
            public Int32 duration;
            public Int32 positionsCount;
            public IntPtr positions;
        }
    }
}
