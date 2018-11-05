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
        }

        public override void AddTo(GraphicsPath myGraphicsPath)
        {
            myGraphicsPath.AddBezier(a, b, c, d);
        }
    }
}
