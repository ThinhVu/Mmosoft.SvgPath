using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SVGPathExplain.CommandProcess
{
    public class QuadraticBezierCurve : ICmdDrawer
    {
        // (x1 y1 x y)+
        // Draws a quadratic Bézier curve from the current point to (x,y) using (x1,y1) as the control point. 
        // Q (uppercase) indicates that absolute coordinates will follow; q (lowercase) indicates that relative 
        // coordinates will follow. Multiple sets of coordinates may be specified to draw a polybézier. 
        // At the end of the command, the new current point becomes the final (x,y) coordinate pair used in the polybézier.
        public void Process(Cmd c, GraphicsPath g, ref float x, ref float y)
        {
            if (c.Params.Count % 4 != 0)
                throw new ArgumentException("Missing parameters");            

            bool isAbs = c.CmdText.ToUpper() == c.CmdText;
            for (int i = 0; i < c.Params.Count; i += 4)
            {
                var controlPoint1 = new PointF((isAbs ? 0 : x) + c.Params[i], (isAbs ? 0 : y) + c.Params[i + 1]);
                var endPoint = new PointF((isAbs ? 0 : x) + c.Params[i + 2], (isAbs ? 0 : y) + c.Params[i + 3]);

                g.AddBezier(new PointF(x, y), controlPoint1, controlPoint1, endPoint);

                x = endPoint.X;
                y = endPoint.Y;
            }
        }
    }
}