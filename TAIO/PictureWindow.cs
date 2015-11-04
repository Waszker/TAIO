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
    /// <summary>
    /// Window used to show input and output graph
    /// </summary>
    public partial class PictureWindow : Form
    {
        public PictureWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Takes name of window and name of automaton (to get the right image)
        /// </summary>
        /// <param name="windowName"></param>
        /// <param name="automatonName"></param>
        public PictureWindow(string windowName, string automatonName)
        {
            InitializeComponent();
            int diffw = this.Width - pictureBox1.Width;
            int diffh = this.Height - pictureBox1.Height;
            pictureBox1.Image = new Bitmap(automatonName);
            this.Size = new System.Drawing.Size(pictureBox1.Image.Width+diffw, pictureBox1.Image.Height + diffh);
            pictureBox1.Dock = DockStyle.Fill;
            this.Text = windowName;
        }
    }
}
