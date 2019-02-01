using System.Drawing;

namespace SVGPathExplain
{
    class Program
    {
        static void Main(string[] args)
        {
            var cmd = new PathDrawer();
            Bitmap b = cmd.Draw("M3.5 0c-1.93 0-3.5 1.57-3.5 3.5 0-1.38 1.12-2.5 2.5-2.5s2.5 1.12 2.5 2.5v.5h-1l2 2 2-2h-1v-.5c0-1.93-1.57-3.5-3.5-3.5z", 8, 8);
            b.Save("action-redo.bmp");
        }
    }
}
