using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SVGPathExplain.CmdConverter
{
    class AbsoluteSmoothCurveToCmdConverter : ICmdConverter
    {
        public Cmd[] Convert(Cmd c, Cmd prevC, ref float absX, ref float absY)
        {
            List<Cmd> cmds = new List<Cmd>();
            Cmd cmd;
            for (int i = 0; i < c.Params.Count; i += 2)
            {
                cmd = new Cmd { CmdText = "C", X = absX, Y = absY };
                // control 1
                if (prevC.CmdText == "C")
                {
                    float prevSecondControlPointX = prevC.Params[2];
                    float prevSecondControlPointY = prevC.Params[3];

                    c.Params.Add(absX * 2 - prevSecondControlPointX);
                    c.Params.Add(absY * 2 - prevSecondControlPointY);
                }
                else
                {
                    c.Params.Add(absX);
                    c.Params.Add(absY);
                }
                // control 2
                cmd.Params.Add(c.Params[i]);
                cmd.Params.Add(c.Params[i + 1]);
                // next point
                cmd.Params.Add(c.Params[i + 2]);
                cmd.Params.Add(c.Params[i + 3]);
                //
                absX = c.Params[i + 3];
                absY = c.Params[i + 4];
                // 
                cmds.Add(cmd);
            }
            return cmds.ToArray();
        }
    }
}
