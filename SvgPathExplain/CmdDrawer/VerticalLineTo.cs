using System.Drawing;
using System.Drawing.Drawing2D;

namespace SVGPathExplain.CommandProcess
{
    public class VerticalLineTo : ICmdDrawer
    {
        public void Process(Cmd c, GraphicsPath g)
        {
            g.AddLine(new PointF(c.X, c.Y), new PointF(c.X, c.Params[0]));
        }
    }
}
