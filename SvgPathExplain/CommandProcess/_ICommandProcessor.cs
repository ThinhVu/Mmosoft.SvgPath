using System.Drawing.Drawing2D;

namespace SVGPathExplain.CommandProcess
{
    public interface _ICommandProcessor
    {
        void Process(Command command, GraphicsPath g, ref float x, ref float y);
    }
}
