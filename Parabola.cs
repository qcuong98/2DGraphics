using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics2D
{
    class Parabola : Shape
    {
        float a, b, c;
        PointF bound_1;

        public Parabola(float p1, float p2, float p3, PointF p4, PointF p5)
        {
            a = p1;
            b = p2;
            c = p3;
            origin = p4;
            bound_1 = p5;
        }

        private float F(float x) {
            return a * x * x + b * x + c;
        }

        public override void AddTo(GraphicsPath myGraphicsPath)
        {
            PointF bound_2 = new PointF(2 * origin.X - bound_1.X, bound_1.Y);

            PointF pc = new PointF((bound_1.X + bound_2.X) / 2, bound_1.Y + (2 * a * bound_1.X + b) * (bound_2.X - bound_1.X) / 2);
            PointF c1 = new PointF(2F / 3 * pc.X + 1F / 3 * bound_1.X, 2F / 3 * pc.Y + 1F / 3 * bound_1.Y);
            PointF c2 = new PointF(2F / 3 * pc.X + 1F / 3 * bound_2.X, 2F / 3 * pc.Y + 1F / 3 * bound_2.Y);

            myGraphicsPath.AddBezier(bound_1, c1, c2, bound_2);
        }
    }
}
