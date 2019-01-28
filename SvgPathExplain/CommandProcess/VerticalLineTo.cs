using System;

namespace SVGPathExplain.CommandProcess
{
    public class VerticalLineTo : _ICommandProcessor
    {       
        public void Process(Command c)
        {
            Console.Write(c.CommandText.ToUpper() == c.CommandText ? "[abs]" : "[rel]");
            Console.WriteLine(" VerticalLineTo: " + c.Paramenters[0]);
        }
    }
}
