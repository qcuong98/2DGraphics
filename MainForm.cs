using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Graphics2D
{
    public partial class MainForm : Form
    {
        public const int MAX_LAYER = 1000;

        private const int LINE = 1;
        private const int CIRCLE = 2;
        private const int ELLIPSE = 3;
        private const int RECTANGLE = 4;
        private const int BEZIER = 5;
        private const int POLYGON = 6;
        private const int STRING = 7;
        private const int PARABOLA = 8;
        private const int SELECT = 9;
        private const int MOVE = 10;
        private const int SCALE = 11;
        private const int ROTATE = 12;

        public static int PB_WIDTH;
        public static int PB_HEIGHT;
        private const int SCALING_LEN = 100;

        int nLayer;
        private Layer[] myLayers;
        int curLayer;
        private GraphicsPath[] myGraphicsPath;

        int nPoint;
        private PointF[] Points;

        bool MouseDowned;

        public MainForm()
        {
            InitializeComponent();

            nLayer = 0;
            myLayers = new Layer[MAX_LAYER];
            curLayer = -1;
            myGraphicsPath = new GraphicsPath[MAX_LAYER];

            nPoint = 0;
            Points = new PointF[100];

            /* init background of PictureBoxes*/
            pictureBoxBrushColor.BackColor = Color.Orange;
            pictureBoxPenColor.BackColor = Color.Black;
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

            if (radioButtonSelect.Checked)
                return SELECT;
            if (radioButtonMove.Checked)
                return MOVE;
            if (radioButtonScale.Checked)
                return SCALE;
            if (radioButtonRotate.Checked)
                return ROTATE;
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
                case SELECT:
                    return 1;
                default:
                    return 2;
            }
        }

        private void GetPen(ref Color c, ref float width, ref float[] dashPattern)
        {
            c = pictureBoxPenColor.BackColor;

            if (radioButtonSolid.Checked)
            {
                float wid = CheckValidFloat(textBoxWidth.Text);
                width = (wid == -1 ? 1 : wid);
            }
            else if (radioButtonDot.Checked)
                dashPattern = new float[] { 1F, 5F };
            else if (radioButtonDash.Checked)
                dashPattern = new float[] { 10F, 5F };
            else if (radioButtonDashDot.Checked)
                dashPattern = new float[] { 10F, 5F, 1F, 5F };
            else if (radioButtonDashDotDot.Checked)
                dashPattern = new float[] { 10F, 5F, 1F, 5F, 1F, 5F };
            else if (radioButtonNull.Checked)
                c = Color.Transparent;
        }

        private int GetBrush(ref Color c, ref int idPattern)
        {
            if (radioButtonBrushTransparent.Checked)
            {
                c = Color.Transparent;
                return 0;
            }
            if (radioButtonBrushColor.Checked)
            {
                c = pictureBoxBrushColor.BackColor;
                return 0;
            }

            if (radioButtonBrushPattern1.Checked)
                idPattern = 1;
            else if (radioButtonBrushPattern2.Checked)
                idPattern = 2;
            else if (radioButtonBrushPattern3.Checked)
                idPattern = 3;
            return 1;
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox.CreateGraphics().DrawEllipse(new Pen(Color.Black), e.X - 1, e.Y - 1, 3, 3);
            if (NoOfControlPoints(GetObject()) == 2)
            {
                nPoint = 1;
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
            int obj = GetObject();
            if (MouseDowned && NoOfControlPoints(obj) == 2 && nPoint == 1)
            {
                textBoxString.Text = nPoint.ToString();
                float tmpdx = 0, tmpdy = 0, tmpAngle = 0, tmppx = 0, tmppy = 0;
                if (obj == MOVE)
                {
                    tmpdx = myLayers[curLayer].dx;
                    tmpdy = myLayers[curLayer].dy;
                }
                else if (obj == ROTATE)
                    tmpAngle = myLayers[curLayer].angle;
                else if (obj == SCALE)
                {
                    tmppx = myLayers[curLayer].px;
                    tmppy = myLayers[curLayer].py;
                }

                Points[1] = new Point(e.X, e.Y);
                Render();

                if (obj == MOVE) {
                    myLayers[curLayer].dx = tmpdx;
                    myLayers[curLayer].dy = tmpdy;
                }
                else if (obj == ROTATE)
                    myLayers[curLayer].angle = tmpAngle;
                else if (obj == SCALE)
                {
                    myLayers[curLayer].px = tmppx;
                    myLayers[curLayer].py = tmppy;
                } 
                else
                    --nLayer;
                nPoint = 1;
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (NoOfControlPoints(GetObject()) == 2 && nPoint == 1)
            {
                nPoint = 2;
                Points[1] = new Point(e.X, e.Y);
                Render();
            }
            MouseDowned = false;
        }

        private static float sqr(float x){
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
                    AddGraphicsPath(new Parabola(A, B, C, Points[0], Points[1]));
                    break;
                case SELECT:
                    for (int i = nLayer - 1; i >= 0; --i) 
                    {
                        bool ok = false;
                        for (int x = -5; x <= 5; ++x)
                            for (int y = -5; y <= 5; ++y)
                            {
                                PointF tmpPoint = new PointF(Points[0].X + x, Points[0].Y + y);
                                if (myGraphicsPath[i].IsVisible(tmpPoint) ||
                                    myGraphicsPath[i].IsOutlineVisible(tmpPoint, myLayers[i].GetPen()))
                                {
                                    ok = true;
                                    break;
                                }
                            }
                        if (ok)
                        {
                            curLayer = i;
                            break;
                        }
                    }
                    break;
                case MOVE:
                    if (curLayer != -1)
                    {
                        myLayers[curLayer].dx += Points[1].X - Points[0].X;
                        myLayers[curLayer].dy += Points[1].Y - Points[0].Y;
                    }
                    break;
                case SCALE:
                    if (curLayer != -1)
                    {
                        myLayers[curLayer].px = (Points[1].X - Points[0].X) / SCALING_LEN;
                        myLayers[curLayer].py = (Points[1].Y - Points[0].Y) / SCALING_LEN;
                    }
                    break; 
                case ROTATE:
                    if (curLayer != -1)
                    {
                        float va_x = Points[0].X - myLayers[curLayer].myShape.origin.X;
                        float va_y = Points[0].Y - myLayers[curLayer].myShape.origin.Y;
                        float vb_x = Points[1].X - myLayers[curLayer].myShape.origin.X;
                        float vb_y = Points[1].Y - myLayers[curLayer].myShape.origin.Y;

                        float new_angle = (float)Math.Acos((va_x * vb_x + va_y * vb_y) /
                            (float)Math.Sqrt((sqr(va_x) + sqr(va_y)) * (sqr(vb_x) + sqr(vb_y))));
                        myLayers[curLayer].angle += 180F / (float)Math.Acos(-1) * new_angle;
                        if (myLayers[curLayer].angle >= 360F)
                            myLayers[curLayer].angle -= 360F;
                        if (myLayers[curLayer].angle < 0F)
                            myLayers[curLayer].angle += 360F;
                    }
                    break;
            }
            RefreshGraphics();
            nPoint = 0;
        }

        private void AddGraphicsPath(Shape myShape)
        {
            ++nLayer;
            curLayer = nLayer - 1;
            Color c = new Color();
            float wid = 0;
            float[] dashPatern = new float[0];
            GetPen(ref c, ref wid, ref dashPatern);
            int idBrush;
            Color cBrush = new Color();
            int idPattern = 0;
            idBrush = GetBrush(ref cBrush, ref idPattern);
            myLayers[nLayer - 1] = new Layer(myShape, c, wid, dashPatern, idBrush, cBrush, idPattern);
        }

        Bitmap drawToBMP(Boolean getBound)
        {
            Bitmap bm = new Bitmap(PB_WIDTH, PB_HEIGHT);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.Clear(Color.White);
                for (int i = 0; i < nLayer; ++i)
                {
                    Matrix transformMatrix = new Matrix();
                    /* translate */
                    transformMatrix.Translate(myLayers[i].dx, myLayers[i].dy, MatrixOrder.Append);
                    /* rotate */
                    PointF newOrigin = new PointF(myLayers[i].myShape.origin.X + myLayers[i].dx,
                                                  myLayers[i].myShape.origin.Y + myLayers[i].dy);
                    transformMatrix.RotateAt(myLayers[i].angle, newOrigin, MatrixOrder.Append);
                    /* scale */
                    transformMatrix.Translate(-newOrigin.X, -newOrigin.Y, MatrixOrder.Append);
                    transformMatrix.Scale(myLayers[i].px, myLayers[i].py, MatrixOrder.Append);
                    transformMatrix.Translate(newOrigin.X, newOrigin.Y, MatrixOrder.Append);

                    myGraphicsPath[i] = new GraphicsPath();
                    myLayers[i].myShape.AddTo(myGraphicsPath[i]);
                    myGraphicsPath[i].Transform(transformMatrix);

                    gr.DrawPath(myLayers[i].GetPen(), myGraphicsPath[i]);
                    gr.FillPath(myLayers[i].GetBrush(), myGraphicsPath[i]);
                    if (i == curLayer && getBound)
                    {
                        Pen myPen = new Pen(Color.Black);
                        myPen.DashPattern = new float[] { 1F, 5F };
                        RectangleF myRectF = myGraphicsPath[i].GetBounds();
                        gr.DrawRectangle(myPen, myRectF.X, myRectF.Y, myRectF.Width, myRectF.Height);
                    }
                }
            }
            return bm;
        }

        private void RefreshGraphics()
        {

            pictureBox.Image = drawToBMP(true);
            pictureBox.Refresh();
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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (nLayer > 0 && curLayer != -1)
            {
                for (int i = curLayer + 1; i < nLayer; ++i)
                    myLayers[i - 1] = myLayers[i];
                --nLayer;
                curLayer = nLayer - 1;
                RefreshGraphics();
            }
        }

        private void buttonSendBack_Click(object sender, EventArgs e)
        {
            if (nLayer > 0 && curLayer != -1)
            {
                Layer tmpLayer = myLayers[curLayer];
                for (int i = curLayer - 1; i >= 0; --i)
                    myLayers[i + 1] = myLayers[i];
                myLayers[0] = tmpLayer;
                curLayer = 0;
                RefreshGraphics();
            }
        }

        private void buttonBringFront_Click(object sender, EventArgs e)
        {
            if (nLayer > 0 && curLayer != -1)
            {
                Layer tmpLayer = myLayers[curLayer];
                for (int i = curLayer + 1; i < nLayer; ++i)
                    myLayers[i - 1] = myLayers[i];
                myLayers[nLayer - 1] = tmpLayer;
                curLayer = nLayer - 1;
                RefreshGraphics();
            }
        }

        private void buttonSendBackward_Click(object sender, EventArgs e)
        {
            if (nLayer > 0 && curLayer != -1 && curLayer > 0)
            {
                Layer tmp = myLayers[curLayer];
                myLayers[curLayer] = myLayers[curLayer - 1];
                myLayers[curLayer - 1] = tmp;
                --curLayer;
                RefreshGraphics();
            }
        }

        private void buttonBrindForward_Click(object sender, EventArgs e)
        {
            if (nLayer > 0 && curLayer != -1 && curLayer < nLayer - 1)
            {
                Layer tmp = myLayers[curLayer];
                myLayers[curLayer] = myLayers[curLayer + 1];
                myLayers[curLayer + 1] = tmp;
                ++curLayer;
                RefreshGraphics();
            }
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
                using (var writer = new System.IO.StreamWriter(fOutput))
                {
                    SerializationObject serializationObject = new SerializationObject(nLayer, myLayers, curLayer);

                    var serializer = new XmlSerializer(serializationObject.GetType());
                    serializer.Serialize(writer, serializationObject);
                    writer.Flush();
                }
            }
        }

        private void buttonLoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog myOpenFileDialog = new OpenFileDialog();
            myOpenFileDialog.Title = "Load File of Objects";
            myOpenFileDialog.CheckFileExists = true;
            myOpenFileDialog.CheckPathExists = true;
            myOpenFileDialog.DefaultExt = "shp";
            myOpenFileDialog.Filter = "Shape files (*.shp)|*.shp";
            myOpenFileDialog.FilterIndex = 1;
            myOpenFileDialog.RestoreDirectory = true;
            if (myOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fInput = myOpenFileDialog.FileName;
                using (var reader = new System.IO.StreamReader(fInput))
                {
                    SerializationObject serializationObject = new SerializationObject(nLayer, myLayers, curLayer);

                    var serializer = new XmlSerializer(serializationObject.GetType());
                    serializationObject = (SerializationObject)serializer.Deserialize(reader);
                    reader.Close();

                    nLayer = serializationObject.nLayer;
                    for (int i = 0; i < nLayer; ++i)
                        myLayers[i] = serializationObject.myLayers[i];
                    curLayer = serializationObject.curLayer;
                    RefreshGraphics();
                    nPoint = 0;
                }
            }
        }

        private void buttonExportImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog mySaveFileDialog = new SaveFileDialog();
            mySaveFileDialog.Title = "Export to image";
            mySaveFileDialog.CheckPathExists = true;
            mySaveFileDialog.DefaultExt = "bmp";
            mySaveFileDialog.Filter = "Bitmap image file (*.bmp)|*.bmp|Joint Photographic Experts Group (*.jpeg)|*.jpeg|"+
                                    "Portable Network Graphic (*.png)|*.png|Tagged Image File Format (*.tif)|*.tif|"+
                                    "Graphics Interchange Format (*.gif)|*.gif";
            mySaveFileDialog.FilterIndex = 1;
            mySaveFileDialog.RestoreDirectory = true;
            if (mySaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fOutput = mySaveFileDialog.FileName;
                Bitmap image = drawToBMP(false);

                switch (mySaveFileDialog.FilterIndex)
                {
                    case 1:
                        image.Save(fOutput, ImageFormat.Bmp);
                        break;
                    case 2:
                        image.Save(fOutput, ImageFormat.Jpeg);
                        break;
                    case 3:
                        image.Save(fOutput, ImageFormat.Png);
                        break;
                    case 4:
                        image.Save(fOutput, ImageFormat.Tiff);
                        break;
                    case 5:
                        image.Save(fOutput, ImageFormat.Gif);
                        break;
                }
            }
        }
    }
}
