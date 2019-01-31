using System.Drawing.Drawing2D;

namespace SVGPathExplain.CommandProcess
{
    public class ClosePath : _ICommandProcessor
    {     
        public void Process(Command command, GraphicsPath g, ref float x, ref float y)
        {
            g.CloseFigure();
        }
    }
}
