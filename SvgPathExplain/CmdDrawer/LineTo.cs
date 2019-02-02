using System.Drawing;
using System.Drawing.Drawing2D;

namespace SVGPath.CommandProcess
{
    public class LineTo : ICmdDrawer
    {
        public void Process(Cmd c, GraphicsPath g)
        {
            g.AddLine(new PointF(c.X, c.Y), new PointF(c.Params[0], c.Params[1]));
        }
    }
}
