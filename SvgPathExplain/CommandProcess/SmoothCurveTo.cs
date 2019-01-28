using System;
using System.Collections.Generic;

namespace SVGPathExplain.CommandProcess
{
    public class SmoothCurveTo : _ICommandProcessor
    {        
        public void Process(Command c)
        {
            // build point
            if (c.Paramenters.Count % 4 != 0)
                throw new Exception("Argument missing!");

            var points = new List<string>();
            for (int i = 0; i < c.Paramenters.Count; i += 4)
                points.Add(string.Format("[({0}, {1}) ({2}, {3})]", c.Paramenters[i], c.Paramenters[i+1], c.Paramenters[i+2], c.Paramenters[i+3]));

            Console.Write(c.CommandText.ToUpper() == c.CommandText ? "[abs]" : "[rel]");
            Console.WriteLine(" SmoothCurveTo: " + string.Join(", ", points.ToArray()));            
        }
    }
}
