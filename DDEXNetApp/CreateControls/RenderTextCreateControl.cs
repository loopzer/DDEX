using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DDEXNetApp.CreateControls
{
    public partial class RenderTextCreateControl : Form
    {
        public RenderTextCreateControl()
        {
            InitializeComponent();
            this.TextValue = string.Empty;
        }

        public string TextValue { get; set; }

        public Font font { get; set; }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            this.TextValue = txtValue.Text;
            this.font = this.fontDialog.Font;
            if (this.TextValue != string.Empty)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show(this,"Text is empty","Error", MessageBoxButtons.OK);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.TextValue = string.Empty;
            this.Close();
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            this.fontDialog.ShowDialog(this);

            this.txtValue.Font = this.fontDialog.Font;
            
        }
    }
}
