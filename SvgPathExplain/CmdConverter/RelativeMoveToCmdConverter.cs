using System.Collections.Generic;

namespace SVGPathExplain.CmdConverter
{
    public class RelativeMoveToCmdConverter : ICmdConverter
    {
        public Cmd[] Convert(Cmd c, Cmd prevC, ref float absX, ref float absY)
        {
            List<Cmd> cmds = new List<Cmd>();
            Cmd cmd = new Cmd { CmdText = "M" };
            
            absX += c.Params[0];
            absY += c.Params[1];

            cmd.Params.Add(absX);
            cmd.Params.Add(absY);

            cmds.Add(cmd);

            // line to
            if (c.Params.Count > 2)
            {
                int j = 2;
                while (j < c.Params.Count)
                {
                    cmd = new Cmd { CmdText = "L" };
                    absX += c.Params[j];
                    absY += c.Params[j + 1];

                    cmd.Params.Add(absX);
                    cmd.Params.Add(absY);
                    cmds.Add(cmd);
                    j += 2;
                }
            }

            return cmds.ToArray();
        }
    }
}
