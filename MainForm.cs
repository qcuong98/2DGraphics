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
        private const int MAX_LAYER = 1000;

        private const int SELECT = 0;
        private const int LINE = 1;
        private const int CIRCLE = 2;
        private const int ELLIPSE = 3;
        private const int RECTANGLE = 4;
        private const int BEZIER = 5;

        int nGraphicsPath;
        private GraphicsPath[] myGraphicsPaths;
        private Pen[] myPens;
        private Brush[] myBrushes;

        int nPoint;
        private Point[] Points;

        bool MouseDowned;

        public MainForm()
        {
            InitializeComponent();
            
            nGraphicsPath = 0;
            myGraphicsPaths = new GraphicsPath[MAX_LAYER];
            myPens = new Pen[MAX_LAYER];
            myBrushes = new Brush[MAX_LAYER];

            nPoint = 0;
            Points = new Point[100];

            /* init background of PictureBoxes*/
            pictureBoxBrushColor.BackColor = Color.Navy;
            pictureBoxPenColor.BackColor = Color.Red;
            pictureBox.BackColor = Color.White;

            //myGraphicsPaths[0] = new GraphicsPath();
            //myGraphicsPaths[0].AddBezier(new PointF(100, 100), new PointF(200, 200), new PointF(300, 100), new PointF(100, 400));
            //myBrushes[0] = new SolidBrush(Color.Black);
            //myPens[0] = new Pen(Brushes.Red);
            //nGraphicsPath = 1;
            //RefreshGraphics();
        }

        private int GetObject()
        {
            if (radioButtonLine.Checked)
                return LINE;
            if (radioButtonCircle.Checked)
                return CIRCLE;
            if (radioButtonEllipse.Checked)
                return ELLIPSE;
            if (radioButtonRectangle.Checked)
                return RECTANGLE;
            if (radioButtonBezier.Checked)
                return BEZIER;
            return SELECT;
        }

        private int NoOfControlPoints(int Shape)
        {
            switch (Shape)
            {
                case LINE:
                case CIRCLE:
                case ELLIPSE:
                case RECTANGLE:
                    return 2;
                case BEZIER:
                    return 4;
            }
            return 0;
        }

        private float CheckValidFloat(string p)
        {
            float i = -1;
            try
            {
                i = (float)System.Convert.ToDouble(p);
            }
            catch (Exception)
            {
                MessageBox.Show("Width is invalid! Set width = 1.");
                textBoxWidth.Text = "1";
                return -1;
            }
            if (i <= 0)
            {
                MessageBox.Show("Width have to be greater than 0! Set width = 1.");
                textBoxWidth.Text = "1";
                return -1;
            }
            return i;
        }

        private Pen GetPen()
        {
            Pen myPen = new Pen(pictureBoxPenColor.BackColor);

            if (radioButtonSolid.Checked)
            {
                float wid = CheckValidFloat(textBoxWidth.Text);
                myPen.Width = (wid == -1 ? 1 : wid);
            }
            else if (radioButtonDot.Checked)
                myPen.DashPattern = new float[] { 1F, 5F };
            else if (radioButtonDash.Checked)
                myPen.DashPattern = new float[] { 10F, 5F };
            else if (radioButtonDashDot.Checked)
                myPen.DashPattern = new float[] { 10F, 5F, 1F, 5F };
            else if (radioButtonDashDotDot.Checked)
                myPen.DashPattern = new float[] { 10F, 5F, 1F, 5F, 1F, 5F };
            else if (radioButtonNull.Checked)
                myPen.Color = Color.Transparent;

            return myPen;
        }

        private Brush GetBrush()
        {
            if (radioButtonBrushTransparent.Checked)
            {
                SolidBrush mySolidBrush = new SolidBrush(Color.Transparent);
                return mySolidBrush;
            }
            if (radioButtonBrushColor.Checked)
            {
                SolidBrush mySolidBrush = new SolidBrush(pictureBoxBrushColor.BackColor);
                return mySolidBrush;
            }

            string dir = "";
            if (radioButtonBrushPattern1.Checked)
                dir = @"C:\Users\qcuong98\Documents\Visual Studio 2013\Projects\ComputerGraphics\Graphics2D\pattern_1.bmp";
            else if (radioButtonBrushPattern2.Checked)
                dir = @"C:\Users\qcuong98\Documents\Visual Studio 2013\Projects\ComputerGraphics\Graphics2D\pattern_2.bmp";
            else if (radioButtonBrushPattern3.Checked)
                dir = @"C:\Users\qcuong98\Documents\Visual Studio 2013\Projects\ComputerGraphics\Graphics2D\pattern_3.bmp";
            Bitmap myImage = (Bitmap)Image.FromFile(dir);
            TextureBrush myTextureBrush = new TextureBrush(myImage);
            return myTextureBrush;
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (NoOfControlPoints(GetObject()) == 2)
            {
                Points[0] = new Point(e.X, e.Y);
            }
            else
            {
                Points[nPoint] = new Point(e.X, e.Y);
                ++nPoint;
                if (nPoint == NoOfControlPoints(GetObject()))
                {
                    Render();
                    nPoint = 0;
                }
            }

            MouseDowned = true;
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseDowned && NoOfControlPoints(GetObject()) == 2)
            {
                Points[1] = new Point(e.X, e.Y);
                Render();
                if (GetObject() != SELECT)
                    --nGraphicsPath;
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (NoOfControlPoints(GetObject()) == 2)
            {
                Points[1] = new Point(e.X, e.Y);
                Render();
            }
            MouseDowned = false;
        }

        private static float sqr(float x) {
            return x * x;
        }

        private void Render()
        {
            if (GetObject() == LINE)
                AddGraphicsPath(new Line(Points[0], Points[1]));
            else if (GetObject() == CIRCLE) {
                float r = (float)Math.Sqrt(sqr(Points[1].X - Points[0].X) + sqr(Points[1].Y - Points[0].Y));
                AddGraphicsPath(new Ellipse(new PointF(Points[0].X - r, Points[0].Y - r), 2 * r, 2 * r));
            }
            else if (GetObject() == ELLIPSE)
            {
                PointF a = new PointF(Math.Min(Points[0].X, Points[1].X), Math.Min(Points[0].Y, Points[1].Y));
                int wid = Math.Abs(Points[1].X - Points[0].X), hgt = Math.Abs(Points[1].Y - Points[0].Y);
                AddGraphicsPath(new Ellipse(a, wid, hgt));
            }
            else if (GetObject() == RECTANGLE)
            {
                PointF a = new PointF(Math.Min(Points[0].X, Points[1].X), Math.Min(Points[0].Y, Points[1].Y));
                PointF b = new PointF(Math.Max(Points[0].X, Points[1].X), Math.Max(Points[0].Y, Points[1].Y));
                AddGraphicsPath(new Rectangle(a, b));
            }
            else if (GetObject() == BEZIER)
            {
                AddGraphicsPath(new Bezier(Points[0], Points[1], Points[2], Points[3]));
            }
            if (GetObject() != SELECT)
                RefreshGraphics();
        }

        private void AddGraphicsPath(Shape myShape)
        {
            myGraphicsPaths[nGraphicsPath] = new GraphicsPath();
            myShape.AddTo(myGraphicsPaths[nGraphicsPath]);
            myPens[nGraphicsPath] = GetPen();
            myBrushes[nGraphicsPath] = GetBrush();
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
                {
                    gr.FillPath(myBrushes[i], myGraphicsPaths[i]);
                    gr.DrawPath(myPens[i], myGraphicsPaths[i]);
                }
            }
            pictureBox.Image = bm;
            pictureBox.Refresh();
        }

        private void buttonSaveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog mySaveFileDialog = new SaveFileDialog();
            mySaveFileDialog.Title = "Save File of Objects";    
            mySaveFileDialog.CheckPathExists = true;  
            mySaveFileDialog.DefaultExt = "shp";  
            mySaveFileDialog.Filter = "Shape files (*.shp)|*.shp|All files (*.*)|*.*";  
            mySaveFileDialog.FilterIndex = 1;  
            mySaveFileDialog.RestoreDirectory = true;
            if (mySaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fOutput = mySaveFileDialog.FileName;
            }
        }

        private void buttonLoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog myOpenFileDialog = new OpenFileDialog();
            myOpenFileDialog.Title = "Load File of Objects";
            myOpenFileDialog.CheckFileExists = true;
            myOpenFileDialog.CheckPathExists = true;
            myOpenFileDialog.DefaultExt = "shp";
            myOpenFileDialog.Filter = "Shape files (*.shp)|*.shp|All files (*.*)|*.*";
            myOpenFileDialog.FilterIndex = 1;
            myOpenFileDialog.RestoreDirectory = true;
            if (myOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fInput = myOpenFileDialog.FileName;
            }
        }

        private void pictureBoxBrushColor_Click(object sender, EventArgs e)
        {
            ColorDialog myColorDialog = new ColorDialog();
            myColorDialog.AllowFullOpen = false;  
            myColorDialog.AnyColor = true;  
            myColorDialog.SolidColorOnly = false;  
            myColorDialog.Color = Color.Red;

            if (myColorDialog.ShowDialog() == DialogResult.OK)
                pictureBoxBrushColor.BackColor = myColorDialog.Color;
        }

        private void pictureBoxPenColor_Click(object sender, EventArgs e)
        {
            ColorDialog myColorDialog = new ColorDialog();
            myColorDialog.AllowFullOpen = false;
            myColorDialog.AnyColor = true;
            myColorDialog.SolidColorOnly = false;
            myColorDialog.Color = Color.Red;

            if (myColorDialog.ShowDialog() == DialogResult.OK)
                pictureBoxPenColor.BackColor = myColorDialog.Color;
        }  
    }
}
