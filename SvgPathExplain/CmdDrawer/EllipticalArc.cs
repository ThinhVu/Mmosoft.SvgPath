using System.Drawing.Drawing2D;

namespace SVGPath.CommandProcess
{
    public class EllipticalArc : ICmdDrawer
    {               
        public void Process(Cmd c, GraphicsPath g)
        {
            // rx ry x-axis-rotation large-arc-flag sweep-flag x y

            // Draws an elliptical arc from the current point to (x, y). 
            // The size and orientation of the ellipse are defined by two radii (rx, ry) and an x-axis-rotation, 
            // which indicates how the ellipse as a whole is rotated, in degrees, relative to the current coordinate system. 
            // The center (cx, cy) of the ellipse is calculated automatically to satisfy the constraints imposed by the other parameters.
            // large-arc-flag and sweep-flag contribute to the automatic calculations and help determine how the arc is drawn.

            // TODO:
            throw new InvalidCmdException($"Command {c.Text} is not supported yet!");
        }
    }
}
