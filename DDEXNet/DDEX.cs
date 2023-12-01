using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace DDEXNet
{
	public class DDEX : IDisposable
	{
		#region DLL Calls
		//DLL Calls

		[DllImport("DDEX", CharSet = CharSet.Ansi)]
		public static extern IntPtr Render_Create(string plugin, int window, string imageFolder, ref Configuration cfg);

		[DllImport("DDEX")]
		public static extern void Render_Present(IntPtr render);

		[DllImport("DDEX")]
		public static extern void Render_Clean(IntPtr render);


		[DllImport("DDEX")]
		public static extern void Render_FlushScreen(IntPtr render);

		[DllImport("DDEX")]
		public static extern void Render_FlushBackground(IntPtr render);

		[DllImport("DDEX")]
		public static extern void Render_DrawImage(IntPtr render, int imageNum, int x, int y, [In] ref RECT r, ref RenderColor color);

		[DllImport("DDEX")]
		public static extern void Primitive_DrawBox(IntPtr render, [In] ref RECT r, ref RenderColor color);

		[DllImport("DDEX")]
		public static extern void Render_DrawImageWithRotation(IntPtr render, int imageNum, int x, int y, [In] ref RECT r, ref RenderColor color, int angle);

		[DllImport("DDEX")]
		public static extern void Render_Destroy(IntPtr render);

		[DllImport("DDEX")]
		private static extern void Render_CleanLight(IntPtr pDDEX);

		[DllImport("DDEX")]
		private static extern void Render_SetLight(IntPtr pDDEX, ref LightDraw ld);

		[DllImport("DDEX")]
		private static extern void Render_SetMasterLight(IntPtr pDDEX, int redLight, int greenLight, int blueLight);

		[DllImport("DDEX")]
		private static extern void Render_SetRenderEffect(IntPtr pDDEX, int effect, ref DDEXFLOAT4 data);

		[DllImport("DDEX")]
		private static extern void Render_SetPresentEffect(IntPtr pDDEX, int effect, ref DDEXFLOAT4 data);

		[DllImport("DDEX")]
		private static extern void Render_ClearPresentEffect(IntPtr pDDEX, int effect);

		[DllImport("DDEX", CharSet = CharSet.Ansi)]
		public static extern int Render_MakeFont(IntPtr pDDEX, string fontName, int size, bool bold, bool italic, int forcedId);

		[DllImport("DDEX", CharSet = CharSet.Ansi)]
		public static extern int Render_DrawFont(IntPtr pDDEX, string text, int font, int x, int y, ref RenderColor color);

		[DllImport("DDEX")]
		public static extern IntPtr UI_Create(IntPtr pDDEX);

		[DllImport("DDEX")]
		public static extern void Render_SetImageProxy(IntPtr pDDEX, ProxyDelegateType proxy);
		//private void Render_SetImageProxy(IntPtr pDDEX, Render::FuncGetFileBytes func);

		#endregion

		public enum PRESENT_EFFECTS : int
		{
			DEFAULT,
			INVERTCOLOR,
			GREY,
			RED,
			GREEN,
			BLUE,
			INVERTTEXTURE,
			RELIEF,
			VIBRATIONFULL,
			VIBRATIONSIMPLE,
			SHAKE,
			DRUNK,
			FLASH,
			RELIEFCOLOR,
			BLUR,
			ENUMSIZE
		}
		public enum RENDER_EFFECTS : int
		{
			NONE = 0,
			INVERTCOLORS = 1,
			GREYSCALE = 2,
			REDSCALE = 3,
			GREENSCALE = 4,
			BLUESCALE = 5,
			INVERTTEXTURE = 6,
			RELIEF = 7,
			SWINGING = 8,
			WAVE = 9,
			BLUR = 10,
			CUSTOM = 11
		}
		#region EXTRAS
		[StructLayout(LayoutKind.Sequential)]
		public struct RECT
		{
			public int Left, Top, Right, Bottom;

			public RECT(int left, int top, int right, int bottom)
			{
				Left = left;
				Top = top;
				Right = right;
				Bottom = bottom;
			}

			public RECT(System.Drawing.Rectangle r) : this(r.Left, r.Top, r.Right, r.Bottom) { }

			public int X
			{
				get { return Left; }
				set { Right -= (Left - value); Left = value; }
			}

			public int Y
			{
				get { return Top; }
				set { Bottom -= (Top - value); Top = value; }
			}

			public int Height
			{
				get { return Bottom - Top; }
				set { Bottom = value + Top; }
			}

			public int Width
			{
				get { return Right - Left; }
				set { Right = value + Left; }
			}

			public System.Drawing.Point Location
			{
				get { return new System.Drawing.Point(Left, Top); }
				set { X = value.X; Y = value.Y; }
			}

			public System.Drawing.Size Size
			{
				get { return new System.Drawing.Size(Width, Height); }
				set { Width = value.Width; Height = value.Height; }
			}

			public static implicit operator System.Drawing.Rectangle(RECT r)
			{
				return new System.Drawing.Rectangle(r.Left, r.Top, r.Width, r.Height);
			}

			public static implicit operator RECT(System.Drawing.Rectangle r)
			{
				return new RECT(r);
			}

			public static bool operator ==(RECT r1, RECT r2)
			{
				return r1.Equals(r2);
			}

			public static bool operator !=(RECT r1, RECT r2)
			{
				return !r1.Equals(r2);
			}

			public bool Equals(RECT r)
			{
				return r.Left == Left && r.Top == Top && r.Right == Right && r.Bottom == Bottom;
			}

			public override bool Equals(object obj)
			{
				if (obj is RECT)
					return Equals((RECT)obj);
				else if (obj is System.Drawing.Rectangle)
					return Equals(new RECT((System.Drawing.Rectangle)obj));
				return false;
			}

			public override int GetHashCode()
			{
				return ((System.Drawing.Rectangle)this).GetHashCode();
			}

			public override string ToString()
			{
				return string.Format(System.Globalization.CultureInfo.CurrentCulture, "{{Left={0},Top={1},Right={2},Bottom={3}}}", Left, Top, Right, Bottom);
			}

		}

		#endregion

		public struct Configuration
		{
			public byte vsync;
			public byte holder;
			public RenderMode render_mode;
			public VertexMode vertex_mode;
			public MemoryMode memory;
			public byte deferral;
		}

		public struct DDEXFLOAT4
		{
			public float r;
			public float g;
			public float b;
			public float a;

			// override object.Equals
			public bool Equals(DDEXFLOAT4 obj)
			{

				return (this.r == obj.r
					&& this.a == obj.a
					&& this.r == obj.r
					&& this.g == obj.g
					);
			}

		}

		public struct RenderColor
		{
			public byte b;
			public byte g;
			public byte r;
			public byte a;
		}

		public struct LightDraw
		{
			public int image;
			public byte type;
			public RECT rect;
			public RenderColor color;
		}

		[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = CharSet.None)]
		public struct FileData
		{
			public Int32 fileNum;

			public IntPtr bytes;

			public Int32 size;
			public Int32 fileType; // PNG BMP etc;
		};

		public enum RenderAPI : byte
		{
			DX9 = 0, DX9_EXP = 1, OGL = 2, DX8 = 3
		}

		public enum MemoryMode : byte
		{
			DX9_DEFAULT = 0, DX9_ADMIN, DX9_SYSTEM
		}

		public enum RenderMode : byte
		{
			DX9_HARDWARE = 0, DX9_REF = 1, DX9_SOFTWARE = 2
		}

		public enum VertexMode : byte
		{
			DX9_HARDWARE = 0, DX9_SOFTWARE = 1
		}

		public AnimationFactory AnimationFactory { get; private set; }

		public delegate void ProxyDelegateType(ref FileData file);

		public ProxyDelegateType proxyDelegate;

		protected IntPtr hwnd;

		protected IntPtr pDDEX;

		protected UI ui;

		protected Func<int, byte[]> imageReader = null;

		protected string imageFolder;

		public DDEX(string plugin, IntPtr hwnd, string imageFolder, Configuration config)
		{
			if ((this.pDDEX = Render_Create(plugin, hwnd.ToInt32(), imageFolder, ref config)) == IntPtr.Zero)
			{
				throw new DDEXException("Error al iniciar DDEX.");
			}
			this.imageFolder = imageFolder;
			this.SetProxy((num) =>
			{
				var file = $"{this.imageFolder}\\{num}.png";

				if (!System.IO.File.Exists(file))
				{
					file = $"{this.imageFolder}\\{num}.bmp";
				}

				return System.IO.File.ReadAllBytes(file);
			});

			this.AnimationFactory = new AnimationFactory(this.pDDEX);
		}

		public static bool Probe(IntPtr hwnd, Configuration config)
		{
			return true; //(Probe(hwnd.ToInt32(), ref config) >= 0);
		}

		public void SetRenderEffect(RENDER_EFFECTS effect, DDEXFLOAT4 rgb)
		{
			Render_SetRenderEffect(this.pDDEX, (int)effect, ref rgb);
		}

		public void SetRenderEffect(RENDER_EFFECTS effect)
		{
			this.SetRenderEffect(effect, new DDEXFLOAT4()
			{
				a = 0.0f,
				r = 0.0f,
				g = 0.0f,
				b = 0.0f
			});
		}

		private void Proxy(ref FileData file)
		{
			var bytes = this.imageReader(file.fileNum);

			if (bytes != null)
			{
				file.fileType = 1;
				file.size = bytes.Length;
				file.bytes = Marshal.UnsafeAddrOfPinnedArrayElement(bytes, 0);
			}
			else
			{
				file.fileType = 0;
			}
		}

		public void SetProxy(Func<int, byte[]> proxy)
		{
			this.imageReader = proxy;

			this.proxyDelegate = delegate (ref FileData file)
			{
				this.Proxy(ref file);
			};

			Render_SetImageProxy(this.pDDEX, this.proxyDelegate);
		}
		public void SetPresentEffect(PRESENT_EFFECTS effect)
		{
			this.SetPresentEffect(effect, new DDEXFLOAT4());
		}


		public void SetPresentEffect(PRESENT_EFFECTS effect, DDEXFLOAT4 rgb)
		{
			Render_SetPresentEffect(this.pDDEX, (int)effect, ref rgb);
		}

		public void ClearPresentEffects()
		{
			Render_ClearPresentEffect(pDDEX, -1);
		}

		public int CreateFont(System.Drawing.Font font, int forceFont = -1)
		{
			int _font = Render_MakeFont(pDDEX, font.OriginalFontName ?? font.Name, (int)font.Size, font.Bold, font.Italic, forceFont);

			if (_font == -1)
			{
				throw new DDEXException("Error al cargar fuente(" + font.OriginalFontName.ToString() + ").");
			}

			return _font;
		}

		public int GetHDC(int font)
		{
			return 1;//DGetHDCFont(ref pDDEX, font);
		}

		public void DrawPlus(int image, RECT rect, int x, int y, RenderColor color)
		{
			Render_DrawImage(this.pDDEX, image, x, y, ref rect, ref color);
		}

		public void Draw(RECT rect, RenderColor color)
		{
			Primitive_DrawBox(this.pDDEX, ref rect, ref color);
		}

		public void DrawBox(RECT rect, RenderColor color)
		{
			Primitive_DrawBox(this.pDDEX, ref rect, ref color);
		}

		public void Draw(string text, int x, int y, RenderColor color, int font)
		{
			Render_DrawFont(pDDEX, text, font, x, y, ref color);
		}

		public void DrawShadow(int image, RECT rect, int x, int y, RenderColor color, int angle)
		{
		}

		public void Draw(int image, RECT rect, int x, int y, RenderColor color)
		{
			Render_DrawImage(this.pDDEX, image, x, y, ref rect, ref color);
		}

		public void Draw(int image, RECT rect, int x, int y, RenderColor color, int angle)
		{
			Render_DrawImageWithRotation(this.pDDEX, image, x, y, ref rect, ref color, angle);
		}

		public void SetMasterLight(int redLight, int greenLight, int blueLight)
		{
			Render_SetMasterLight(pDDEX, redLight, greenLight, blueLight);
		}

		public UI GetUI()
		{
			if (this.ui == null)
			{
				this.ui = new UI(this.pDDEX, UI_Create(this.pDDEX));
			}

			return ui;
		}

		public void Draw(int image, RECT rect, int x, int y)
		{
			this.Draw(image, rect, x, y, new RenderColor()
			{
				a = 255,
				r = 255,
				g = 255,
				b = 255,
			});
		}

		public void CleanLight()
		{
			Render_CleanLight(pDDEX);
		}

		public void CleanSolidObject()
		{
			//   CleanSolidObject(ref pDDEX);
		}

		public void FlushScreen()
		{
			//FlushScreen(ref pDDEX);
			Render_FlushScreen(this.pDDEX);
		}

		public void FlushBackground()
		{
			Render_FlushBackground(this.pDDEX);
		}

		public void SaveImage(IntPtr hwnd, string filename, int imageType)
		{
			// SaveImage(ref pDDEX, hwnd.ToInt32(), filename, imageType);
		}

		public void SetLight(LightDraw ld)
		{
			Render_SetLight(pDDEX, ref ld);
		}

		public int GetAvaibleMemory()
		{
			return 1;// AvaibleMemory(ref pDDEX);
		}

		public void PreLoad(int image)
		{
			//PreCargarGrafico(ref pDDEX, image);
		}

		public void Clean()
		{
			//  LimpiarMotor(ref pDDEX);
			Render_Clean(this.pDDEX);
		}

		public void Present()
		{
			// DibujarMotor(ref pDDEX);
			Render_Present(this.pDDEX);
		}

		public void Dispose()
		{
			if (this.pDDEX != IntPtr.Zero)
			{
				this.ui?.Dispose();
				Render_Destroy(this.pDDEX);
			}
		}
	}

	[Serializable]
	public class DDEXException : Exception
	{
		public DDEXException() { }
		public DDEXException(string message) : base(message) { }
		public DDEXException(string message, Exception inner) : base(message, inner) { }
		protected DDEXException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context)
			: base(info, context) { }
	}
}
