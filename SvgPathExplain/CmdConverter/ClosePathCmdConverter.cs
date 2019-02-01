using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SVGPathExplain.CmdConverter
{
    class ClosePathCmdConverter : ICmdConverter
    {
        public Cmd[] Convert(Cmd c, Cmd prevC, ref float absX, ref float absY)
        {
            Cmd[] cmds = new Cmd[1];
            cmds[0] = new Cmd { CmdText = "Z" };
            return cmds;
        }
    }
}
