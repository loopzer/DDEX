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
    public partial class RenderImageCreateControl : Form
    {
        public int SelectedFile { get; set; }

        public DDEXNet.DDEX.RECT SelectRect { get; set; }

        enum FileType
        {
            NONE, BMP, PNG
        }

        public RenderImageCreateControl()
        {
            InitializeComponent();
        }

        private FileType CheckFile(int fileNum)
        {
            if (System.IO.File.Exists("Graficos\\" + fileNum.ToString() + ".bmp"))
            {
                return FileType.BMP;
            }
            if (System.IO.File.Exists("Graficos\\" + fileNum.ToString() + ".png"))
            {
                return FileType.PNG;
            }

            return FileType.NONE;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

            if (this.ImageView.SelectedItems.Count == 1)
            {
                this.SelectedFile = int.Parse(this.ImageView.SelectedItems[0].Text);
            }
            else
            {
                this.SelectedFile = 0;
            }


            if (this.SelectedFile <= 0)
            {
                MessageBox.Show(this, "Image not found", "Error", MessageBoxButtons.OK);
            }
            else
            {
                Bitmap img = null;
                switch (this.CheckFile(this.SelectedFile))
                {
                    case FileType.BMP:
                        img = new System.Drawing.Bitmap("Graficos\\" + this.SelectedFile.ToString() + ".bmp");
                        break;
                    case FileType.PNG:
                        img = new System.Drawing.Bitmap("Graficos\\" + this.SelectedFile.ToString() + ".png");
                        break;
                    default:
                        break;
                }

                this.SelectRect = new DDEXNet.DDEX.RECT(0, 0, img.Width, img.Height);
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.SelectedFile = 0;
            this.Close();
        }

        private void RenderImageCreateControl_Load(object sender, EventArgs e)
        {

            List<int> imageNum = new List<int>(); ;
            foreach (var item in System.IO.Directory.GetFiles("Graficos\\").Where(x => x.EndsWith("png", StringComparison.OrdinalIgnoreCase) || x.EndsWith("bmp", StringComparison.OrdinalIgnoreCase)))
            {
                int v = 0;

                if (int.TryParse(System.IO.Path.GetFileNameWithoutExtension(item), out v))
                {
                    imageNum.Add(v);
                }
            }

            foreach (var item in imageNum)
            {
                switch (this.CheckFile(item))
                {
                    case FileType.BMP:
                        this.imageList.Images.Add(item.ToString(), new System.Drawing.Bitmap("Graficos\\" + item.ToString() + ".bmp"));
                        break;
                    case FileType.PNG:
                        this.imageList.Images.Add(item.ToString(), new System.Drawing.Bitmap("Graficos\\" + item.ToString() + ".png"));
                        break;
                    default:
                        break;
                }

                this.ImageView.Items.Add(item.ToString(), item.ToString());
            }
        }
    }
}
