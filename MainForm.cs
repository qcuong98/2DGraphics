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

        private const int LINE = 1;
        private const int CIRCLE = 2;
        private const int ELLIPSE = 3;
        private const int RECTANGLE = 4;
        private const int BEZIER = 5;
        private const int POLYGON = 6;
        private const int STRING = 7;
        private const int PARABOLA = 8;
        private const int HYPERBOLA = 9;

        public static int PB_WIDTH;
        public static int PB_HEIGHT;

        int nLayer;
        private Layer[] myLayers;

        int nPoint;
        private PointF[] Points;

        bool MouseDowned;

        public MainForm()
        {
            InitializeComponent();

            nLayer = 0;
            myLayers = new Layer[MAX_LAYER];

            nPoint = 0;
            Points = new PointF[100];

            /* init background of PictureBoxes*/
            pictureBoxBrushColor.BackColor = Color.Navy;
            pictureBoxPenColor.BackColor = Color.Red;
            pictureBox.BackColor = Color.White;

            PB_WIDTH = pictureBox.ClientSize.Width;
            PB_HEIGHT = pictureBox.ClientSize.Height;
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
            if (radioButtonPolygon.Checked)
                return POLYGON;
            if (radioButtonString.Checked)
                return STRING;
            if (radioButtonParabola.Checked)
                return PARABOLA;
            return 0;
        }

        private int NoOfControlPoints(int Shape)
        {
            switch (Shape)
            {
                case BEZIER:
                    return 4;
                case POLYGON:       
                    return (textBoxPolygon.Text == "" ? 3 : System.Convert.ToInt32(textBoxPolygon.Text));
                case STRING:
                    return 1;
                default:
                    return 2;
            }
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
            pictureBox.CreateGraphics().DrawEllipse(new Pen(Color.Black), e.X - 1, e.Y - 1, 3, 3);
            if (NoOfControlPoints(GetObject()) == 2)
            {
                Points[0] = new Point(e.X, e.Y);
            }
            else
            {
                Points[nPoint] = new Point(e.X, e.Y);
                ++nPoint;
                if (nPoint == NoOfControlPoints(GetObject()))
                    Render();
            }

            MouseDowned = true;
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseDowned && NoOfControlPoints(GetObject()) == 2)
            {
                Points[1] = new Point(e.X, e.Y);
                Render();
                --nLayer;
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
            PointF a, b;
            int typeObject = GetObject();

            switch (typeObject)
            {
                case LINE:
                    AddGraphicsPath(new Line(Points[0], Points[1]));
                    break;
                case CIRCLE:
                    float r = (float)Math.Sqrt(sqr(Points[1].X - Points[0].X) + sqr(Points[1].Y - Points[0].Y));
                    AddGraphicsPath(new Ellipse(new PointF(Points[0].X - r, Points[0].Y - r), 2 * r, 2 * r));
                    break;
                case ELLIPSE:
                    a = new PointF(Math.Min(Points[0].X, Points[1].X), Math.Min(Points[0].Y, Points[1].Y));
                    float wid = Math.Abs(Points[1].X - Points[0].X), hgt = Math.Abs(Points[1].Y - Points[0].Y);
                    AddGraphicsPath(new Ellipse(a, wid, hgt));
                    break;
                case RECTANGLE:
                    a = new PointF(Math.Min(Points[0].X, Points[1].X), Math.Min(Points[0].Y, Points[1].Y));
                    b = new PointF(Math.Max(Points[0].X, Points[1].X), Math.Max(Points[0].Y, Points[1].Y));
                    AddGraphicsPath(new Rectangle(a, b));
                    break;
                case BEZIER:
                    AddGraphicsPath(new Bezier(Points[0], Points[1], Points[2], Points[3]));
                    break;
                case POLYGON:
                    PointF[] tmp = new PointF[nPoint];
                    for (int i = 0; i < nPoint; ++i)
                       tmp[i] = Points[i];
                    AddGraphicsPath(new Polygon(tmp));
                    break;
                case STRING:
                    AddGraphicsPath(new String(new Point((int)Points[0].X, (int)Points[0].Y), textBoxString.Text));
                    break;
                case PARABOLA:
                    if (Math.Abs(Points[1].X - Points[0].X) < 5)
                        Points[1].X = Points[0].X + 5;
                    if (Math.Abs(Points[1].Y - Points[0].Y) < 5)
                        Points[1].Y = Points[0].Y + 5;

                    float A = (Points[1].Y - Points[0].Y) / sqr(Points[1].X - Points[0].X);
                    float B = -2 * A * Points[0].X;
                    float C = A * sqr(Points[0].X) + Points[0].Y;

                    float p1 = A * Points[0].X * Points[0].X + B * Points[0].X + C;
                    float p2 = A * Points[1].X * Points[1].X + B * Points[1].X + C;
                    AddGraphicsPath(new Parabola(A, B, C));
                    break;
            }
            RefreshGraphics();
            nPoint = 0;
        }

        private void AddGraphicsPath(Shape myShape)
        {
            GraphicsPath tmpGraphicsPath = new GraphicsPath();
            myShape.AddTo(tmpGraphicsPath);
            ++nLayer;
            myLayers[nLayer - 1] = new Layer(myShape, tmpGraphicsPath, GetPen(), GetBrush());
        }

        private void RefreshGraphics()
        {
            Bitmap bm = new Bitmap(PB_WIDTH, PB_HEIGHT);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.Clear(Color.White);
                for (int i = 0; i < nLayer; ++i)
                {
                    gr.DrawPath(myLayers[i].myPen, myLayers[i].myGraphicsPath);
                    gr.FillPath(myLayers[i].myBrush, myLayers[i].myGraphicsPath);
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

        private void textBoxPolygon_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPolygon.Text == "")
                return;
            try
            {
                int n = System.Convert.ToInt32(textBoxPolygon.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("N is invalid! Set N = 3.");
                textBoxPolygon.Text = "3";
                return;
            }
        }
    }
}
