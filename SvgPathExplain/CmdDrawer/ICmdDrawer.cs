using System.Drawing.Drawing2D;

namespace SVGPathExplain.CommandProcess
{
    public interface ICmdDrawer
    {
        void Process(Cmd command, GraphicsPath g);
    }
}
