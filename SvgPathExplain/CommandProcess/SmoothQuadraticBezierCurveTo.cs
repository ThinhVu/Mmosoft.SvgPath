using System;
using System.Collections.Generic;

namespace ConsoleApp7.CommandProcess
{
    public class SmoothQuadraticBezierCurveTo : CmdProcess
    {
        public SmoothQuadraticBezierCurveTo(bool relativePosition) : base(relativePosition)
        {
        }

        public override void Process(List<string> tokenize, ref int index)
        {
            throw new NotImplementedException();
        }
    }
}
