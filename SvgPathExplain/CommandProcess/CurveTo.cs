using System;
using System.Collections.Generic;

namespace SVGPathExplain.CommandProcess
{
    public class CurveTo : _ICommandProcessor
    {
        public void Process(Command c)
        {
            if (c.Paramenters.Count % 6 != 0)
                throw new Exception("Argument missing!");

            var points = new List<string>();
            for (int i = 0; i < c.Paramenters.Count; i += 6)
                points.Add($"[{c.Paramenters[i]}, {c.Paramenters[i + 1]}, {c.Paramenters[i + 2]}, {c.Paramenters[i + 3]}, {c.Paramenters[i + 4]}, {c.Paramenters[i + 5]}]");

            Console.Write(c.CommandText.ToUpper() == c.CommandText ? "[abs]" : "[rel]");
            Console.WriteLine(" CurveTo: " + string.Join(", ", points.ToArray()));            
        }
    }
}
