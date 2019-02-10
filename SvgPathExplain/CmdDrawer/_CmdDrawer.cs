using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using SVGPath;
using SVGPath.CommandProcess;

namespace SVGPath.CmdDrawer
{
    // ref: https://www.w3.org/TR/SVG/paths.html#PathDataLinetoCommands
    // ref: https://useiconic.com/open/
    // ref: https://github.com/iconic/open-iconic
    public static class CmdDrawer
    {       
        public static Bitmap Draw(List<Cmd> cmds, int width, int height, Brush brush)
        {
            var b = new Bitmap(width, height);
            var g = Graphics.FromImage(b);
            g.SmoothingMode = SmoothingMode.HighQuality;

            var gp = new GraphicsPath();
            for (int i = 0, cmdCount = cmds.Count; i < cmdCount; i++)
                CmdDrawerFactory.Create(cmds[i].Text).Process(cmds[i], gp);
            g.FillPath(brush, gp);

            gp.Dispose();
            g.Dispose();
            return b;
        }         
    }
}
