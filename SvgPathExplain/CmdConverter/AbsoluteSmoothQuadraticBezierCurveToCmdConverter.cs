using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SVGPathExplain.CmdConverter
{
    class AbsoluteSmoothQuadraticBezierCurveToCmdConverter : ICmdConverter
    {
        public Cmd[] Convert(Cmd c, Cmd prevC, ref float absX, ref float absY)
        {
            List<Cmd> cmds = new List<Cmd>();
            Cmd cmd;
            for (int i = 0; i < c.Params.Count; i += 2)
            {
                cmd = new Cmd { CmdText = "C", X = absX, Y = absY };
                // control point 1
                if (prevC.CmdText == "C")
                {
                    float controlPoint2PrevX = c.Params[3];
                    float controlPoint2PrevY = c.Params[4];
                    //
                    cmd.Params.Add(2 * absX - c.Params[3]);
                    cmd.Params.Add(2 * absY - c.Params[4]);
                }
                else
                {
                    cmd.Params.Add(absX);
                    cmd.Params.Add(absY);
                }
                cmd.Params.Add(c.Params[i]);
                cmd.Params.Add(c.Params[i + 1]);
                cmd.Params.Add(c.Params[i + 3]);
                cmd.Params.Add(c.Params[i + 4]);
                absX = c.Params[i + 3];
                absY = c.Params[i + 4];
                cmds.Add(cmd);
            }
            return cmds.ToArray();
        }
    }
}
