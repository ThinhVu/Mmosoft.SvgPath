using System;
using System.Collections.Generic;

namespace SVGPathExplain.CmdConverter
{
    public class AbsoluteCurveToCmdConveter : ICmdConverter
    {
        public Cmd[] Convert(Cmd c, Cmd prevC, ref float absX, ref float absY)
        {
            List<Cmd> cmds = new List<Cmd>();
            Cmd cmd = null;
            for (int i = 0, paramCount = c.Params.Count; i < paramCount; i+=6)
            {
                cmd = new Cmd { CmdText = "C", X = absX, Y = absY };
                cmd.Params.Add(c.Params[i]);
                cmd.Params.Add(c.Params[i+1]);
                cmd.Params.Add(c.Params[i+2]);
                cmd.Params.Add(c.Params[i+3]);
                cmd.Params.Add(c.Params[i+4]);
                cmd.Params.Add(c.Params[i+5]);
                //
                absX = c.Params[i + 4];
                absY = c.Params[i + 5];
                //
                cmds.Add(cmd);
            }
            return cmds.ToArray();
        }
    }
}