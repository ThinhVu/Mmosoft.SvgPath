namespace SVGPathExplain
{
    public static class PathValidator
    {
        public static void Validate(Cmd command)
        {
            if (command == null)
                throw new InvalidCmdException("Null command");

            switch(command.CmdText)
            {
                case "M":
                case "m":
                case "L":
                case "l":
                    if (command.Params.Count % 2 != 0)
                        throw new InvalidCmdException($"{command.CmdText} required parameters is multiples of 2!");
                    break;                        
                case "H":
                case "h":
                case "V":
                case "v":
                    if (command.Params.Count != 1)
                        throw new InvalidCmdException($"{command.CmdText} cannot have more than 1 parameter!");
                    break;
                case "C":
                case "c":
                    if (command.Params.Count %6 != 0)
                        throw new InvalidCmdException($"{command.CmdText} required parameters number is multiples of 6!");
                    break;
                case "S":
                case "s":
                case "Q":
                case "q":
                    if (command.Params.Count % 4 != 0)
                        throw new InvalidCmdException($"{command.CmdText} required parameters number is multiples of 4!");
                    break;
                case "T":
                case "t":
                    if (command.Params.Count % 2 != 0)
                        throw new InvalidCmdException($"{command.CmdText} required parameters number is multiples of 2!");
                    break;
                case "A":
                case "a":
                    if (command.Params.Count % 7 != 0)
                        throw new InvalidCmdException($"{command.CmdText} required parameters number is multiples of 7!");
                    break;                
                default:
                    throw new InvalidCmdException($"{command.CmdText} is invalid command");
            }
        }
    }
}
