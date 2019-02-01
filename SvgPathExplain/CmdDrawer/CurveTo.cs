using System.Drawing;
using System.Drawing.Drawing2D;

namespace SVGPathExplain.CommandProcess
{
    public class CurveTo : ICmdDrawer
    {
        // 	(x1 y1 x2 y2 x y)+
        // Draws a cubic Bézier curve from the current point to (x,y) using (x1,y1) as the control point at the beginning
        // of the curve and (x2,y2) as the control point at the end of the curve. C (uppercase) indicates that absolute 
        // coordinates will follow; c (lowercase) indicates that relative coordinates will follow. Multiple sets of 
        // coordinates may be specified to draw a polybézier. At the end of the command, the new current point becomes
        // the final (x,y) coordinate pair used in the polybézier.
        public void Process(Cmd c, GraphicsPath g)
        {
            bool isAbs = c.CmdText.ToUpper() == c.CmdText;
            for (int i = 0; i < c.Params.Count; i+=6)
            {
                var controlPoint1 = new PointF(c.Params[i], c.Params[i + 1]);
                var controlPoint2 = new PointF(c.Params[i + 2], c.Params[i + 3]);
                var endPoint = new PointF(c.Params[i + 4], c.Params[i + 5]);

                g.AddBezier(new PointF(x, y), controlPoint1, controlPoint2, endPoint);

                x = endPoint.X;
                y = endPoint.Y;
            }
        }
    }
}
