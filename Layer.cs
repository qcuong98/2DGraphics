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
        public float dx;
        public float dy;
        public float angle;

        public Layer(Shape p1, GraphicsPath p2, Pen p3, Brush p4)
        {
            myShape = p1;
            myGraphicsPath = p2;
            myPen = p3;
            myBrush = p4;
            angle = 0;
            dx = 0;
            dy = 0;
        }
    }
}