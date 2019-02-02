using System.Drawing.Drawing2D;

namespace SVGPath.CommandProcess
{
    public class ClosePath : ICmdDrawer
    {     
        public void Process(Cmd command, GraphicsPath g)
        {
            g.CloseFigure();
        }
    }
}
