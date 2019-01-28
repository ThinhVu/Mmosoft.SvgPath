using System;
using System.Collections.Generic;

namespace SVGPathExplain.CommandProcess
{
    public class QuadraticBezierCurve : _ICommandProcessor
    {        
        public void Process(Command c)
        {
            if (c.Paramenters.Count % 4 != 0)
                throw new ArgumentException("Missing parameters");
            
            var points = new List<string>();
         
            for (int i = 0; i < c.Paramenters.Count; i += 4)
                points.Add(string.Format("[(x1: {0} y1: {1} x: {2} y: {3})]", c.Paramenters[i], c.Paramenters[i + 1], c.Paramenters[i + 2], c.Paramenters[i + 3]));

            Console.Write(c.CommandText.ToUpper() == c.CommandText ? "[abs]" : "[rel]");
            Console.WriteLine(" QuadraticBezierCurve: " + string.Join(", ", points.ToArray()));            
        }        
    }
}
