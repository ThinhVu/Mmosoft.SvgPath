using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SVGPathExplain.CommandProcess
{
    public class SmoothCurveTo : _ICommandProcessor
    {
        // (x2 y2 x y)+

        // Draws a cubic Bézier curve from the current point to (x,y). 
        // The first control point is assumed to be the reflection of the second 
        // control point on the previous command relative to the current point. 
        // (If there is no previous command or if the previous command was not an 
        // C, c, S or s, assume the first control point is coincident with the current point.) 
        // (x2,y2) is the second control point (i.e., the control point at the end of the curve). 
        // S (uppercase) indicates that absolute coordinates will follow; 
        // s (lowercase) indicates that relative coordinates will follow. 
        // Multiple sets of coordinates may be specified to draw a polybézier.
        // At the end of the command, the new current point becomes the final (x,y) 
        // coordinate pair used in the polybézier.
        public void Process(Command c, GraphicsPath g, ref float x, ref float y)
        {
            bool isAbs = c.CommandText.ToUpper() == c.CommandText;

            PointF controlPoint1 = GetControlPoint1(c, currentPoint: new PointF(x, y));

            for (int i = 0; i < c.Params.Count; i += 4)
            {
                var controlPoint2 = new PointF((isAbs ? 0 : x) + c.Params[i], (isAbs ? 0 : y) + c.Params[i + 1]);
                var endPoint = new PointF((isAbs ? 0 : x) + c.Params[i + 2], (isAbs ? 0 : y) + c.Params[i + 3]);

                g.AddBezier(new PointF(x, y), controlPoint1, controlPoint2, endPoint);

                x = endPoint.X;
                y = endPoint.Y;
            }
        }

        private PointF GetControlPoint1(Command c, PointF currentPoint)
        {
            PointF currentControlPoint1 = new PointF(0, 0);

            // if current is S or s and there is no C, c, S, s
            // assume the first control point is coincident with the current point
            if (c.CommandText == "S" || c.CommandText == "s")
            {
                if (c.PrevCmd == null)
                {
                    currentControlPoint1 = currentPoint;
                }
                else if (c.PrevCmd.CommandText != "C"
                    && c.PrevCmd.CommandText != "c"
                    && c.PrevCmd.CommandText != "S"
                    && c.PrevCmd.CommandText != "s")
                {
                    currentControlPoint1 = currentPoint;
                }
                else
                {
                    PointF prevSecondControlAbsPosition = new PointF(0, 0);
                    // otherwise, trying to get the last second control point of previous
                    string prevCmdText = c.PrevCmd.CommandText;
                    if (prevCmdText == "C")
                    {
                        // ((x1 y1) (x2 y2) (x y))+
                        for (int i = 0; i < c.PrevCmd.Params.Count; i += 6)
                            prevSecondControlAbsPosition = new PointF(c.PrevCmd.Params[i + 2], c.PrevCmd.Params[i + 3]);
                    }
                    else if (prevCmdText == "c")
                    {                        
                        PointF offsetOfSecondPoint = new Point(0, 0);
                        PointF offsetToCurrentPoint = new Point(0, 0);

                        // ((x1 y1) (x2 y2) (x y))+
                        for (int i = 0; i < c.PrevCmd.Params.Count; i += 6)
                        {
                            // controlPoint1 = new PointF(c.PrevCmd.Params[i + 2], c.PrevCmd.Params[i + 3]);
                            offsetOfSecondPoint = new PointF(c.PrevCmd.Params[i + 2], c.PrevCmd.Params[i + 3]);
                            offsetToCurrentPoint = new PointF(c.PrevCmd.Params[i + 4], c.PrevCmd.Params[i + 5]);
                        }

                        prevSecondControlAbsPosition = new PointF(
                            currentPoint.X - offsetToCurrentPoint.X + offsetOfSecondPoint.X,
                            currentPoint.Y - offsetToCurrentPoint.Y + offsetOfSecondPoint.Y);
                    }
                    else if (prevCmdText == "S")
                    {
                        // ((x2 y2) (x y))+
                        for (int i = 0; i < c.PrevCmd.Params.Capacity; i += 4)
                            prevSecondControlAbsPosition = new PointF(c.PrevCmd.Params[i], c.PrevCmd.Params[i + 1]);
                    }
                    else if (prevCmdText == "s")
                    {
                        PointF offsetOfSecondPoint = new Point(0, 0);
                        PointF offsetToCurrentPoint = new Point(0, 0);
                        for (int i = 0; i < c.PrevCmd.Params.Capacity; i += 4)
                        {
                            offsetOfSecondPoint = new PointF(c.PrevCmd.Params[i], c.PrevCmd.Params[i + 1]);
                            offsetToCurrentPoint = new PointF(c.PrevCmd.Params[i + 2], c.PrevCmd.Params[i + 3]);
                        }

                        prevSecondControlAbsPosition = new PointF(
                            currentPoint.X - offsetToCurrentPoint.X + offsetOfSecondPoint.X,
                            currentPoint.Y - offsetToCurrentPoint.Y + offsetOfSecondPoint.Y);
                    }

                    // calculate current control point 1
                    float distanceX = currentPoint.X - prevSecondControlAbsPosition.X;
                    float distanceY = currentPoint.Y - prevSecondControlAbsPosition.Y;
                    
                    currentControlPoint1.X = currentPoint.X + distanceX;
                    currentControlPoint1.Y = currentPoint.Y + distanceY;
                }
            }

            
            return currentControlPoint1;
        }
    }
}
