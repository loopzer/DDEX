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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnLoadPlugins_Click(object sender, EventArgs e)
        {
            var files = System.IO.Directory.GetFiles(Environment.CurrentDirectory);

            this.listBoxPlugins.Items.Clear();

            foreach (var item in files)
            {
                if (item.Contains("DDEX_") && item.Contains(".dll"))
                {
                    this.listBoxPlugins.Items.Add(System.IO.Path.GetFileName(item));
                }
            }
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            if (this.listBoxPlugins.SelectedItem != null)
            {
                var frm = new FrmDDEX(this.listBoxPlugins.SelectedItem.ToString());
                frm.Show();
            }
        }

        private void btnLaunchDefferal_Click(object sender, EventArgs e)
        {
            if (this.listBoxPlugins.SelectedItem != null)
            {
                var frm = new FrmDDEX(this.listBoxPlugins.SelectedItem.ToString(), true);
                frm.Show();
            }
        }
    }
}
