using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using SVGPathExplain.CommandProcess;

namespace SVGPathExplain
{
    // ref: https://www.w3.org/TR/SVG/paths.html#PathDataLinetoCommands
    // ref: https://useiconic.com/open/
    // ref: https://github.com/iconic/open-iconic
    public class SvgPathCommand
    {
        private static Dictionary<string, _ICommandProcessor> commandProcessors = new Dictionary<string, _ICommandProcessor>
        {
            // moveto
            { "M", new MoveTo() },
            { "m", new MoveTo() },
            // lineto
            { "L", new LineTo() },
            { "l", new LineTo() },
            //  horizontal lineto
            { "H", new HorizontalLineTo() },
            { "h", new HorizontalLineTo() },
            // vertical lineto
            { "V", new VerticalLineTo() },
            { "v", new VerticalLineTo() },
            // curveto
            { "C", new CurveTo() },
            { "c", new CurveTo() },
            // smooth curveto
            { "S", new SmoothCurveTo() },
            { "s", new SmoothCurveTo() },
            // quadratic Bézier curve
            { "Q", new QuadraticBezierCurve() },
            { "q", new QuadraticBezierCurve() },
            // smooth quadratic Bézier curveto
            { "T", new SmoothQuadraticBezierCurveTo() },
            { "t", new SmoothQuadraticBezierCurveTo() },
            // elliptical Arc
            { "A", new EllipticalArc() },
            { "a", new EllipticalArc() },
            // closepath
            { "Z", new ClosePath() },
            { "z", new ClosePath() },
        };

        private int ratio;

        public SvgPathCommand()
        {
            ratio = 10;
        }

        public Bitmap Explain(string path, int width, int height)
        {
            var tokenized = PathTokenize(path);
            var rawCommands = BuildCommands(tokenized);
            var cmds = PreprocessCommands(rawCommands);
            return this.Execute(cmds, width, height);
        }

        private List<Command> BuildCommands(List<string> tokenizedPath)
        {
            List<Command> commands = new List<Command>();
            Command command = null;
            for (int i = 0, c = tokenizedPath.Count; i < c; i++)
            {
                if (tokenizedPath[i].Length == 1 && !char.IsDigit(tokenizedPath[i][0]))
                {
                    if (command != null)
                        commands.Add(command);

                    command = new Command(tokenizedPath[i]);
                }
                else
                {
                    command.Params.Add(float.Parse(tokenizedPath[i]) * ratio);
                }
            }

            // last close path
            if (command != null)
                commands.Add(command);

            return commands;
        }

        private Bitmap Execute(List<Command> commands, int width, int height)
        {            
            Bitmap b = new Bitmap((width + 1) * ratio, (height + 1) * ratio);
            Graphics g = Graphics.FromImage(b);
            GraphicsPath gp = new GraphicsPath();
            
            float x = 0;
            float y = 0;
            Command c;
            for (int i = 0, cmdCount = commands.Count; i < cmdCount; i++)
            {
                c = commands[i];
                commandProcessors[c.CommandText].Process(c, gp, ref x, ref y);
            }

            g.SmoothingMode = SmoothingMode.HighQuality;
            g.FillPath(Brushes.Black, gp);
            gp.Dispose();
            g.Dispose();
            return b;
        }

        private List<Command> PreprocessCommands(List<Command> cmds)
        {
            for (int i = 1; i < cmds.Count; ++i)
                cmds[i].PrevCmd = cmds[i - 1];

            return cmds;
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

            if (number.Length != 0)
                tokenize.Add(number.ToString());

            return tokenize;
        }
    }
}
