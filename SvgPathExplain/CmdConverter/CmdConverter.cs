using System.Collections.Generic;

namespace SVGPathExplain.CmdConverter
{
    public static class CmdConverter
    {
        /// <summary>
        /// Translate command from relative to absolute position
        /// Separate shorthand command to multiple commands
        /// 
        /// This method doesn't modify input commands
        /// </summary>
        /// <param name="cmds">New command collection object</param>
        /// <returns></returns>
        public static List<Cmd> NormalizeCommands(List<Cmd> cmds)
        {
            float absX = 0f;
            float absY = 0f;

            List<Cmd> absCommands = new List<Cmd>();
            Cmd curCmd;
            Cmd prevCmd;

            for (int i = 0, cmdCount = cmds.Count; i < cmdCount; i++)
            {
                curCmd = cmds[i];
                prevCmd = i > 0 ? cmds[i - 1] : null;

                PathValidator.Validate(cmds[i]);
                absCommands.AddRange(CmdConveterFactory.Create(curCmd.CmdText).Convert(curCmd, prevCmd, ref absX, ref absY));                
            }

            return absCommands;
        }

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
                cmd = new Cmd { CmdText = commands[i].CmdText };
                cmd.Params.AddRange(commands[i].Params);

                for (int j = 0, cmdParamCount = cmd.Params.Count; j < cmdParamCount; j++)
                {
                    cmd.Params[j] *= ratio;
                }

                cmds.Add(cmd);
            }
            return cmds;
        }
    }
}
