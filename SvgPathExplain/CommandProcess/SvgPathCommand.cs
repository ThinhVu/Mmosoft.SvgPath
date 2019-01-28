using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp7.CommandProcess
{
    // ref: https://www.w3.org/TR/SVG/paths.html#PathDataLinetoCommands
    // ref: https://useiconic.com/open/
    // ref: https://github.com/iconic/open-iconic
    public class SvgPathCommand
    {
        public void Explain(string name, string path)
        {
            Console.WriteLine("Draw " + name);
            var token = PathTokenize(path);
            Execute(token);
        }

        private void Execute(List<string> tokenize)
        {
            var cmds = new Dictionary<string, CmdProcess>
                {
                    // moveto
                    { "M", new MoveTo(true) }, { "m", new MoveTo(false) },
                    // lineto
                    { "L", new LineTo(true) }, { "l", new LineTo(false) },
                    //  horizontal lineto
                    { "H", new HorizontalLineTo(true) }, { "h", new HorizontalLineTo(false) },
                    // vertical lineto
                    { "V", new VerticalLineTo(true) }, { "v", new VerticalLineTo(false) },
                    // curveto
                    { "C", new CurveTo(true) }, { "c", new CurveTo(false) },
                    // smooth curveto
                    { "S", new SmoothCurveTo(true) }, { "s", new SmoothCurveTo(false) },
                    // quadratic Bézier curve
                    { "Q", new QuadraticBezierCurve(true) }, { "q", new QuadraticBezierCurve(false) },
                    // smooth quadratic Bézier curveto
                    { "T", new SmoothQuadraticBezierCurveTo(true) }, { "t", new SmoothQuadraticBezierCurveTo(false) },
                    // elliptical Arc
                    { "A", new EllipticalArc(true) },{ "a", new EllipticalArc(false) },
                    // closepath
                    { "Z", new ClosePath(true) }, { "z", new ClosePath(false) },
                };

            int i = 0;
            while (i < tokenize.Count)
            {
                cmds[tokenize[i]].Process(tokenize, ref i);
                i++; // next cmd
            }
        }

        private List<string> PathTokenize(string path)
        {
            var tokenize = new List<string>();
            //
            var numAlreadyContainDot = false;
            var number = new StringBuilder();

            int i = 0;
            while (i < path.Length)
            {
                if (char.IsLetter(path[i]))
                {
                    if (number.Length != 0)
                    {
                        tokenize.Add(number.ToString());
                        numAlreadyContainDot = false;
                        number = new StringBuilder();
                    }
                    tokenize.Add(path[i].ToString());
                    i++;
                }
                // start or append number
                else if (char.IsDigit(path[i]))
                {
                    number.Append(path[i]);
                    i++;
                }
                // start number
                else if (path[i] == '-')
                {
                    // next number
                    if (number.Length != 0)
                    {
                        tokenize.Add(number.ToString());
                        numAlreadyContainDot = false;
                    }
                    number = new StringBuilder();
                    number.Append('-');
                    i++;
                }
                // append number
                else if (path[i] == '.')
                {
                    if (numAlreadyContainDot)
                    {
                        tokenize.Add(number.ToString());
                        numAlreadyContainDot = false;
                        number = new StringBuilder();
                    }

                    number.Append('.');
                    numAlreadyContainDot = true;
                    i++;
                }
                // separate 2 positive number
                else if (path[i] == ' ' || path[i] == ',')
                {
                    tokenize.Add(number.ToString());
                    numAlreadyContainDot = false;
                    number = new StringBuilder();
                    i++;
                }
            }

            return tokenize;
        }
    }
}
