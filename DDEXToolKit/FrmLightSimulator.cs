using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DDEXNet;
namespace DDEXToolKit {
    public partial class FrmLightSimulator : Form {
        public FrmLightSimulator() {
            InitializeComponent();
        }

        private DDEXNet.DDEX ddex;

        private void FrmLightSimulator_Load(object sender, EventArgs e) {
            this.InitDDEX();
            this.UpdateData();
            tRender.Start();
        }

        private void InitDDEX() {
            ddex = new DDEXNet.DDEX("DDEX_DX9", this.picMain.Handle, "Graficos", new DDEXNet.DDEX.Configuration() {
                memory = DDEXNet.DDEX.MemoryMode.DX9_DEFAULT,
                render_mode = DDEXNet.DDEX.RenderMode.DX9_HARDWARE,
                vertex_mode = DDEXNet.DDEX.VertexMode.DX9_SOFTWARE,
                vsync = 1
            });


        }

        private void tRender_Tick(object sender, EventArgs e) {
            this.RenderFrame();
        }

        private void RenderFrame() {
            if (ddex != null) {
                this.ddex.SetMasterLight(this.trackRedLight.Value, this.trackGreenLight.Value, this.trackBlueLight.Value);
                this.ddex.CleanLight();
                this.ddex.CleanSolidObject();
                this.ddex.Clean();

                this.DrawFloor();

                this.ddex.FlushBackground();

                this.DrawTree();
                this.ddex.Draw(15147, new DDEXNet.DDEX.RECT(0, 0, 32, 32), 136, 136);

                this.DrawLights();
                this.ddex.FlushScreen();

                this.ddex.Present();
            }
        }

        private void DrawTree() {
            this.ddex.Draw(6002, new DDEXNet.DDEX.RECT(0, 0, 32, 32), 275, 0);
        }

        private void DrawLights() {

            DDEXNet.DDEX.LightDraw ld;

            ld.image = 103;
            ld.rect = new DDEXNet.DDEX.RECT(226 - this.trackFireDiameter.Value, 226 - this.trackFireDiameter.Value, this.trackFireDiameter.Value*2, this.trackFireDiameter.Value*2);
            ld.type = 0;
            DDEXNet.DDEX.RenderColor rgb = new DDEXNet.DDEX.RenderColor(); ;

            rgb.r = (byte)this.trackFireRed.Value;
            rgb.g = (byte)this.trackFireGreen.Value;
            rgb.b = (byte)this.trackFireBlue.Value;
            rgb.a = 255;

            ld.color = rgb;

            this.ddex.SetLight(ld);

        }

        private void DrawFloor() {
            DDEXNet.DDEX.RECT r = new DDEXNet.DDEX.RECT(0, 0, 128, 128);

            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    this.ddex.Draw(12052, r, i * 128, j * 128);
                }
            }
        }

        private void FrmLightSimulator_FormClosed(object sender, FormClosedEventArgs e) {
            this.ddex.Dispose();
        }

        private void Tracks_Scroll(object sender, EventArgs e) {
            this.UpdateData();
        }

        private void UpdateData() {
            this.UpdateData(this.trackRedLight, this.lblRedLightValue);
            this.UpdateData(this.trackGreenLight, this.lblGreenLightValue);
            this.UpdateData(this.trackBlueLight, this.lblBlueLightValue);

            this.UpdateData(this.trackFireRed, this.lblRedFireLightValue);
            this.UpdateData(this.trackFireGreen, this.lblGreenFireLightValue);
            this.UpdateData(this.trackFireBlue, this.lblBlueFireLightValue);
            this.UpdateData(this.trackFireDiameter, this.lblFireDiameterValue);
        }


        private void UpdateData(TrackBar track, Label lbl) {
            lbl.Text = track.Value.ToString();
        }

        private void TrackMaster_Scroll(object sender, EventArgs e) {
            this.trackRedLight.Value = this.trackMasterLight.Value;
            this.trackGreenLight.Value = this.trackMasterLight.Value;
            this.trackBlueLight.Value = this.trackMasterLight.Value;

            this.UpdateData();
        }

        private void FireMaster_Scroll(object sender, EventArgs e) {
            this.trackFireRed.Value = this.trackFireMaster.Value;
            this.trackFireGreen.Value = this.trackFireMaster.Value;
            this.trackFireBlue.Value = this.trackFireMaster.Value;

            this.UpdateData();
        }

    }
}
