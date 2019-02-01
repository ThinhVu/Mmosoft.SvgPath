using System.Drawing;
using System.Drawing.Drawing2D;

namespace SVGPathExplain.CommandProcess
{
    public class MoveTo : ICmdDrawer
    {
        // (x y)+
        // Start a new sub-path at the given (x,y) coordinates. M (uppercase) indicates that 
        // absolute coordinates will follow; m (lowercase) indicates that relative coordinates
        // will follow. If a moveto is followed by multiple pairs of coordinates, the subsequent
        // pairs are treated as implicit lineto commands. Hence, implicit lineto commands will
        // be relative if the moveto is relative, and absolute if the moveto is absolute.
        public void Process(Cmd c, GraphicsPath g, ref float x, ref float y)
        {
            // M
            if (c.CmdText.ToUpper() == c.CmdText)
            {
                x = c.Params[0];
                y = c.Params[1];
            }
            // m
            else
            {
                x += c.Params[0];
                y += c.Params[1];
            }            
        }
    }
}
