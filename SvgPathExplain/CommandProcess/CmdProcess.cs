using System.Collections.Generic;

namespace ConsoleApp7.CommandProcess
{
    public abstract class CmdProcess
    {
        protected bool absolutePosition;
        protected CmdProcess(bool absPos)
        {
            this.absolutePosition = absPos;
        }
        public abstract void Process(List<string> tokenize, ref int index);
    }
}
