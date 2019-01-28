using System;
using System.Collections.Generic;

namespace SVGPathExplain.CommandProcess
{
    public class MoveTo : _ICommandProcessor
    {
        public void Process(Command c)
        {
            var points = new List<string>();

            for(int i=0; i<c.Paramenters.Count; i+=2)
                points.Add(string.Format("({0}, {1})", c.Paramenters[i], c.Paramenters[i + 1]));
            
            Console.Write(c.CommandText.ToUpper() == c.CommandText ? "[abs]" : "[rel]");
            Console.WriteLine(" MoveTo: " + string.Join(", ", points.ToArray()));
        }
    }
}
