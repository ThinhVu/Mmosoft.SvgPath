using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SVGPathExplain
{
    public class PathParser
    {        
        private static bool TokenIsCommand(string token)
        {
            return Cmd.AbsoluteCmdChars.Contains(token) || Cmd.RelativeCmdChars.Contains(token);
        }

        private static List<string> Tokenize(string path)
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

        public static List<Cmd> Parse(string path)
        {
            List<string> tokens = Tokenize(path);
            List<Cmd> commands = new List<Cmd>();
            Cmd command = new Cmd();
            
            for(int i=tokens.Count - 1; i>=0; i--)
            {
                if (TokenIsCommand(tokens[i]))
                {
                    //
                    command.CmdText = tokens[i];
                    command.Params.Reverse();
                    //
                    commands.Add(command);
                    // 
                    command = new Cmd();
                }
                else
                {
                    command.Params.Add(float.Parse(tokens[i]));
                }
            }
            
            return commands;
        }
    }
}
