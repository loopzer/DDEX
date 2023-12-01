using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DDEXNetApp
{
    public partial class PresenterEffectControl : UserControl
    {


        public DDEXNet.DDEX.PRESENT_EFFECTS Effect { get; private set; }

        public bool IsEnable
        {
            get
            {
                return this.chkEffect.Checked;
            }
        }


        public PresenterEffectControl()
        {
            InitializeComponent();
        }

        public PresenterEffectControl(DDEXNet.DDEX.PRESENT_EFFECTS effect)
        {
            InitializeComponent();
            this.Effect = effect;
            this.chkEffect.Text = this.Effect.ToString();
        }

        public DDEXNet.DDEX.DDEXFLOAT4 GetValues()
        {
            return new DDEXNet.DDEX.DDEXFLOAT4()
            {
                r = (int)nudValue1.Value / 1000.0f,
                g = (int)nudValue2.Value / 1000.0f,
                b = (int)nudValue3.Value / 1000.0f
            };
        }

    }
}
