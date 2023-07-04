using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UCPic
{
    public partial class ImgViewForm : Form
    {
        public ImgViewForm()
        {
            InitializeComponent();
        }
        public ImgViewForm(Image image)
        {
            InitializeComponent();
            var imgMaxHeight = image.Height;
            var imgMaxWidth = image.Width;
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            //button1.Location = new Point(10, 10);
            this.Height = imgMaxHeight + 100;
            this.Width = imgMaxWidth + 10;
            this.pictureBox1.Height = imgMaxHeight;
            this.pictureBox1.Width = imgMaxWidth;
            this.pictureBox1.Image = image;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ImgViewForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
