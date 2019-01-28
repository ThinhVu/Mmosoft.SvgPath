using System;
using System.Collections.Generic;

namespace SVGPathExplain.CommandProcess
{
    public class SmoothQuadraticBezierCurveTo : _ICommandProcessor
    {
        public void Process(Command c)
        {
            if (c.Paramenters.Count % 2 != 0)
                throw new ArgumentException("Missing parameters");
           
            var points = new List<string>();
            for (int i = 0; i < c.Paramenters.Count; i += 2)
                points.Add(string.Format("[(x: {0} y: {1})]", c.Paramenters[i], c.Paramenters[i + 1]));

            Console.Write(c.CommandText.ToUpper() == c.CommandText ? "[abs]" : "[rel]");
            Console.WriteLine(" SmoothQuadraticBezierCurveTo: " + string.Join(", ", points.ToArray()));            
        }
    }
}
