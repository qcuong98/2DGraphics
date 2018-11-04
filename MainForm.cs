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
        private const int ELLIPSE = 2;
        private const int CIRCLE = 3;
        private const int RECTANGLE = 4;

        private GraphicsPath[] myGraphicsPaths;
        private Pen[] myPens;
        private Brush[] myBrushes;
        int nGraphicsPath;

        int x0, y0, x1, y1;
        bool MouseDowned;

        public MainForm()
        {
            InitializeComponent();
            
            nGraphicsPath = 0;
            myGraphicsPaths = new GraphicsPath[MAX_LAYER];
            myPens = new Pen[MAX_LAYER];
            myBrushes = new Brush[MAX_LAYER];

            /* init background of PictureBoxes*/
            pictureBoxBrushColor.BackColor = Color.White;
            pictureBoxPenColor.BackColor = Color.Red;
            pictureBox.BackColor = Color.White;
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
            return SELECT;
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
                Render();
                if (GetObject() != SELECT)
                    --nGraphicsPath;
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            x1 = e.X;
            y1 = e.Y;
            Render();
            MouseDowned = false;
        }

        private void Render()
        {
            if (GetObject() == LINE)
                AddGraphicsPath(new Line(new PointF(x0, y0), new PointF(x1, y1)));
            else if (GetObject() == CIRCLE) {
                float r = (float)Math.Sqrt((x1 - x0) * (x1 - x0) + (y1 - y0) * (y1 - y0));
                AddGraphicsPath(new Ellipse(new PointF(x0 - r, y0 - r), 2 * r, 2 * r));
            }
            else if (GetObject() == ELLIPSE)
            {
                PointF a = new PointF(Math.Min(x0, x1), Math.Min(y0, y1));
                int wid = Math.Abs(x1 - x0), hgt = Math.Abs(y1 - y0);
                AddGraphicsPath(new Ellipse(a, wid, hgt));
            }
            else if (GetObject() == RECTANGLE)
            {
                PointF a = new PointF(Math.Min(x0, x1), Math.Min(y0, y1));
                PointF b = new PointF(Math.Max(x0, x1), Math.Max(y0, y1));
                AddGraphicsPath(new Rectangle(a, b));
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
