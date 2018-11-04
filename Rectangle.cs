using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics2D
{
    class Rectangle : Shape
    {
        PointF a;
        PointF b;

        public Rectangle(PointF p1, PointF p2)
        {
            a = p1;
            b = p2;
        }

        public override void AddTo(GraphicsPath myGraphicsPath)
        {
            RectangleF myRectangle = new RectangleF(a.X, a.Y, b.X - a.X, b.Y - a.Y);
            myGraphicsPath.AddRectangle(myRectangle);
        }
    }
}
