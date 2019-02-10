using System.Collections.Generic;

namespace SVGPath
{
    public static class CmdScaler
    {
        /// <summary>
        /// Create new command collection which have position value = value * ratio
        /// </summary>
        /// <param name="commands"></param>
        /// <param name="ratio"></param>
        /// <returns></returns>
        public static List<Cmd> Scale(List<Cmd> commands, float ratio)
        {
            List<Cmd> cmds = new List<Cmd>(commands.Count);
            Cmd cmd;
            for (int i = 0, cmdCount = commands.Count; i < cmdCount; i++)
            {
                cmd = new Cmd
                {
                    Text = commands[i].Text,
                    X = commands[i].X * ratio,
                    Y = commands[i].Y * ratio
                };
                cmd.Params.AddRange(commands[i].Params);

                switch (cmd.Text)
                {
                    case "A":
                        cmd.Params[0] *= ratio; // rx
                        cmd.Params[1] *= ratio; // ry
                        cmd.Params[5] *= ratio; // x
                        cmd.Params[6] *= ratio; // 7
                        break;
                    default:
                        for (int j = 0, cmdParamCount = cmd.Params.Count; j < cmdParamCount; j++)
                        {
                            cmd.Params[j] *= ratio;
                        }
                        break;
                }

                cmds.Add(cmd);
            }
            return cmds;
        }
    }
}
