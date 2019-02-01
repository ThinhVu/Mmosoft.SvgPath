using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SVGPathExplain.CommandProcess
{
    public class LineTo : ICmdDrawer
    {
        public void Process(Cmd c, GraphicsPath g, ref float x, ref float y)
        {
            if (c.Params.Count % 2 != 0)
                throw new Exception("Argument missing!");

            bool isAbsolute = c.CmdText.ToUpper() == c.CmdText;

            for (int i = 0; i < c.Params.Count; i += 2)
            {
                float xParam = c.Params[i];
                float yParam = c.Params[i + 1];
                g.AddLine(new PointF(x, y), new PointF(x + xParam, y + yParam));

                if (isAbsolute)
                {
                    x = xParam;
                    y = yParam;
                }
                else
                {
                    x += xParam;
                    y += yParam;
                }
            }
        }
    }
}
