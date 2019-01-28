using System;
using System.Collections.Generic;

namespace ConsoleApp7.CommandProcess
{
    public class ClosePath : CmdProcess
    {
        public ClosePath(bool relativePosition) : base(relativePosition)
        {
        }

        public override void Process(List<string> tokenize, ref int index)
        {
            Console.WriteLine("Close path!");
        }
    }
}
