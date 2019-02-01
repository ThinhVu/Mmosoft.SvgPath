using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SVGPathExplain.CmdConverter
{
    class AbsoluteLineToCmdConverter : ICmdConverter
    {
        public Cmd[] Convert(Cmd c, Cmd prevC, ref float absX, ref float absY)
        {
            List<Cmd> cmds = new List<Cmd>();
            for (int i = 0; i < c.Params.Count; i+=2)
            {
                Cmd cmd = new Cmd { CmdText = "L", X = absX, Y = absY };
                cmd.Params.Add(c.Params[i]);
                cmd.Params.Add(c.Params[i+1]);
                absX = c.Params[i];
                absY = c.Params[i+1];
                cmds.Add(cmd);
            }
            return cmds.ToArray();
        }
    }
}
