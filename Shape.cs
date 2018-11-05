﻿using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics2D
{
    abstract public class Shape
    {
        abstract public void AddTo(GraphicsPath myGraphicsPath);
    }
}