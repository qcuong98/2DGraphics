using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics2D
{
    public class Ellipse : Shape
    {
        public PointF a;
        public float width;
        public float height;

        public Ellipse() : base() { }

        public Ellipse(PointF p1, float p2, float p3)
        {
            a = p1;
            width = p2;
            height = p3;
            float x = a.X + width / 2;
            float y = a.Y + height / 2;
            origin = new PointF(x, y);
        }

        public override void AddTo(GraphicsPath myGraphicsPath)
        {
            RectangleF Rect = new RectangleF(a.X, a.Y, width, height);
            myGraphicsPath.AddEllipse(Rect);
        }
    }
}
