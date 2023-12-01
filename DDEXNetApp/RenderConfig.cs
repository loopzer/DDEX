using DDEXNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DDEXNetApp
{
    public partial class RenderConfig : Form
    {
        public RenderObject RenderObject { get; private set; }

        private int mouseX;
        private int mouseY;

        public RenderConfig()
        {
            InitializeComponent();
            this.cbEffects.SelectedValueChanged += cbEffects_SelectedValueChanged;
            this.KeyUp += RenderConfig_KeyUp;
        }

        void RenderConfig_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        void cbEffects_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbEffects.SelectedItem == null)
            {
                return;
            }

            this.RenderObject.Effect = (DDEXNet.DDEX.RENDER_EFFECTS)Enum.Parse(typeof(DDEXNet.DDEX.RENDER_EFFECTS), (string)cbEffects.SelectedItem);
        }

        public RenderConfig(RenderObject renderObject)
            : this()
        {
            this.RenderObject = renderObject;
            this.LoadData();
            this.SetObjectValues();
        }

        private void SetObjectValues()
        {

            DDEX.RenderColor rgba = this.RenderObject.Color;

            this.colorDialog.Color = Color.FromArgb(rgba.a, rgba.r, rgba.g, rgba.b);

            this.nudAlpha.Value = rgba.a;

            for (int i = 0; i < this.cbEffects.Items.Count - 1; i++)
            {
                if ((string)this.cbEffects.Items[i] == this.RenderObject.Effect.ToString())
                {
                    this.cbEffects.SelectedIndex = i;
                    break;
                }
            }

            this.nudRadius.Value = this.RenderObject.LightRadius;
            this.chkAsLight.Checked = this.RenderObject.AsLight;
        }

        private void LoadData()
        {
            foreach (var item in Enum.GetNames(typeof(DDEXNet.DDEX.RENDER_EFFECTS)))
            {
                this.cbEffects.Items.Add(item);
            }

            this.cbEffects.SelectedIndex = 0;
        }

        private void picLocation_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouseX = e.X;
            this.mouseY = e.Y;
        }

        private void picLocation_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void picLocation_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                int newX = mouseX - e.X;
                int newY = mouseY - e.Y;

                this.RenderObject.X += -newX;
                this.RenderObject.Y += -newY;

                this.mouseX = e.X;
                this.mouseY = e.Y;
            }
        }

        private void UpdateColor()
        {
            var color = this.colorDialog.Color;

            this.btnColor.BackColor = color;

            DDEX.RenderColor rgba;

            rgba.r = color.R;
            rgba.g = color.G;
            rgba.b = color.B;
            rgba.a = (byte)this.nudAlpha.Value;

            this.RenderObject.SetColor(rgba);
        }


        private void btnColor_Click(object sender, EventArgs e)
        {
            this.colorDialog.ShowDialog(this);
            this.UpdateColor();
        }

        private void nudAlpha_ValueChanged(object sender, EventArgs e)
        {
            this.UpdateColor();
        }

        private void trackValue1_Scroll(object sender, EventArgs e)
        {
            this.lblTrackValue1.Text = this.trackValue1.Value.ToString();
            this.UpdateEffectValues();
        }

        private void UpdateEffectValues()
        {
            DDEXNet.DDEX.DDEXFLOAT4 effectValues = new DDEX.DDEXFLOAT4();

            effectValues.r = this.trackValue1.Value / 360.0f;
            effectValues.g = this.trackValue2.Value / 360.0f;

            this.RenderObject.SetEffectValues(effectValues);
        }

        private void trackValue2_Scroll(object sender, EventArgs e)
        {
            this.lblTrackValue2.Text = this.trackValue2.Value.ToString();
            this.UpdateEffectValues();
        }

        private void chkAsLight_CheckedChanged(object sender, EventArgs e)
        {
            this.RenderObject.AsLight = this.chkAsLight.Checked;
        }

        private void nudRadius_ValueChanged(object sender, EventArgs e)
        {
            this.RenderObject.LightRadius = (int)nudRadius.Value;
        }

        private void chkNegativeLight_CheckedChanged(object sender, EventArgs e)
        {
            this.RenderObject.LightType = this.chkNegativeLight.Checked ? (byte)1 : (byte)0;
        }
    }
}
