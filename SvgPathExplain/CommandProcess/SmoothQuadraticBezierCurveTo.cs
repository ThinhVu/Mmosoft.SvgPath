using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SVGPathExplain.CommandProcess
{
    public class SmoothQuadraticBezierCurveTo : _ICommandProcessor
    {
        //public void Process(Command c)
        //{
        //    if (c.Paramenters.Count % 2 != 0)
        //        throw new ArgumentException("Missing parameters");

        //    var points = new List<string>();
        //    for (int i = 0; i < c.Paramenters.Count; i += 2)
        //        points.Add(string.Format("[(x: {0} y: {1})]", c.Paramenters[i], c.Paramenters[i + 1]));

        //    Console.Write(c.CommandText.ToUpper() == c.CommandText ? "[abs]" : "[rel]");
        //    Console.WriteLine(" SmoothQuadraticBezierCurveTo: " + string.Join(", ", points.ToArray()));            
        //}
        public void Process(Command c, GraphicsPath g, ref float x, ref float y)
        {
            if (c.Params.Count % 4 != 0)
                throw new ArgumentException("Missing parameters");

            PointF controlPoint = GetControlPoint1(c, currentPoint: new PointF(x, y));

            bool isAbs = c.CommandText.ToUpper() == c.CommandText;
            for (int i = 0; i < c.Params.Count; i += 2)
            {                
                var endPoint = new PointF((isAbs ? 0 : x) + c.Params[i], (isAbs ? 0 : y) + c.Params[i + 1]);

                g.AddBezier(new PointF(x, y), controlPoint, controlPoint, endPoint);

                x = endPoint.X;
                y = endPoint.Y;
            }
        }

        private PointF GetControlPoint1(Command c, PointF currentPoint)
        {
            PointF currentControlPoint1 = new PointF(0, 0);

            // if current is T or t and there is no Q, q, T, t
            // assume the first control point is coincident with the current point
            if (c.CommandText == "T" || c.CommandText == "t")
            {
                if (c.PrevCmd == null)
                {
                    currentControlPoint1 = currentPoint;
                }
                else if (c.PrevCmd.CommandText != "Q"
                    && c.PrevCmd.CommandText != "q"
                    && c.PrevCmd.CommandText != "T"
                    && c.PrevCmd.CommandText != "t")
                {
                    currentControlPoint1 = currentPoint;
                }
                else
                {
                    PointF prevSecondControlAbsPosition = new PointF(0, 0);
                    // otherwise, trying to get the last second control point of previous
                    string prevCmdText = c.PrevCmd.CommandText;
                    if (prevCmdText == "Q")
                    {
                        // ((x1 y1) (x y))+
                        for (int i = 0; i < c.PrevCmd.Params.Count; i += 4)
                            prevSecondControlAbsPosition = new PointF(c.PrevCmd.Params[i], c.PrevCmd.Params[i + 1]);
                    }
                    else if (prevCmdText == "q")
                    {                        
                        PointF offsetOfSecondPoint = new Point(0, 0);
                        PointF offsetToCurrentPoint = new Point(0, 0);

                        // ((x1 y1) (x2 y2) (x y))+
                        for (int i = 0; i < c.PrevCmd.Params.Count; i += 4)
                        {                            
                            offsetOfSecondPoint = new PointF(c.PrevCmd.Params[i], c.PrevCmd.Params[i + 1]);
                            offsetToCurrentPoint = new PointF(c.PrevCmd.Params[i + 2], c.PrevCmd.Params[i + 3]);
                        }

                        prevSecondControlAbsPosition = new PointF(
                            currentPoint.X - offsetToCurrentPoint.X + offsetOfSecondPoint.X,
                            currentPoint.Y - offsetToCurrentPoint.Y + offsetOfSecondPoint.Y);
                    }
                    else if (prevCmdText == "T")
                    {
                        // TODO:                         
                        // Lost the track! We must loop back to the first node then calculate from starting point
                        throw new Exception("Lost the track!");
                    }
                    else if (prevCmdText == "t")
                    {
                        throw new Exception("Lost the track!");
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
