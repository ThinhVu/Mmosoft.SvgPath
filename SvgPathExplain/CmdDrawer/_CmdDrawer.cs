using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using SVGPath.CmdConverter;
using SVGPath.CommandProcess;

namespace SVGPath.CmdDrawer
{
    // ref: https://www.w3.org/TR/SVG/paths.html#PathDataLinetoCommands
    // ref: https://useiconic.com/open/
    // ref: https://github.com/iconic/open-iconic
    public class CmdDrawer
    {
        public int Ratio;

        public CmdDrawer()
        {
            Ratio = 10;
        }   

        public Bitmap Draw(string path, int width, int height)
        {
            List<Cmd> inputCmds = PathParser.Parse(path);
            List<Cmd> cmds = CmdConverter.CmdConverter.Scale(CmdConverter.CmdConverter.NormalizeCommands(inputCmds), Ratio);
            GraphicsPath gp = new GraphicsPath();
            for (int i = 0, cmdCount = cmds.Count; i < cmdCount; i++)
            {
                CmdDrawerFactory.Create(cmds[i].Text).Process(cmds[i], gp);
            }            
            Bitmap b = new Bitmap(width * Ratio + 1, height * Ratio + 1);
            Graphics g = Graphics.FromImage(b);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.FillPath(Brushes.Black, gp);
            gp.Dispose();
            g.Dispose();
            return b;
        }         
    }
}
