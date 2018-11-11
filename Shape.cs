using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Graphics2D
{
    [XmlInclude(typeof(Line))]
    [XmlInclude(typeof(Ellipse))]
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(Bezier))]
    [XmlInclude(typeof(Polygon))]
    [XmlInclude(typeof(String))]
    [XmlInclude(typeof(Parabola))]
    [Serializable]
    abstract public class Shape
    {
        public PointF origin;

        public Shape() { }
        abstract public void AddTo(GraphicsPath myGraphicsPath);
    }
}
