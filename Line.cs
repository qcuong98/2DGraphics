using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics2D
{
    class Line : Shape
    {
        private PointF a;
        private PointF b;

        public Line(PointF p1, PointF p2)
        {
            a = p1;
            b = p2;
        }

        override public void AddTo(GraphicsPath myGraphicsPath)
        {
            myGraphicsPath.AddLine(a, b);
        }
    }
}
