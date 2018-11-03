using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics2D
{
    public partial class MainForm : Form
    {
        private const int MAX_LAYER = 100;
        private Graphics myGraphics;
        private GraphicsPath[] myGraphicsPath;
        int nGraphicsPath;
        int x0, y0, x1, y1;
        bool MouseDowned;

        public MainForm()
        {
            InitializeComponent();

            /* white background */
            int wid = pictureBox.ClientSize.Width;
            int hgt = pictureBox.ClientSize.Height;
            Bitmap bm = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.Clear(Color.White);
            }
            pictureBox.Image = bm;
            pictureBox.Refresh();
            
            nGraphicsPath = 0;
            myGraphicsPath = new GraphicsPath[MAX_LAYER];
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            x0 = e.X;
            y0 = e.Y;
            MouseDowned = true;
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseDowned)
            {
                x1 = e.X;
                y1 = e.Y;
                AddLine(new Point(x0, y0), new Point(x1, y1));
                --nGraphicsPath;
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            x1 = e.X;
            y1 = e.Y;
            AddLine(new Point(x0, y0), new Point(x1, y1));
            MouseDowned = false;
        }

        private void AddLine(Point a, Point b) {
            Pen myPen = new Pen(Brushes.Red);
            GraphicsPath tmpGraphicsPath = new GraphicsPath();
            tmpGraphicsPath.AddLine(a, b);            

            myGraphicsPath[nGraphicsPath] = tmpGraphicsPath;
            ++nGraphicsPath;

            tmpGraphicsPath = new GraphicsPath();

            for (int i = 0; i < nGraphicsPath; ++i)
            {
                tmpGraphicsPath.AddPath(myGraphicsPath[i], false);
            }

            int wid = pictureBox.ClientSize.Width;
            int hgt = pictureBox.ClientSize.Height;
            Bitmap bm = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.Clear(Color.White);
                gr.DrawPath(myPen, tmpGraphicsPath);
            }
            pictureBox.Image = bm;
            pictureBox.Refresh();
        }


    }
}
