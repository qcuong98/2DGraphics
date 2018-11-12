using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics2D
{
    public class Hyperbola : Shape
    {
        public float A;
        public float B;
        public PointF bound_1;

        public Hyperbola() : base() {}

        public Hyperbola(float a2, float b2, PointF origin, PointF bound_1)
        {
            A = a2;
            B = b2;
            this.origin = origin;
            this.bound_1 = bound_1;
        }

        private float absX(float y)
        {
            return (float)Math.Sqrt(A * (y * y + B) / B);
        }

        public override void AddTo(GraphicsPath myGraphicsPath)
        {
            int len = 0;
            PointF[] points1 = new PointF[5000];
            PointF[] points2 = new PointF[5000];

            float dy = Math.Abs(bound_1.Y - origin.Y);
            for (float y = -dy; y <= dy; ++y)
            {
                ++len;
                points1[len - 1] = new PointF(origin.X + absX(y), origin.Y + y);
                points2[len - 1] = new PointF(origin.X - absX(y), origin.Y + y);
            }

            PointF[] line = new PointF[len];

            Array.Copy(points1, line, len);
            myGraphicsPath.StartFigure();
            myGraphicsPath.AddLines(line);

            Array.Copy(points2, line, len);
            myGraphicsPath.StartFigure();
            myGraphicsPath.AddLines(line);
        }
    }
}
