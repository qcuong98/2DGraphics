using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics2D
{
    class Layer
    {
        public Shape myShape;
        public GraphicsPath myGraphicsPath;
        public Pen myPen;
        public Brush myBrush;
        public Matrix myMatrix;

        public Layer(Shape p1, GraphicsPath p2, Pen p3, Brush p4)
        {
            myShape = p1;
            myGraphicsPath = p2;
            myPen = p3;
            myBrush = p4;
            myMatrix = new Matrix();
        }
    }
}