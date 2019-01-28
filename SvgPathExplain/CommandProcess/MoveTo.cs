using System;
using System.Collections.Generic;

namespace ConsoleApp7.CommandProcess
{
    public class MoveTo : CmdProcess
    {
        public MoveTo(bool absPos) : base(absPos)
        {
        }

        public override void Process(List<string> tokenize, ref int index)
        {
            string x = tokenize[++index];
            string y = tokenize[++index];

            Console.WriteLine("Move to position ({0}, {1}) {2}", x, y, this.absolutePosition ? "" : "relative.");
        }
    }
}
