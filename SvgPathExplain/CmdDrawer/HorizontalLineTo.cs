﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SVGPathExplain.CommandProcess
{
    public class HorizontalLineTo : ICmdDrawer
    {
        public void Process(Cmd c, GraphicsPath g, ref float x, ref float y)
        {
            float xParam = c.Params[0];
            // H
            if (c.CmdText.ToUpper() == c.CmdText)
            {
                g.AddLine(new PointF(x, y), new PointF(xParam, y));
                x = xParam;
            }
            // h
            else
            {
                g.AddLine(new PointF(x, y), new PointF(x + xParam, y));
                x += xParam;
            }
        }
    }
}