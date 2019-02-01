using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SVGPathExplain.CommandProcess
{
    public class HorizontalLineTo : ICmdDrawer
    {
        public void Process(Cmd command, GraphicsPath g)
        {
            g.AddLine(new PointF(command.X, command.Y), new PointF(command.Params[0], command.Y));
        }
    }
}
