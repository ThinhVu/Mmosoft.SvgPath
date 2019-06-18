using System.Collections.Generic;

namespace SVGPath
{
    public static class CmdValidator
    {
        // Validate command
        public static void ValidateCmds(List<Cmd> cmds)
        {
            for (int i = 0; i < cmds.Count; i++)
            {
                Validate(cmds[i], i);
            }
        }

        private static void Validate(Cmd command, int index)
        {
            if (command == null)
                throw new System.ArgumentNullException(string.Format("command {0} is null", index));

            switch(command.Text)
            {
                case "Z":
                case "z":
                    break;
                case "H":
                case "h":
                case "V":
                case "v":
                    if (command.Params.Count != 1)
                        throw new InvalidCmdException(string.Format("{0} cannot have more than 1 parameter!", command.Text), index);
                    break;
                case "M":
                case "m":
                case "L":
                case "l":
                case "T":
                case "t":
                    if (command.Params.Count % 2 != 0)
                        throw new InvalidCmdException(string.Format("{0} required parameters is multiples of 2!", command.Text), index);
                    break;
                case "S":
                case "s":
                case "Q":
                case "q":
                    if (command.Params.Count % 4 != 0)
                        throw new InvalidCmdException(string.Format("{0} required parameters number is multiples of 4!", command.Text), index);
                    break;
                case "C":
                case "c":
                    if (command.Params.Count %6 != 0)
                        throw new InvalidCmdException(string.Format("{0} required parameters number is multiples of 6!", command.Text), index);
                    break;
                case "A":
                case "a":
                    if (command.Params.Count % 7 != 0)
                        throw new InvalidCmdException(string.Format("{0} required parameters number is multiples of 7!", command.Text), index);
                    break;
                default:
                    throw new InvalidCmdException(string.Format("{0} is invalid command", command.Text));
            }
        }
    }
}
