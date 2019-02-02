using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SVGPath.CmdConverter
{
    class AbsoluteSmoothQuadraticBezierCurveToCmdConverter : ICmdConverter
    {
        public Cmd[] Convert(Cmd c, Cmd prevC, ref float absX, ref float absY)
        {
            List<Cmd> cmds = new List<Cmd>();
            Cmd cmd;
            for (int i = 0; i < c.Params.Count; i += 2)
            {
                cmd = new Cmd { Text = "C", X = absX, Y = absY };
                // control point 1                
                if (cmds.Count > 0)
                {
                    float controlPoint2PrevX = cmds[cmds.Count - 1].Params[2];
                    float controlPoint2PrevY = cmds[cmds.Count - 1].Params[3];
                    //
                    cmd.Params.Add(2 * absX - controlPoint2PrevX);
                    cmd.Params.Add(2 * absY - controlPoint2PrevY);
                }
                else if (prevC.Text == "C")
                {
                    float controlPoint2PrevX = prevC.Params[2];
                    float controlPoint2PrevY = prevC.Params[3];
                    //
                    cmd.Params.Add(2 * absX - controlPoint2PrevX);
                    cmd.Params.Add(2 * absY - controlPoint2PrevY);
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
