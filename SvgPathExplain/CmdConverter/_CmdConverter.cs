using System.Collections.Generic;

namespace SVGPath
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
        public static List<Cmd> ExtractToSingleAndAbsolutePositionCmds(List<Cmd> cmds)
        {
            float absX = 0f;
            float absY = 0f;

            List<Cmd> absCommands = new List<Cmd>();
            Cmd curCmd;
            Cmd prevCmd;

            for (int i = 0, cmdCount = cmds.Count; i < cmdCount; i++)
            {
                curCmd = cmds[i];
                prevCmd = absCommands.Count > 0? absCommands[absCommands.Count - 1] : null;                
                absCommands.AddRange(CmdConveterFactory.Create(curCmd.Text).Convert(curCmd, prevCmd, ref absX, ref absY));                
            }

            return absCommands;
        }
    }
}
