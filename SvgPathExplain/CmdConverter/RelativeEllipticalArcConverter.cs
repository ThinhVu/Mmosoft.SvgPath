using System.Collections.Generic;

namespace SVGPath.CmdConverter
{
    class RelativeEllipticalArcConverter : ICmdConverter
    {
        public Cmd[] Convert(Cmd c, Cmd prevC, ref float absX, ref float absY)
        {
            List<Cmd> cmds = new List<Cmd>();
            Cmd cmd = null;

            for (int i = 0, paramCount = c.Params.Count; i < paramCount; i += 7)
            {
                cmd = new Cmd { Text = "A", X = absX, Y = absY };
                cmd.Params.Add(c.Params[i]);
                cmd.Params.Add(c.Params[i + 1]);
                cmd.Params.Add(c.Params[i + 2]);
                cmd.Params.Add(c.Params[i + 3]);
                cmd.Params.Add(c.Params[i + 4]);
                cmd.Params.Add(c.Params[i + 5]);
                cmd.Params.Add(c.Params[i + 6]);
                //
                absX += c.Params[i + 5];
                absY += c.Params[i + 6];
                //
                cmds.Add(cmd);
            }

            return cmds.ToArray();
        }
    }
}
