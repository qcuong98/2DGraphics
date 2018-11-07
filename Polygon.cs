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
            float x = 0, y = 0;
            for (int i = 0; i < val.Length; ++i)
            {
                x += val[i].X;
                y += val[i].Y;
            }
            x /= val.Length;
            y /= val.Length;
            origin = new PointF(x, y);
        }

        public override void AddTo(GraphicsPath myGraphicsPath)
        {
            if (p.Length >= 3)
                myGraphicsPath.AddPolygon(p);
        }
    }
}
