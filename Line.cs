using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics2D
{
    public class Line : Shape
    {
        private PointF a;
        private PointF b;

        public Line() : base() { }

        public Line(PointF p1, PointF p2)
        {
            a = p1;
            b = p2;
            float x = (a.X + b.X) / 2;
            float y = (a.Y + b.Y) / 2;
            origin = new PointF(x, y);
        }

        override public void AddTo(GraphicsPath myGraphicsPath)
        {
            myGraphicsPath.AddLine(a, b);
        }
    }
}
