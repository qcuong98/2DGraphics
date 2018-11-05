using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics2D
{
    class String : Shape
    {
        string myText;
        Point origin;

        public String(Point p, string s)
        {
            myText = s;
            origin = p;
        }

        public override void AddTo(GraphicsPath myGraphicsPath)
        {
            FontFamily family = new FontFamily("Arial");
            int fontStyle = (int)FontStyle.Italic;
            int emSize = 26;
            StringFormat format = StringFormat.GenericDefault;

            myGraphicsPath.AddString(myText, family, fontStyle, emSize, origin, format);
        }
    }
}
