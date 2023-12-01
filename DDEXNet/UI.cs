using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace DDEXNet
{
	public class UI
	{
		[DllImport("DDEX")]
		private static extern void UI_Destroy(IntPtr pointerUI);

		[DllImport("DDEX")]
		private static extern UIComponent UI_GetUIComponent(IntPtr pointerUI, UInt32 imageIndex);

		public struct UIComponent
		{
			public IntPtr icon;
			public IntPtr hdc;
			public IntPtr hdcRed;
			public IntPtr bitmap;
			public IntPtr bitmapRed;
			public IntPtr cursor;
			public UInt32 image;
		}

		private IntPtr pointerUI;

		private IntPtr pointerDdex;

		public UI(IntPtr pointerDdex, IntPtr pointerUI)
		{
			this.pointerDdex = pointerDdex;
			this.pointerUI = pointerUI;
		}

		public UIComponent GetUIComponent(uint imageIndex)
		{
			return UI_GetUIComponent(this.pointerUI, imageIndex);
		}

		public void Dispose()
		{
			UI_Destroy(this.pointerUI);
		}
	}
}
