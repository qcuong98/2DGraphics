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
        private const int SELECT = 0;
        private const int LINE = 1;
        private const int CIRCLE = 2;
        private const int RECTANGLE = 3;

        private GraphicsPath[] myGraphicsPaths;
        private Pen[] myPens;
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
            myGraphicsPaths = new GraphicsPath[MAX_LAYER];
            myPens = new Pen[MAX_LAYER];
        }

        private int GetObject()
        {
            if (radioButtonLine.Checked)
                return LINE;
            if (radioButtonCircle.Checked)
                return CIRCLE;
            if (radioButtonRectangle.Checked)
                return RECTANGLE;
            return SELECT;
        }

        private int CheckValidInt(string p)
        {
            int i = -1;
            try
            {
                i = System.Convert.ToInt32(p);
            }
            catch (FormatException)
            {
                return -1;
            }
            catch (OverflowException)
            {
                return -1;
            }
            if (i < 1)
                return -1;
            return i;
        }

        private Pen GetPen()
        {
            Pen myPen = new Pen(Color.Red);

            if (radioButtonRed.Checked)
                myPen.Color = Color.Red;
            else if (radioButtonGreen.Checked)
                myPen.Color = Color.Green;
            else if (radioButtonBlue.Checked)
                myPen.Color = Color.Blue;

            if (radioButtonSolid.Checked)
            {
                int wid = CheckValidInt(textBoxWidth.Text);
                if (wid != -1)
                    myPen.Width = wid;
            } else if (radioButtonDot.Checked)
                myPen.DashPattern = new float[] { 1F, 5F };
            else if (radioButtonDash.Checked)
                myPen.DashPattern = new float[] { 10F, 5F };
            else if (radioButtonDashDot.Checked)
                myPen.DashPattern = new float[] { 10F, 5F, 1F, 5F };
            else if (radioButtonDashDotDot.Checked)
                myPen.DashPattern = new float[] { 10F, 5F, 1F, 5F, 1F, 5F };

            return myPen;
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
                if (GetObject() == LINE)
                    AddLine(new Point(x0, y0), new Point(x1, y1));
                else if (GetObject() == CIRCLE)
                    AddCircle(new Point(x0, y0), (float)Math.Sqrt((x1 - x0) * (x1 - x0) + (y1 - y0) * (y1 - y0)));
                else if (GetObject() == RECTANGLE)
                    AddRectangle(new Point(x0, y0), new Point(x1, y1));
                if (GetObject() != SELECT)
                {
                    RefreshGraphics();
                    --nGraphicsPath;
                }
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            x1 = e.X;
            y1 = e.Y;
            if (GetObject() == LINE)
                AddLine(new Point(x0, y0), new Point(x1, y1));
            else if (GetObject() == CIRCLE)
                AddCircle(new Point(x0, y0), (float)Math.Sqrt((x1 - x0) * (x1 - x0) + (y1 - y0) * (y1 - y0)));
            else if (GetObject() == RECTANGLE)
                AddRectangle(new Point(x0, y0), new Point(x1, y1));
            RefreshGraphics();
            MouseDowned = false;
        }

        private void AddLine(Point a, Point b) {
            myGraphicsPaths[nGraphicsPath] = new GraphicsPath();
            myGraphicsPaths[nGraphicsPath].AddLine(a, b);
            myPens[nGraphicsPath] = GetPen();
            ++nGraphicsPath;
        }

        private void AddCircle(Point a, float r)
        {
            myGraphicsPaths[nGraphicsPath] = new GraphicsPath();
            RectangleF circleRect = new RectangleF(a.X - r, a.Y - r, r * 2, r * 2);
            myGraphicsPaths[nGraphicsPath].AddEllipse(circleRect);
            myPens[nGraphicsPath] = GetPen();
            ++nGraphicsPath;
        }

        private void AddRectangle(Point a, Point b)
        {
            
            myGraphicsPaths[nGraphicsPath] = new GraphicsPath();
            Point p1 = new Point(Math.Min(a.X, b.X), Math.Min(a.Y, b.Y));
            RectangleF myRectangle = new RectangleF(p1.X, p1.Y, Math.Abs(a.X - b.X), Math.Abs(a.Y - b.Y));
            myGraphicsPaths[nGraphicsPath].AddRectangle(myRectangle);
            myPens[nGraphicsPath] = GetPen();
            ++nGraphicsPath;
        }

        private void RefreshGraphics()
        {
            int wid = pictureBox.ClientSize.Width;
            int hgt = pictureBox.ClientSize.Height;
            Bitmap bm = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.Clear(Color.White);
                for (int i = 0; i < nGraphicsPath; ++i)
                    gr.DrawPath(myPens[i], myGraphicsPaths[i]);
            }
            pictureBox.Image = bm;
            pictureBox.Refresh();
        }
    }
}
