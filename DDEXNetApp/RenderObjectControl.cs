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
    public partial class RenderObjectControl : UserControl
    {

        public RenderObject RenderObject { get; private set; }

        public RenderObjectControl()
        {
            InitializeComponent();
        }

        public RenderObjectControl(RenderObject renderObject)
            : this()
        {
            this.RenderObject = renderObject;
            this.lblName.Text = this.RenderObject.ToString();
        }

        private void btnConfigure_Click(object sender, EventArgs e)
        {
            new RenderConfig(this.RenderObject).ShowDialog(this);
        }
    }
}
