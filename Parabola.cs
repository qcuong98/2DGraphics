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
            PointF[] p = new PointF[MainForm.PB_WIDTH];
            int nPoint = 0;
            for (int x = 0; x < MainForm.PB_WIDTH; ++x)
            {
                float y = F(x);
                if (y >= 0 && y < MainForm.PB_HEIGHT)
                {
                    ++nPoint;
                    p[nPoint - 1] = new PointF(x, y);
                }
            }

            PointF[] pixels = new PointF[nPoint];
            Array.Copy(p, pixels, nPoint);
            myGraphicsPath.AddLines(pixels);
        }
    }
}
