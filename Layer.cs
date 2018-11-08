using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics2D
{
    public class Layer
    {
        public Shape myShape;
        public GraphicsPath myGraphicsPath;

        public Color PenColor;
        public float PenWidth;
        public float[] PenDashPattern;

        public int typeBrush;
        public Color colorBrush;
        public int idPattern;

        public float dx;
        public float dy;
        public float angle;
        public float px;
        public float py;

        private Layer()
        {
            myShape = null;
            myGraphicsPath = null;
            // myPen = null;
            // myBrush = null;
            angle = 0;
            dx = 0; dy = 0;
            px = 1; py = 1;

        }

        public Pen GetPen()
        {
            Pen myPen = new Pen(PenColor);
            myPen.Width = PenWidth;
            if (PenDashPattern.Length > 0)
                myPen.DashPattern = PenDashPattern;
            return myPen;
        }

        public Brush GetBrush()
        {
            if (typeBrush == 0)
            {
                Brush myBrush = new SolidBrush(colorBrush);
                return myBrush;
            }

            string dir = "";
            if (idPattern == 1)
                dir = @"C:\Users\qcuong98\Documents\Visual Studio 2013\Projects\ComputerGraphics\Graphics2D\pattern_1.bmp";
            else if (idPattern == 2)
                dir = @"C:\Users\qcuong98\Documents\Visual Studio 2013\Projects\ComputerGraphics\Graphics2D\pattern_2.bmp";
            else if (idPattern == 3)
                dir = @"C:\Users\qcuong98\Documents\Visual Studio 2013\Projects\ComputerGraphics\Graphics2D\pattern_3.bmp";
            Bitmap myImage = (Bitmap)Image.FromFile(dir);
            TextureBrush myTextureBrush = new TextureBrush(myImage);
            return myTextureBrush;
        }

        public Layer(Shape p1, GraphicsPath p2, Color c, float wid, float[] dashPattern, int tb, Color c1, int idPat)
        {
            myShape = p1;
            myGraphicsPath = p2;

            PenColor = c;
            PenWidth = wid;
            PenDashPattern = dashPattern;

            typeBrush = tb;
            colorBrush = c1;
            idPattern = idPat;

            angle = 0;
            dx = 0; dy = 0;
            px = 1; py = 1;
        }
    }
}