using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SVGPath.CommandProcess
{
    public class EllipticalArc : ICmdDrawer
    {
        // See the original implementation at: https://github.com/vvvv/SVG
        public void Process(Cmd c, GraphicsPath g)
        {
            // rx ry x-axis-rotation large-arc-flag sweep-flag x y

            // Draws an elliptical arc from the current point to (x, y). 
            // The size and orientation of the ellipse are defined by two radii (rx, ry) and an x-axis-rotation, 
            // which indicates how the ellipse as a whole is rotated, in degrees, relative to the current coordinate system. 
            // The center (cx, cy) of the ellipse is calculated automatically to satisfy the constraints imposed by the other parameters.
            // large-arc-flag and sweep-flag contribute to the automatic calculations and help determine how the arc is drawn.

            PointF start = new PointF(c.X, c.Y);
            PointF end = new PointF(c.Params[5], c.Params[6]);

            float radiusX = c.Params[0];
            float radiusY = c.Params[1];
            float xAxisRotation = c.Params[2];
            float largeArcFlag = c.Params[3];
            float sweepFlag = c.Params[4];
            float x = c.Params[5];
            float y = c.Params[6];


            if (start == end)
                return;

            if (radiusX == 0.0f && radiusY == 0.0f)
                g.AddLine(start, end);

            double radiansPerDegree = Math.PI / 180;
            double doublePi = Math.PI * 2;

            double sinPhi = Math.Sin(xAxisRotation * radiansPerDegree);
            double cosPhi = Math.Cos(xAxisRotation * radiansPerDegree);

            double x1Dash = cosPhi * (start.X - end.X) / 2.0 + sinPhi * (start.Y - end.Y) / 2.0;
            double y1Dash = -sinPhi * (start.X - end.X) / 2.0 + cosPhi * (start.Y - end.Y) / 2.0;

            double root;
            double numerator = (radiusX * radiusX * radiusY * radiusY) - (radiusX * radiusX * y1Dash * y1Dash) - (radiusY * radiusY * x1Dash * x1Dash);


            float rx = radiusX;
            float ry = radiusY;

            if (numerator < 0.0)
            {
                float s = (float)Math.Sqrt(1.0 - numerator / (radiusX * radiusX * radiusY * radiusY));
                rx *= s;
                ry *= s;
                root = 0.0;
            }
            else
            {
                root = ((largeArcFlag == 1 && sweepFlag == 1) || (largeArcFlag == 0 && sweepFlag == 0) ? -1 : 1) * Math.Sqrt(numerator / (radiusX * radiusX * y1Dash * y1Dash + radiusY * radiusY * x1Dash * x1Dash));
            }

            double cxDash = root * rx * y1Dash / ry;
            double cyDash = -root * ry * x1Dash / rx;

            double cx = cosPhi * cxDash - sinPhi * cyDash + (start.X + end.X) / 2.0;
            double cy = sinPhi * cxDash + cosPhi * cyDash + (start.Y + end.Y) / 2.0;

            double theta1 = CalculateVectorAngle(1.0, 0.0, (x1Dash - cxDash) / rx, (y1Dash - cyDash) / ry);
            double dTheta = CalculateVectorAngle((x1Dash - cxDash) / rx, (y1Dash - cyDash) / ry, (-x1Dash - cxDash) / rx, (-y1Dash - cyDash) / ry);

            if (sweepFlag == 0 && dTheta > 0)
            {
                dTheta -= DoublePI;
            }
            else if (sweepFlag == 1 && dTheta < 0)
            {
                dTheta += DoublePI;
            }


            int segments = (int)Math.Ceiling((double)Math.Abs(dTheta / (Math.PI / 2.0)));
            double delta = dTheta / segments;
            double t = 8.0 / 3.0 * Math.Sin(delta / 4.0) * Math.Sin(delta / 4.0) / Math.Sin(delta / 2.0);

            double startX = start.X;
            double startY = start.Y;

            for (int i = 0; i < segments; i++)
            {
                double cosTheta1 = Math.Cos(theta1);
                double sinTheta1 = Math.Sin(theta1);
                double theta2 = theta1 + delta;
                double cosTheta2 = Math.Cos(theta2);
                double sinTheta2 = Math.Sin(theta2);

                double endpointX = cosPhi * rx * cosTheta2 - sinPhi * ry * sinTheta2 + cx;
                double endpointY = sinPhi * rx * cosTheta2 + cosPhi * ry * sinTheta2 + cy;

                double dx1 = t * (-cosPhi * rx * sinTheta1 - sinPhi * ry * cosTheta1);
                double dy1 = t * (-sinPhi * rx * sinTheta1 + cosPhi * ry * cosTheta1);

                double dxe = t * (cosPhi * rx * sinTheta2 + sinPhi * ry * cosTheta2);
                double dye = t * (sinPhi * rx * sinTheta2 - cosPhi * ry * cosTheta2);

                g.AddBezier((float)startX, (float)startY, (float)(startX + dx1), (float)(startY + dy1),
                    (float)(endpointX + dxe), (float)(endpointY + dye), (float)endpointX, (float)endpointY);

                theta1 = theta2;
                startX = (float)endpointX;
                startY = (float)endpointY;
            }          
        }

        private const double DoublePI = Math.PI * 2;
        private static double CalculateVectorAngle(double ux, double uy, double vx, double vy)
        {
            double ta = Math.Atan2(uy, ux);
            double tb = Math.Atan2(vy, vx);

            if (tb >= ta)
            {
                return tb - ta;
            }

            return DoublePI - (ta - tb);
        }
    }
}
