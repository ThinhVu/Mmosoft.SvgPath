using System.Drawing.Drawing2D;

namespace SVGPath.CommandProcess
{
    public interface ICmdDrawer
    {
        void Process(Cmd command, GraphicsPath g);
    }
}
