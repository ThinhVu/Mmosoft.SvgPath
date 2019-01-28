using System;

namespace SVGPathExplain.CommandProcess
{
    public class HorizontalLineTo : _ICommandProcessor
    {      
        public void Process(Command c)
        {
            Console.Write(c.CommandText.ToUpper() == c.CommandText? "[abs]": "[rel]");
            Console.WriteLine(" HorizontalLineTo: " + c.Paramenters[0]);            
        }
    }
}
