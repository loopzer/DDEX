using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using DDEXNet;
using System.Diagnostics;

namespace DDEXNetApp
{

	public partial class FrmDDEX : Form
	{
		enum VirtualKeyStates : int
		{
			VK_LBUTTON = 0x01,
			VK_RBUTTON = 0x02,
			VK_CANCEL = 0x03,
			VK_MBUTTON = 0x04,
			//
			VK_XBUTTON1 = 0x05,
			VK_XBUTTON2 = 0x06,
			//
			VK_BACK = 0x08,
			VK_TAB = 0x09,
			//
			VK_CLEAR = 0x0C,
			VK_RETURN = 0x0D,
			//
			VK_SHIFT = 0x10,
			VK_CONTROL = 0x11,
			VK_MENU = 0x12,
			VK_PAUSE = 0x13,
			VK_CAPITAL = 0x14,
			//
			VK_KANA = 0x15,
			VK_HANGEUL = 0x15,  /* old name - should be here for compatibility */
			VK_HANGUL = 0x15,
			VK_JUNJA = 0x17,
			VK_FINAL = 0x18,
			VK_HANJA = 0x19,
			VK_KANJI = 0x19,
			//
			VK_ESCAPE = 0x1B,
			//
			VK_CONVERT = 0x1C,
			VK_NONCONVERT = 0x1D,
			VK_ACCEPT = 0x1E,
			VK_MODECHANGE = 0x1F,
			//
			VK_SPACE = 0x20,
			VK_PRIOR = 0x21,
			VK_NEXT = 0x22,
			VK_END = 0x23,
			VK_HOME = 0x24,
			VK_LEFT = 0x25,
			VK_UP = 0x26,
			VK_RIGHT = 0x27,
			VK_DOWN = 0x28,
			VK_SELECT = 0x29,
			VK_PRINT = 0x2A,
			VK_EXECUTE = 0x2B,
			VK_SNAPSHOT = 0x2C,
			VK_INSERT = 0x2D,
			VK_DELETE = 0x2E,
			VK_HELP = 0x2F,
			//
			VK_LWIN = 0x5B,
			VK_RWIN = 0x5C,
			VK_APPS = 0x5D,
			//
			VK_SLEEP = 0x5F,
			//
			VK_NUMPAD0 = 0x60,
			VK_NUMPAD1 = 0x61,
			VK_NUMPAD2 = 0x62,
			VK_NUMPAD3 = 0x63,
			VK_NUMPAD4 = 0x64,
			VK_NUMPAD5 = 0x65,
			VK_NUMPAD6 = 0x66,
			VK_NUMPAD7 = 0x67,
			VK_NUMPAD8 = 0x68,
			VK_NUMPAD9 = 0x69,
			VK_MULTIPLY = 0x6A,
			VK_ADD = 0x6B,
			VK_SEPARATOR = 0x6C,
			VK_SUBTRACT = 0x6D,
			VK_DECIMAL = 0x6E,
			VK_DIVIDE = 0x6F,
			VK_F1 = 0x70,
			VK_F2 = 0x71,
			VK_F3 = 0x72,
			VK_F4 = 0x73,
			VK_F5 = 0x74,
			VK_F6 = 0x75,
			VK_F7 = 0x76,
			VK_F8 = 0x77,
			VK_F9 = 0x78,
			VK_F10 = 0x79,
			VK_F11 = 0x7A,
			VK_F12 = 0x7B,
			VK_F13 = 0x7C,
			VK_F14 = 0x7D,
			VK_F15 = 0x7E,
			VK_F16 = 0x7F,
			VK_F17 = 0x80,
			VK_F18 = 0x81,
			VK_F19 = 0x82,
			VK_F20 = 0x83,
			VK_F21 = 0x84,
			VK_F22 = 0x85,
			VK_F23 = 0x86,
			VK_F24 = 0x87,
			//
			VK_NUMLOCK = 0x90,
			VK_SCROLL = 0x91,
			//
			VK_OEM_NEC_EQUAL = 0x92,   // '=' key on numpad
									   //
			VK_OEM_FJ_JISHO = 0x92,   // 'Dictionary' key
			VK_OEM_FJ_MASSHOU = 0x93,   // 'Unregister word' key
			VK_OEM_FJ_TOUROKU = 0x94,   // 'Register word' key
			VK_OEM_FJ_LOYA = 0x95,   // 'Left OYAYUBI' key
			VK_OEM_FJ_ROYA = 0x96,   // 'Right OYAYUBI' key
									 //
			VK_LSHIFT = 0xA0,
			VK_RSHIFT = 0xA1,
			VK_LCONTROL = 0xA2,
			VK_RCONTROL = 0xA3,
			VK_LMENU = 0xA4,
			VK_RMENU = 0xA5,
			//
			VK_BROWSER_BACK = 0xA6,
			VK_BROWSER_FORWARD = 0xA7,
			VK_BROWSER_REFRESH = 0xA8,
			VK_BROWSER_STOP = 0xA9,
			VK_BROWSER_SEARCH = 0xAA,
			VK_BROWSER_FAVORITES = 0xAB,
			VK_BROWSER_HOME = 0xAC,
			//
			VK_VOLUME_MUTE = 0xAD,
			VK_VOLUME_DOWN = 0xAE,
			VK_VOLUME_UP = 0xAF,
			VK_MEDIA_NEXT_TRACK = 0xB0,
			VK_MEDIA_PREV_TRACK = 0xB1,
			VK_MEDIA_STOP = 0xB2,
			VK_MEDIA_PLAY_PAUSE = 0xB3,
			VK_LAUNCH_MAIL = 0xB4,
			VK_LAUNCH_MEDIA_SELECT = 0xB5,
			VK_LAUNCH_APP1 = 0xB6,
			VK_LAUNCH_APP2 = 0xB7,
			//
			VK_OEM_1 = 0xBA,   // ';:' for US
			VK_OEM_PLUS = 0xBB,   // '+' any country
			VK_OEM_COMMA = 0xBC,   // ',' any country
			VK_OEM_MINUS = 0xBD,   // '-' any country
			VK_OEM_PERIOD = 0xBE,   // '.' any country
			VK_OEM_2 = 0xBF,   // '/?' for US
			VK_OEM_3 = 0xC0,   // '`~' for US
							   //
			VK_OEM_4 = 0xDB,  //  '[{' for US
			VK_OEM_5 = 0xDC,  //  '\|' for US
			VK_OEM_6 = 0xDD,  //  ']}' for US
			VK_OEM_7 = 0xDE,  //  ''"' for US
			VK_OEM_8 = 0xDF,
			//
			VK_OEM_AX = 0xE1,  //  'AX' key on Japanese AX kbd
			VK_OEM_102 = 0xE2,  //  "<>" or "\|" on RT 102-key kbd.
			VK_ICO_HELP = 0xE3,  //  Help key on ICO
			VK_ICO_00 = 0xE4,  //  00 key on ICO
							   //
			VK_PROCESSKEY = 0xE5,
			//
			VK_ICO_CLEAR = 0xE6,
			//
			VK_PACKET = 0xE7,
			//
			VK_OEM_RESET = 0xE9,
			VK_OEM_JUMP = 0xEA,
			VK_OEM_PA1 = 0xEB,
			VK_OEM_PA2 = 0xEC,
			VK_OEM_PA3 = 0xED,
			VK_OEM_WSCTRL = 0xEE,
			VK_OEM_CUSEL = 0xEF,
			VK_OEM_ATTN = 0xF0,
			VK_OEM_FINISH = 0xF1,
			VK_OEM_COPY = 0xF2,
			VK_OEM_AUTO = 0xF3,
			VK_OEM_ENLW = 0xF4,
			VK_OEM_BACKTAB = 0xF5,
			//
			VK_ATTN = 0xF6,
			VK_CRSEL = 0xF7,
			VK_EXSEL = 0xF8,
			VK_EREOF = 0xF9,
			VK_PLAY = 0xFA,
			VK_ZOOM = 0xFB,
			VK_NONAME = 0xFC,
			VK_PA1 = 0xFD,
			VK_OEM_CLEAR = 0xFE
		}
		//[DllImport("USER32.dll")]
		//static extern short GetKeyState(VirtualKeyStates nVirtKey);

		[DllImport("USER32.dll")]
		static extern short GetKeyState(int nVirtKey);

		DDEXNet.DDEX ddex;

		int objX = 500;
		int objY = 250;

		int fo;

		int mouseX, mouseY;

		Animation anim;

		Animation mouseAnim;

		Animation bodyAnim;

		Animation apoka;

		Animation descarga;

		Animation explotion;

		Animation spawn;

		Animation med;

		bool isDefferal;

		string plugin;

		DateTime SecondStop;

		RenderObjectControl selectedRenderObjectControl = null;

		public FrmDDEX()
		{
			InitializeComponent();
			this.FormClosed += FrmDDEX_FormClosed;
			SecondStop = DateTime.Now;
		}

		public FrmDDEX(string plugin, bool isDefferal = false)
		{
			InitializeComponent();
			this.plugin = plugin;
			this.isDefferal = isDefferal;
			this.FormClosed += FrmDDEX_FormClosed;
			this.picMain.MouseDown += PicMain_MouseDown;
			this.picMain.MouseMove += picMain_MouseMove;
		}

		private List<AnimationFactory.PositionXY> ThunderPositions = new List<AnimationFactory.PositionXY>();

		private void PicMain_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (this.ThunderPositions.Count <= 1)
				{
					var data = new AnimationFactory.AnimationLightBoltData();
					data.positions = new AnimationFactory.PositionXY[2];
					data.positions[0].X = 250;
					data.positions[0].Y = 250;

					data.positions[1].X = e.X;
					data.positions[1].Y = e.Y;

					data.positionsCount = data.positions.Length;
					data.duration = 50;
					data.color = new DDEX.RenderColor()
					{
						a = 255,
						r = 255,
						g = 127,
						b = 255
					};
					this.ddex.AnimationFactory.MakeLigthBoltAutomatic(data);
				}
				else
				{
					var pos = this.ThunderPositions.ToArray();
					var data = new AnimationFactory.AnimationLightBoltData();
					data.positions = pos;
					data.duration = 50;
					data.positionsCount = data.positions.Length;
					data.color = new DDEX.RenderColor()
					{
						a = 255,
						r = 255,
						g = 127,
						b = 255
					};
					this.ddex.AnimationFactory.MakeLigthBoltAutomatic(data);

					this.ThunderPositions.Clear();
				}

			}
			else if (e.Button == MouseButtons.Right)
			{
				this.ThunderPositions.Add(new AnimationFactory.PositionXY(e.X, e.Y));
			}

		}

		const float PI = 3.14f;

		private float Cx(float angulo, float diametro)
		{
			return (float)(diametro * Math.Cos((angulo) * PI / 180));
		}

		private float Cy(float angulo, float diametro)
		{
			return (float)(diametro * Math.Sin((angulo) * PI / 180));
		}

		void picMain_MouseMove(object sender, MouseEventArgs e)
		{
			this.mouseX = e.X;
			this.mouseY = e.Y;
		}

		void FrmDDEX_FormClosed(object sender, FormClosedEventArgs e)
		{
			tRender.Stop();
			this.ddex.Dispose();
			GC.Collect();
		}

		private void FrmDDEX_Load(object sender, EventArgs e)
		{
			this.Text = "DDEX Test plugin:" + plugin + " IsDefferal:" + this.isDefferal.ToString();
			this.InitDDEX();
			this.InitFonts();
			this.InitAnimations();
			this.InitScene();
			this.InitPresenterEffects();
			tRender.Start();
			/*
            var pos = new AnimationFactory.PositionXY[3];
            pos[0].X = 1;
            pos[0].Y = 1;

            pos[1].X = 150;
            pos[1].Y = 200;

            this.ddex.AnimationFactory.MakeLigthBoltAutomatic(pos);

            pos[0].X = 1+300;
            pos[0].Y = 1;

            pos[1].X = 100 + 300;
            pos[1].Y = 100;

            pos[2].X = 150 + 300;
            pos[2].Y = 200;

            this.ddex.AnimationFactory.MakeLigthBolt(pos);
            */
		}

		private void InitPresenterEffects()
		{
			foreach (DDEXNet.DDEX.PRESENT_EFFECTS item in Enum.GetValues(typeof(DDEXNet.DDEX.PRESENT_EFFECTS)).OfType<DDEXNet.DDEX.PRESENT_EFFECTS>())
			{
				flpPresenterEffects.Controls.Add(new PresenterEffectControl(item));
			}
		}

		private void InitAnimations()
		{
			var l = this.GetFrames(320, 384, 5, 6);
			var l2 = this.GetFrames(150, 180, 6, 4);
			var l3 = this.GetFrames(400, 340, 5, 2);

			this.anim = new Animation(1, l, 100, -1);

			this.mouseAnim = new Animation(1, l, 100, -1);

			this.bodyAnim = new Animation(7, l2, 100, -1);

			this.med = new Animation(3071, l3, 100, -1);

			this.CreateApoka();
			this.CreateDescarga();
			this.CreateSpawn();
			this.CreateExplotion();
		}

		private void CreateApoka()
		{
			DDEXNet.DDEX.RECT r = new DDEXNet.DDEX.RECT(0, 0, 145, 145);
			List<AnimationFrame> l = new List<AnimationFrame>();

			for (int i = 0; i < 21; i++)
			{
				l.Add(new AnimationFrame(i + 3000, r));
			}

			this.apoka = new Animation(l, 80, -1);
		}

		private void CreateDescarga()
		{
			DDEXNet.DDEX.RECT r = new DDEXNet.DDEX.RECT(0, 0, 128, 128);
			List<AnimationFrame> l = new List<AnimationFrame>();

			for (int i = 0; i < 15; i++)
			{
				l.Add(new AnimationFrame(i + 3021, r));
			}

			this.descarga = new Animation(l, 80, -1);
		}

		private void CreateExplotion()
		{
			DDEXNet.DDEX.RECT r = new DDEXNet.DDEX.RECT(0, 0, 128, 128);
			List<AnimationFrame> l = new List<AnimationFrame>();

			for (int i = 0; i < 15; i++)
			{
				l.Add(new AnimationFrame(i + 3036, r));
			}

			this.explotion = new Animation(l, 80, -1);
		}

		private void CreateSpawn()
		{
			DDEXNet.DDEX.RECT r = new DDEXNet.DDEX.RECT(0, 0, 128, 128);
			List<AnimationFrame> l = new List<AnimationFrame>();

			for (int i = 0; i < 15; i++)
			{
				l.Add(new AnimationFrame(i + 3051, r));
			}

			this.spawn = new Animation(l, 80, -1);
		}

		private void InitFonts()
		{
			fo = ddex.CreateFont(this.Font);
		}

		private void InitDDEX()
		{
			ddex = new DDEXNet.DDEX(plugin, this.picMain.Handle, "Graficos", new DDEXNet.DDEX.Configuration()
			{
				memory = DDEXNet.DDEX.MemoryMode.DX9_DEFAULT,
				render_mode = DDEXNet.DDEX.RenderMode.DX9_HARDWARE,
				vertex_mode = DDEXNet.DDEX.VertexMode.DX9_SOFTWARE,
				vsync = 0
			});

		}

		private List<DDEXNet.DDEX.RECT> GetFrames(int width, int height, int framesX, int framesY)
		{

			int frameWidth = width / framesX;
			int frameHeight = height / framesY;

			List<DDEXNet.DDEX.RECT> frames = new List<DDEXNet.DDEX.RECT>();
			for (int j = 0; j < framesY; j++)
			{
				for (int i = 0; i < framesX; i++)
				{

					var r = new DDEXNet.DDEX.RECT();
					r.Left = (i * frameWidth);
					r.Top = (j * frameHeight);
					r.Bottom = r.Top + frameHeight;
					r.Right = r.Left + frameWidth;

					frames.Add(r);
				}
			}

			return frames;
		}

		bool moreLoad = false;

		private void DrawWater()
		{
			DDEXNet.DDEX.RECT r = new DDEXNet.DDEX.RECT(0, 0, 222, 76);

			this.ddex.Draw(12041, r, 300, 300);

		}



		private void DrawLights()
		{

			int ancho = 300;
			DDEXNet.DDEX.LightDraw ld;
			DDEXNet.DDEX.LightDraw ld2;

			ld.image = 101;
			ld.rect = new DDEXNet.DDEX.RECT(mouseX - ancho, mouseY - ancho, mouseX + ancho, mouseY + ancho);

			DDEXNet.DDEX.RenderColor rgb = new DDEXNet.DDEX.RenderColor(); ;

			rgb.r = 255;
			rgb.g = 255;
			rgb.b = 255;
			rgb.a = 255;
			if (this.masterAnimation != null)
			{
				rgb = this.masterAnimation.GetColor();
			}

			ld.color = new DDEXNet.DDEX.RenderColor()
			{
				a = 255,
				r = (byte)rgb.r,
				g = (byte)rgb.g,
				b = (byte)rgb.b
			};
			ld.type = 0;
			this.ddex.SetLight(ld);

			ld2.image = 101;
			ld2.rect = new DDEXNet.DDEX.RECT(100, 100, 500, 500);
			ld2.type = 0;
			ld2.color = new DDEXNet.DDEX.RenderColor()
			{
				a = 255,
				r = 255,
				g = 255,
				b = 255
			};

			this.ddex.SetLight(ld2);

		}

		int treeAnim = 0;

		private void DrawTree()
		{
			/*
            this.ddex.Draw(6002, new DDEXNet.DDEX.RECT(0, 233, 300, 270), 275, 233);

            this.ddex.SetRenderEffect(DDEXNet.DDEX.RENDER_EFFECTS.CUSTOM, new DDEX.DDEXFLOAT4()
            {
                r = (treeAnim / 255.0f),
                g = (248 / 255.0f)
            });

            this.ddex.Draw(6002, new DDEXNet.DDEX.RECT(0, 0, 300, 233), 275, 0);
            */
			this.ddex.SetRenderEffect(DDEXNet.DDEX.RENDER_EFFECTS.SWINGING, new DDEX.DDEXFLOAT4()
			{
				r = (treeAnim / 255.0f),
				g = (this.trackSecondValue.Value / 360.0f)
			});

			this.ddex.Draw(6002, new DDEXNet.DDEX.RECT(0, 0, 300, 270), 275, 0);
		}

		private void tTree_Tick(object sender, EventArgs e)
		{
			treeAnim += 2;
		}

		private void tRender_Tick(object sender, EventArgs e)
		{

			Stopwatch s = new Stopwatch();
			if (GetKeyState('A') < 0)
			{
				objX -= 5;
			}
			if (GetKeyState('D') < 0)
			{
				objX += 5;
			}
			if (GetKeyState('W') < 0)
			{
				objY -= 5;
			}
			if (GetKeyState('S') < 0)
			{
				objY += 5;
			}


			if (ddex != null)
			{
				Stopwatch sceneTime = new Stopwatch();

				sceneTime.Start();


				this.ddex.SetMasterLight(this.trackRedLight.Value, this.trackGreenLight.Value, this.trackBlueLight.Value);
				this.ddex.CleanLight();
				this.ddex.CleanSolidObject();
				this.ddex.Clean();

				this.DrawFloor();
				this.DrawWater();

				this.ddex.FlushBackground();

				this.RenderScene();

				this.ddex.FlushScreen();
				this.ddex.Present();

				sceneTime.Stop();

				if ((DateTime.Now - SecondStop).TotalSeconds > 1.0)
				{
					lblFrameTime.Text = sceneTime.ElapsedTicks.ToString() + " ticks " + sceneTime.ElapsedMilliseconds.ToString() + " milli ";
					SecondStop = DateTime.Now;
				}


				// this.lblAMemory.Text = angulo.ToString() + "  " + tangente.ToString();
				this.lblAMemory.Text = this.FormatHBytes((UInt32)this.ddex.GetAvaibleMemory());
			}
		}

		private void DrawTest()
		{
			this.ddex.Draw(30000, new DDEXNet.DDEX.RECT(0, 0, 512, 512), 400, 0);
			/*
            this.ddex.Draw(30001, new DDEXNet.DDEX.RECT(0, 0, 512, 512), 400, 0, new DDEXNet.DDEX.DDEXRGBA()
            {
                a=(byte)trackTest.Value,
                r = 255,
                b = 255,
                g = 255
            });
            */

			DDEXNet.DDEX.LightDraw m;

			m.color.a = (byte)trackTest.Value;
			m.color.r = (byte)trackTest.Value;
			m.color.g = (byte)trackTest.Value;
			m.color.b = (byte)trackTest.Value;

			m.image = 30001;

			m.rect.Left = 400;
			m.rect.Top = 0;
			m.rect.Right = 400 + 512;
			m.rect.Bottom = 512;
			m.type = 0;
			ddex.SetLight(m);
		}

		private DDEXNet.DDEX.RENDER_EFFECTS GetRenderEffect()
		{
			if (this.rbInverColor.Checked)
			{
				return DDEXNet.DDEX.RENDER_EFFECTS.INVERTCOLORS;
			}
			if (this.rbGrayScale.Checked)
			{
				return DDEXNet.DDEX.RENDER_EFFECTS.GREYSCALE;
			}
			if (this.rbRed.Checked)
			{
				return DDEXNet.DDEX.RENDER_EFFECTS.REDSCALE;
			}
			if (this.rbGreen.Checked)
			{
				return DDEXNet.DDEX.RENDER_EFFECTS.GREENSCALE;
			}
			if (this.rbBlue.Checked)
			{
				return DDEXNet.DDEX.RENDER_EFFECTS.BLUESCALE;
			}
			if (this.rbInvertTexture.Checked)
			{
				return DDEXNet.DDEX.RENDER_EFFECTS.INVERTTEXTURE;
			}
			if (this.rbRelief.Checked)
			{
				return DDEXNet.DDEX.RENDER_EFFECTS.RELIEF;
			}
			if (this.rbSwinging.Checked)
			{
				return DDEXNet.DDEX.RENDER_EFFECTS.SWINGING;
			}
			if (this.rbWave.Checked)
			{
				return DDEXNet.DDEX.RENDER_EFFECTS.WAVE;
			}
			if (this.rbCustom.Checked)
			{
				return DDEXNet.DDEX.RENDER_EFFECTS.CUSTOM;
			}

			return DDEXNet.DDEX.RENDER_EFFECTS.NONE;
		}

		private void chkPresentShake_CheckedChanged(object sender, EventArgs e)
		{
			this.UpdatePresentEffects();
		}

		private void UpdatePresentEffects()
		{
			this.ddex.ClearPresentEffects();
			foreach (PresenterEffectControl item in this.flpPresenterEffects.Controls)
			{
				if (item.IsEnable)
				{
					this.ddex.SetPresentEffect(item.Effect, item.GetValues());
				}
			}
		}

		private void chkPresentGreyScale_CheckedChanged(object sender, EventArgs e)
		{
			this.UpdatePresentEffects();
		}

		private void chkVFull_CheckedChanged(object sender, EventArgs e)
		{
			this.UpdatePresentEffects();
		}

		private void chkVibrationSimple_CheckedChanged(object sender, EventArgs e)
		{
			this.UpdatePresentEffects();
		}

		private void DrawFloor()
		{
			DDEXNet.DDEX.RECT r = new DDEXNet.DDEX.RECT(0, 0, 128, 128);

			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					this.ddex.Draw(12052, r, i * 128, j * 128);
				}
			}
		}

		private void trackMasterLight_Scroll(object sender, EventArgs e)
		{
			this.trackRedLight.Value = this.trackMasterLight.Value;
			this.trackGreenLight.Value = this.trackMasterLight.Value;
			this.trackBlueLight.Value = this.trackMasterLight.Value;
		}

		private void chkDrunk_CheckedChanged(object sender, EventArgs e)
		{
			this.UpdatePresentEffects();
		}

		private void btnScreenShot_Click(object sender, EventArgs e)
		{
			Stopwatch s = new Stopwatch();
			s.Start();
			this.ddex.SaveImage(this.Handle, "screenShot.jpg", 1);
			s.Stop();

			Debug.WriteLine(s.ElapsedMilliseconds);
			Debug.WriteLine(s.ElapsedTicks);
		}

		private void btnMoreLoad_Click(object sender, EventArgs e)
		{
			moreLoad = !moreLoad;
		}

		private void btnPreloadAll_Click(object sender, EventArgs e)
		{
			for (int i = 1; i < 0xFFFF; i++)
			{
				this.ddex.PreLoad(i);
			}
		}

		private string FormatHBytes(UInt32 bytes)
		{
			string[] sizes = { "B", "KB", "MB", "GB" };
			double len = (double)bytes;
			int order = 0;
			while (len >= 1024 && order + 1 < sizes.Length)
			{
				order++;
				len = len / 1024;
			}

			// Adjust the format string to your preferences. For example "{0:0.#}{1}" would
			// show a single decimal place, and no space.
			return String.Format("{0:0.##} {1}", len, sizes[order]);
		}

		private void btnSelectColorFrom_Click(object sender, EventArgs e)
		{
			var d = new ColorDialog();

			d.Color = (sender as Button).BackColor;

			d.ShowDialog(this);

			(sender as Button).BackColor = d.Color;
		}

		private void btnSelectColorTo_Click(object sender, EventArgs e)
		{
			var d = new ColorDialog();

			d.Color = (sender as Button).BackColor;

			d.ShowDialog(this);

			(sender as Button).BackColor = d.Color;
		}


		/*MasterAnimate ma;

        double MADuration = 1000;
        double MATimerStep = 25;

        MasterAnimation masterAnimation=null;
        */

		DDEXNet.ColorAnimation masterAnimation;

		private void MakeMasterAnimation(Color fromColor, Color toColor, int? ticks = null)
		{
			/*
            ColorStep to = new ColorStep();
            ColorStep from = new ColorStep();

            this.MADuration = int.Parse(this.txtMasterTIme.Text);
            this.MATimerStep = this.tMasterAnimate.Interval;

            ma.from = fromColor;
            ma.To = toColor;
            ma.Current.FromColor(ma.from);

            to.FromColor(ma.To);
            from.FromColor(ma.from);

            ma.Step.r = Math.Abs(from.r - to.r) / (MADuration / MATimerStep);
            ma.Step.g = Math.Abs(from.g - to.g) / (MADuration / MATimerStep);
            ma.Step.b = Math.Abs(from.b - to.b) / (MADuration / MATimerStep);

            if (from.r > to.r)
            {
                ma.Step.r = -ma.Step.r;
            }

            if (from.g > to.g)
            {
                ma.Step.g = -ma.Step.g;
            }

            if (from.b > to.b)
            {
                ma.Step.b = -ma.Step.b;
            }
             * 
             * this.trackRedLight.Value = GetLightValue(ma.Current.r);
            this.trackBlueLight.Value = GetLightValue(ma.Current.b);
            this.trackGreenLight.Value = GetLightValue(ma.Current.g);

            tMasterAnimate.Start();

            */

			this.masterAnimation = new DDEXNet.ColorAnimation(fromColor.ToDDEXRGBA(), toColor.ToDDEXRGBA(), int.Parse(this.txtMasterTIme.Text), true);


			if (ticks.HasValue)
			{
				this.masterAnimation.Start(ticks.Value);
			}
			else
			{
				this.masterAnimation.Start();
			}

			//var rgb = this.masterAnimation.GetColor();

			//this.trackRedLight.Value = GetLightValue(rgb.r);
			//this.trackBlueLight.Value = GetLightValue(rgb.b);
			//this.trackGreenLight.Value = GetLightValue(rgb.g);

			tMasterAnimate.Start();
		}

		private void btnAnimateMasterColor_Click(object sender, EventArgs e)
		{
			this.MakeMasterAnimation(btnSelectColorFrom.BackColor, btnSelectColorTo.BackColor);
		}

		private int GetLightValue(double val)
		{
			double m = val * 50 / 127;

			int r = (int)m - 50;
			return r < -50 ? 0 : r;
		}

		private byte SumByte(double a, double b)
		{
			var t = a + b;
			if (t > 255)
			{
				t = 255;
			}
			if (t < 0)
			{
				t = 0;
			}
			return (byte)t;
		}


		private void tMasterAnimate_Tick(object sender, EventArgs e)
		{
			/*
            ColorStep result = new ColorStep();

            ma.Current.r = this.SumByte(ma.Current.r,ma.Step.r);
            ma.Current.g = this.SumByte(ma.Current.r,ma.Step.g);
            ma.Current.b = this.SumByte(ma.Current.r,ma.Step.b);

            result.FromColor(ma.To);
            if ((int)ma.Current.r == (int)result.r &&
                (int)ma.Current.b == (int)result.b &&
                (int)ma.Current.g == (int)result.g
                )
            {
                tMasterAnimate.Stop();
                return;
            }
            
            if (
                (ma.Current.GetColor().ToArgb() == ma.To.ToArgb())
             )
            {
                tMasterAnimate.Stop();
                return;
            }
            
            this.trackRedLight.Value = GetLightValue(ma.Current.r);
            this.trackBlueLight.Value = GetLightValue(ma.Current.b);
            this.trackGreenLight.Value = GetLightValue(ma.Current.g);
            */

			this.masterAnimation.Tick();
			/*
                        var rgb = this.masterAnimation.GetColor();

                        this.trackRedLight.Value = GetLightValue(rgb.r);
                        this.trackBlueLight.Value = GetLightValue(rgb.b);
                        this.trackGreenLight.Value = GetLightValue(rgb.g);
                        */
			if (this.masterAnimation.IsComplete())
			{
				tMasterAnimate.Stop();
			}
		}

		private void btnAnimateMasterInvertColor_Click(object sender, EventArgs e)
		{
			this.MakeMasterAnimation(btnSelectColorTo.BackColor, btnSelectColorFrom.BackColor);
		}

		private void label8_Click(object sender, EventArgs e)
		{
			this.txtStartTime.Text = Environment.TickCount.ToString();
		}

		private void btnAnimateTime_Click(object sender, EventArgs e)
		{
			this.MakeMasterAnimation(btnSelectColorFrom.BackColor, btnSelectColorTo.BackColor, int.Parse(this.txtStartTime.Text));
		}

		private void chkFlash_CheckedChanged(object sender, EventArgs e)
		{
			this.UpdatePresentEffects();
		}

		private void trackTest_Scroll(object sender, EventArgs e)
		{
			this.lblTrackTestValue.Text = this.trackTest.Value.ToString();
		}

		private void trackAngle_Scroll(object sender, EventArgs e)
		{
			this.lblTestSecondValue.Text = this.trackSecondValue.Value.ToString();
		}

		private void chkRelief_CheckedChanged(object sender, EventArgs e)
		{
			this.UpdatePresentEffects();
		}

		private void InitScene()
		{
			var tree = new RenderImage(6002, new DDEXNet.DDEX.RECT(0, 0, 300, 270), this.ddex);

			tree.X = 100;
			tree.Y = 100;

			this.AddRenderObject(tree);

			var im2 = new RenderImage(1, new DDEX.RECT(), this.ddex);

			this.AddRenderObject(im2);
		}
		private void AddRenderObject(RenderObject renderObject)
		{
			var control = new RenderObjectControl(renderObject);
			control.Click += RenderObjectControl_Click;
			control.BorderStyle = BorderStyle.FixedSingle;
			this.flpScene.Controls.Add(control);
		}

		private void RenderObjectControl_Click(object sender, EventArgs e)
		{
			RenderObjectControl control = sender as RenderObjectControl;

			this.SelectRenderObjectControl(control);
		}

		private void SelectRenderObjectControl(RenderObjectControl control)
		{
			this.selectedRenderObjectControl = control;
			foreach (RenderObjectControl item in this.flpScene.Controls)
			{
				if (item == control)
				{
					item.BorderStyle = BorderStyle.Fixed3D;
				}
				else
				{
					item.BorderStyle = BorderStyle.FixedSingle;
				}
			}
		}

		private void btnSceneUp_Click(object sender, EventArgs e)
		{
			if (this.selectedRenderObjectControl == null && this.flpScene.Controls.Count != 0)
			{
				return;
			}

			if (this.selectedRenderObjectControl == this.flpScene.Controls[0])
			{
				return;
			}

			int index = this.flpScene.Controls.IndexOf(this.selectedRenderObjectControl);
			this.flpScene.Controls.SetChildIndex(this.selectedRenderObjectControl, index - 1);
		}

		private void btnSceneDown_Click(object sender, EventArgs e)
		{
			if (this.selectedRenderObjectControl == null && this.flpScene.Controls.Count != 0)
			{
				return;
			}

			if (this.selectedRenderObjectControl == this.flpScene.Controls[this.flpScene.Controls.Count - 1])
			{
				return;
			}

			int index = this.flpScene.Controls.IndexOf(this.selectedRenderObjectControl);
			this.flpScene.Controls.SetChildIndex(this.selectedRenderObjectControl, index + 1);
		}

		private void RenderScene()
		{
			RenderObject obj;
			DDEX.RENDER_EFFECTS lastEffect = DDEX.RENDER_EFFECTS.NONE;
			DDEX.DDEXFLOAT4 lastValues;

			lastValues.a = 1;
			lastValues.r = 1;
			lastValues.g = 1;
			lastValues.b = 1;

			this.UpdatePresentEffects();
			this.ddex.DrawBox(new DDEX.RECT(20, 20, 190, 190), new DDEX.RenderColor()
			{
				a = 255,
				r = 255,
				g = 0,
				b = 0
			});
			foreach (RenderObjectControl item in this.flpScene.Controls)
			{
				obj = item.RenderObject;
				if (obj.Visible)
				{
					if ((obj.Effect.HasValue) && (lastEffect != obj.Effect.Value) && (!lastValues.Equals(obj.EffectValues)))
					{
						this.ddex.SetRenderEffect(obj.Effect.Value, obj.EffectValues);
						lastEffect = obj.Effect.Value;
					}

					obj.Draw();
					obj.Tick();
				}
			}

			this.ddex.DrawBox(new DDEX.RECT(10, 10, 200, 200), new DDEX.RenderColor()
			{
				a = 255,
				r = 255,
				g = 255,
				b = 255
			});
		}

		private void btnSceneAdd_Click(object sender, EventArgs e)
		{
			this.cmsScene.Show(this.btnSceneAdd, 0, 0);
		}

		private void mnuAddImageRender_Click(object sender, EventArgs e)
		{
			var control = new CreateControls.RenderImageCreateControl();

			control.ShowDialog(this);

			if (control.SelectedFile > 0)
			{
				this.AddRenderObject(new RenderImage(control.SelectedFile, control.SelectRect, this.ddex));
			}
		}

		private void mnuAddSingleFileAnimation_Click(object sender, EventArgs e)
		{
			var control = new CreateControls.RenderSingleFileAnimationCreateControl();

			control.ShowDialog(this);

			if (control.SelectedFile > 0)
			{
				this.AddRenderObject(new RenderAnimation(control.GeneratedAnimation, this.ddex));
			}
		}

		private void mnuAddMultipleFileAnimation_Click(object sender, EventArgs e)
		{
			var control = new CreateControls.RenderMultiFileAnimationCreateControl();

			control.ShowDialog(this);

			if (control.GeneratedAnimation != null)
			{
				this.AddRenderObject(new RenderAnimation(control.GeneratedAnimation, this.ddex));
			}
		}

		private void mnuAddText_Click(object sender, EventArgs e)
		{
			var control = new CreateControls.RenderTextCreateControl();

			control.ShowDialog(this);

			if (control.TextValue != string.Empty)
			{
				this.AddRenderObject(new RenderText(control.TextValue, this.ddex.CreateFont(control.font), this.ddex));
			}
		}
	}
}
