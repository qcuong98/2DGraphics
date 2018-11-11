using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics2D
{
    public class Rectangle : Shape
    {
        public PointF a;
        public PointF b;

        public Rectangle() : base() { }

        public Rectangle(PointF p1, PointF p2)
        {
            a = p1;
            b = p2;
            float x = (a.X + b.X) / 2;
            float y = (a.Y + b.Y) / 2;
            origin = new PointF(x, y);
        }

        public override void AddTo(GraphicsPath myGraphicsPath)
        {
            RectangleF myRectangle = new RectangleF(a.X, a.Y, b.X - a.X, b.Y - a.Y);
            myGraphicsPath.AddRectangle(myRectangle);
        }
    }
}
