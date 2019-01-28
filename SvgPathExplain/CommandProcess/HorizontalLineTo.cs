using System;
using System.Collections.Generic;

namespace ConsoleApp7.CommandProcess
{
    public class HorizontalLineTo : CmdProcess
    {
        public HorizontalLineTo(bool relativePosition) : base(relativePosition)
        {
        }

        public override void Process(List<string> tokenize, ref int index)
        {
            float x = float.Parse(tokenize[++index]);
            Console.WriteLine(
                "Draw horizontal line to {0} {1}px {2}",
                x < 0 ? " the left " : " the right ",
                Math.Abs(x),
                this.absolutePosition ? "" : "relative.");
        }
    }
}
