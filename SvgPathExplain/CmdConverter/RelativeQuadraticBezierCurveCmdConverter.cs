using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SVGPath
{
    class RelativeQuadraticBezierCurveCmdConverter : ICmdConverter
    {
        public Cmd[] Convert(Cmd c, Cmd prevC, ref float absX, ref float absY)
        {
            List<Cmd> cmds = new List<Cmd>();
            Cmd cmd = null;
            for (int i = 0; i < c.Params.Count; i += 2)
            {
                cmd = new Cmd { Text = "C", X = absX, Y = absY };
                // control point 1
                cmd.Params.Add(absX + c.Params[i]);
                cmd.Params.Add(absY + c.Params[i+1]);
                // control point 2
                cmd.Params.Add(absX + c.Params[i]);
                cmd.Params.Add(absY + c.Params[i+1]);
                // new position
                cmd.Params.Add(absX + c.Params[i+2]);                
                cmd.Params.Add(absY + c.Params[i+3]);
                // update position
                absX += c.Params[i + 2];
                absY += c.Params[i + 3];
                // 
                cmds.Add(cmd);
            }
            return cmds.ToArray();
        }
    }
}
