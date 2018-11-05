using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics2D
{
    class Polygon : Shape
    {
        PointF[] p;

        public Polygon(PointF[] val)
        {
            p = val;
        }

        public override void AddTo(GraphicsPath myGraphicsPath)
        {
            if (p.Length >= 3)
                myGraphicsPath.AddPolygon(p);
        }
    }
}
