using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SVGPath.CmdConverter
{
    class ClosePathCmdConverter : ICmdConverter
    {
        public Cmd[] Convert(Cmd c, Cmd prevC, ref float absX, ref float absY)
        {
            Cmd[] cmds = new Cmd[1];
            cmds[0] = new Cmd { Text = "Z" };
            return cmds;
        }
    }
}
