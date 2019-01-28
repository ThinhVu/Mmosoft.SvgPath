using System;
using System.Collections.Generic;

namespace ConsoleApp7.CommandProcess
{
    public class VerticalLineTo : CmdProcess
    {
        public VerticalLineTo(bool relativePosition) : base(relativePosition)
        {
        }

        public override void Process(List<string> tokenize, ref int index)
        {
            float y = float.Parse(tokenize[++index]);
            Console.WriteLine(
                "Draw vertical line to {0} {1}px {2}",
                y < 0 ? " the top " : " the bottom ",
                Math.Abs(y),
                this.absolutePosition ? "" : "relative.");
        }
    }
}
