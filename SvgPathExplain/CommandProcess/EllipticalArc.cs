using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;

namespace SVGPathExplain.CommandProcess
{
    public class EllipticalArc : _ICommandProcessor
    {       
        //public void Process(Command c)
        //{
        //    if (c.Paramenters.Count % 7 != 0)
        //        throw new ArgumentException("Missing parameter!");

        //    var points = new List<string>();
        //    for (int i = 0; i < c.Paramenters.Count; i += 7)
        //        points.Add(string.Format("(rx: {0} ry: {1} x-axis-rotation: {2} large-arc-flag: {3} sweep-flag: {4} x: {5} y: {6})", 
        //            c.Paramenters[i], c.Paramenters[i + 1], c.Paramenters[i + 2], c.Paramenters[i + 3], c.Paramenters[i + 4], c.Paramenters[i + 5], c.Paramenters[i + 6]));

        //    Console.Write(c.CommandText.ToUpper() == c.CommandText ? "[abs]" : "[rel]");
        //    Console.WriteLine(" EllipticalArc: " + string.Join(", ", points.ToArray()));            
        //}

        public void Process(Command command, GraphicsPath g, ref float x, ref float y)
        {
            throw new NotImplementedException();
        }
    }
}
