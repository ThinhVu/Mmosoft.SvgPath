using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SVGPathExplain.CommandProcess
{
    public static class CmdDrawerFactory
    {
        public static ICmdDrawer Create(string cmd)
        {
            switch(cmd)
            {
                case "M":
                    return new MoveTo();
                case "L":
                    return new LineTo();
                case "C":
                    return new CurveTo();
                case "H":
                    return new HorizontalLineTo();                    
                case "V":
                    return new VerticalLineTo();                    
                case "A":
                    return new EllipticalArc();
                case "Z":
                    return new ClosePath();
                default:
                    throw new InvalidCmdException($"Command {cmd} are not supported!");
            }                
        }
    }
}
