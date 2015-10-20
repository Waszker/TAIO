using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TAIO
{
    public partial class PictureWindow : Form
    {
        public PictureWindow()
        {
            InitializeComponent();
        }

        public PictureWindow(string windowName, string automatonName)
        {
            InitializeComponent();

            pictureBox1.Image = new Bitmap(automatonName);
            pictureBox1.Dock = DockStyle.Fill;
            this.Text = windowName;
        }
    }
}
