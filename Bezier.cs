using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics2D
{
    class Bezier : Shape
    {
        PointF a, b, c, d;

        public Bezier(PointF p1, PointF p2, PointF p3, PointF p4)
        {
            a = p1;
            b = p2;
            c = p3;
            d = p4;
            float x = (p1.X + p2.X + p3.X + p4.X) / 4;
            float y = (p1.Y + p2.Y + p3.Y + p4.Y) / 4;
            origin = new PointF(x, y);
        }

        public override void AddTo(GraphicsPath myGraphicsPath)
        {
            myGraphicsPath.AddBezier(a, b, c, d);
        }
    }
}
