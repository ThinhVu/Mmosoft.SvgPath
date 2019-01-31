using System.Drawing;
using System.Drawing.Drawing2D;

namespace SVGPathExplain.CommandProcess
{
    public class VerticalLineTo : _ICommandProcessor
    {
        public void Process(Command c, GraphicsPath g, ref float x, ref float y)
        {
            float yParam = c.Params[0];
            // H
            if (c.CommandText.ToUpper() == c.CommandText)
            {
                g.AddLine(new PointF(x, y), new PointF(x, yParam));
                y = yParam;
            }
            // h
            else
            {
                g.AddLine(new PointF(x, y), new PointF(x, y + yParam));
                y += yParam;
            }
        }
    }
}
