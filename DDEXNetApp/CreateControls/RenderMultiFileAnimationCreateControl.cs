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
    public partial class RenderMultiFileAnimationCreateControl : Form
    {
        enum FileType
        {
            NONE, BMP, PNG
        }

        public Animation GeneratedAnimation { get; private set; }

        public RenderMultiFileAnimationCreateControl()
        {
            InitializeComponent();
            this.GeneratedAnimation = null;
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

            if (this.ImageView.SelectedItems.Count <= 1)
            {
                MessageBox.Show(this, "Image not found", "Error", MessageBoxButtons.OK);

            }
            else
            {


                int firstFile = int.Parse(this.ImageView.SelectedItems[0].Text);

                Bitmap img = null;
                switch (this.CheckFile(firstFile))
                {
                    case FileType.BMP:
                        img = new System.Drawing.Bitmap("Graficos\\" + firstFile.ToString() + ".bmp");
                        break;
                    case FileType.PNG:
                        img = new System.Drawing.Bitmap("Graficos\\" + firstFile.ToString() + ".png");
                        break;
                    default:
                        break;
                }

                DDEXNet.DDEX.RECT rect = new DDEXNet.DDEX.RECT(0, 0, img.Width, img.Height);

                List<AnimationFrame> ll = new List<AnimationFrame>();

                foreach (ListViewItem item in this.ImageView.SelectedItems)
                {

                    ll.Add(new AnimationFrame(int.Parse(item.Text), rect));
                }

                this.GeneratedAnimation = new Animation(ll, (int)this.nudFrameTime.Value, -1);

                this.Close();
            }
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RenderSingleFileAnimationCreateControl_Load(object sender, EventArgs e)
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
