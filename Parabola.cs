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

        public Parabola(float p1, float p2, float p3)
        {
            a = p1;
            b = p2;
            c = p3;
        }

        private float F(float x) {
            return a * x * x + b * x + c;
        }

        public override void AddTo(GraphicsPath myGraphicsPath)
        {
            int x;

            x = 0;
            while (F(x - 1) >= 0 && F(x - 1) < MainForm.PB_HEIGHT)
                --x;
            PointF p1 = new PointF(x, F(x));

            x = MainForm.PB_WIDTH - 1;
            while (F(x + 1) >= 0 && F(x + 1) < MainForm.PB_HEIGHT)
                ++x;
            PointF p2 = new PointF(x, F(x));

            PointF pc = new PointF((p1.X + p2.X) / 2, p1.Y + (2 * a * p1.X + b) * (p2.X - p1.X) / 2);
            PointF c1 = new PointF(2F / 3 * pc.X + 1F / 3 * p1.X, 2F / 3 * pc.Y + 1F / 3 * p1.Y);
            PointF c2 = new PointF(2F / 3 * pc.X + 1F / 3 * p2.X, 2F / 3 * pc.Y + 1F / 3 * p2.Y);

            myGraphicsPath.AddBezier(p1, c1, c2, p2);
        }
    }
}
