using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using SVGPathExplain.CmdConverter;
using SVGPathExplain.CommandProcess;

namespace SVGPathExplain
{
    // ref: https://www.w3.org/TR/SVG/paths.html#PathDataLinetoCommands
    // ref: https://useiconic.com/open/
    // ref: https://github.com/iconic/open-iconic
    public class PathDrawer
    {        
        private int ratio;

        public PathDrawer()
        {
            ratio = 10;
        }   

        private Bitmap Draw(string path, int width, int height)
        {
            List<Cmd> cmds = CmdConverter.CmdConverter.Scale(CmdConverter.CmdConverter.NormalizeCommands(PathParser.Parse(path)), ratio);
            GraphicsPath gp = new GraphicsPath();
            for (int i = 0, cmdCount = cmds.Count; i < cmdCount; i++)
            {
                CmdDrawerFactory.Create(cmds[i].CmdText).Process(cmds[i], gp);
            }            
            Bitmap b = new Bitmap((width + 1) * ratio, (height + 1) * ratio);
            Graphics g = Graphics.FromImage(b);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.FillPath(Brushes.Black, gp);
            gp.Dispose();
            g.Dispose();
            return b;
        }         
    }
}
